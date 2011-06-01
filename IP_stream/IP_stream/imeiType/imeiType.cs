using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Diagnostics;
using IP_stream.Linq;

namespace IP_stream
{
    class imeiTypeClass
    {
        #region
        //远程取imsi,imei关系
        #endregion
        private  DataClasses1DataContext localdb = new DataClasses1DataContext(streamType.LocalConnString);
        private Dictionary<string, msIMEI> _MsImeiCollection;
        public Dictionary<string, msIMEI> MsImeiCollection
        {
            get
            {
                if (_MsImeiCollection == null)
                {
                    localdb = new DataClasses1DataContext(streamType.LocalConnString);
                    _MsImeiCollection = localdb.msIMEI.ToDictionary(e => e.fileNum + "-" + e.tlli);
                }
                return _MsImeiCollection;
            }
            set
            {
                _MsImeiCollection = value;
            }
        }
        private ILookup<string, imeiType> imeiL;
        public imeiTypeClass(bool init)
        {
            localdb.CommandTimeout = 0;
            if (init == true)
                imeiL = localdb.imeiType.Where(e => e.imei != null).ToLookup(e => e.imei);
        }

        public IEnumerable<msIMEI> AuditMsImeiCollection(int filenum)
        {
            string imeitac = null;
            var m = GetMsImeiCollection(filenum);
            foreach (var a in m)
            {
                if (a.imei != null)
                {
                    if (a.imei.Length > 8)
                    {
                        imeitac = a.imei.Substring(0, 8);
                        a.imeitype = imeiL[imeitac].Where(e => e.imeiModel != null && e.imeiModel != "未知")
                        .Select(e => e.imeiModel).FirstOrDefault()
                        == null ? "未知" : imeiL[imeitac].Where(e => e.imeiModel != null && e.imeiModel != "未知")
                        .Select(e => e.imeiModel).FirstOrDefault();
                        a.imeiclass = imeiL[imeitac].Where(e => e.imeiFactory != null && e.imeiFactory != "未知")
                            .Select(e => e.imeiFactory).FirstOrDefault()
                        == null ? "未知" : imeiL[imeitac].Where(e => e.imeiFactory != null && e.imeiFactory != "未知")
                        .Select(e => e.imeiFactory).FirstOrDefault();
                    }
                }
                yield return a;
            }
        }

        private IEnumerable<msIMEI> GetMsImeiCollection(int filenum)
        {
            localdb = new DataClasses1DataContext(streamType.LocalConnString);
            localdb.CommandTimeout = 0;

            var stream = localdb.IP_stream
                .Where(p => p.FileNum == filenum)
                .Select(p => new { p.FileNum, p.tlli, p.imsi, p.imei });
            var tlliL = stream.ToLookup(e => e.FileNum + "-" + e.tlli);
            foreach (var t in tlliL)
            {
                msIMEI a = new msIMEI();
                a.fileNum = t.Select(e => e.FileNum).FirstOrDefault();
                a.tlli = t.Select(e => e.tlli).FirstOrDefault();
                a.imsi = t.Where(e => e.imsi != null).Select(e => e.imsi).FirstOrDefault();
                a.imei = t.Where(e => e.imei != null).Select(e => e.imei).FirstOrDefault();
                yield return a;
            }
        }
        public IEnumerable<msIMEI> UpdateMsImeiCollection()
        {
            localdb = new DataClasses1DataContext(streamType.LocalConnString);
            localdb.CommandTimeout = 0;

            var stream = localdb.msIMEI;
            var imsiL = stream.Where(e => e.imsi != null).ToLookup(e => e.imsi);
            var tlliL = stream.ToLookup(e => e.fileNum + "-" + e.tlli);
            foreach (var t in tlliL)
            {
                msIMEI a = new msIMEI();
                a.fileNum = t.Select(e => e.fileNum).FirstOrDefault();
                a.tlli = t.Select(e => e.tlli).FirstOrDefault();
                a.imsi = t.Where(e => e.imsi != null).Select(e => e.imsi).FirstOrDefault();
                a.imei = t.Where(e => e.imei != null).Select(e => e.imei).FirstOrDefault();
                a.imeitype = t.Where(e => e.imei != null).Select(e => e.imeitype).FirstOrDefault();
                a.imeiclass = t.Where(e => e.imei != null).Select(e => e.imeiclass).FirstOrDefault();
                if (a.imei == null)
                {
                    var tlli = imsiL[a.imsi].Where(e => e.imei != null);
                    if (tlli != null)
                    {
                        a.imei = tlli.Select(e => e.imei).FirstOrDefault();
                        a.imeitype = tlli.Select(e => e.imeitype).FirstOrDefault();
                        a.imeiclass = tlli.Select(e => e.imeiclass).FirstOrDefault();
                    }
                }
                yield return a;
            }
        }

        public void InsertImeiType(imeiTypeClass _imeiTypeClass, int filenum)
        {
            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            using (SqlConnection con = new SqlConnection(streamType.LocalConnString))
            {
                con.Open();
                using (SqlTransaction tran = con.BeginTransaction())
                {
                    var newOrders = _imeiTypeClass.AuditMsImeiCollection(filenum);
                    SqlBulkCopy bc = new SqlBulkCopy(con,
                      SqlBulkCopyOptions.CheckConstraints |
                      SqlBulkCopyOptions.FireTriggers |
                      SqlBulkCopyOptions.KeepNulls, tran);
                    bc.BulkCopyTimeout = 36000;
                    bc.BatchSize = 1000;
                    bc.DestinationTableName = "msIMEI";
                    bc.WriteToServer(newOrders.AsDataReader());
                    tran.Commit();
                }
                con.Close();
            }
            GC.Collect(); GC.Collect();
            //sw.Stop();
            //MessageBox.Show(filenum.ToString() + "---" + sw.Elapsed.TotalSeconds.ToString() + "---");
            //MessageBox.Show(sw.Elapsed.TotalSeconds.ToString());
        }
        public void UpdateImeiType()
        {
            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            int maxUser = 0;
            using (DataClasses1DataContext mess = new DataClasses1DataContext(streamType.LocalConnString))
                maxUser = mess.msIMEI.Count();
            //MessageBox.Show(maxUser.ToString());
            using (SqlConnection con = new SqlConnection(streamType.LocalConnString))
            {
                con.Open();
                using (SqlTransaction tran = con.BeginTransaction())
                {
                    imeiTypeClass _imeiTypeClass = new imeiTypeClass(false);
                    var newOrders = _imeiTypeClass.UpdateMsImeiCollection();
                    SqlBulkCopy bc = new SqlBulkCopy(con,
                      SqlBulkCopyOptions.CheckConstraints |
                      SqlBulkCopyOptions.FireTriggers |
                      SqlBulkCopyOptions.KeepNulls, tran);
                    bc.BulkCopyTimeout = 36000;
                    bc.BatchSize = 1000;
                    bc.DestinationTableName = "msIMEI";
                    bc.WriteToServer(newOrders.AsDataReader());
                    tran.Commit();
                }
                con.Close();
            }
            using (DataClasses1DataContext mess = new DataClasses1DataContext(streamType.LocalConnString))
                mess.ExecuteCommand("delete from msIMEI where msIMEI_id<=" + maxUser);
            GC.Collect(); GC.Collect();
            //sw.Stop();
            //MessageBox.Show(sw.Elapsed.TotalSeconds.ToString());
        }
    }
}
