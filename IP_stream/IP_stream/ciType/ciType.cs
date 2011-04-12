using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;

namespace IP_stream
{
    class ciType
    {
        #region
        //远程取小区关系
        #endregion
        private DataClasses1DataContext remotedb = new DataClasses1DataContext(streamType.RemoteConnString);
        private Dictionary<string, ciBVCI> _CiTypeCollection;
        public Dictionary<string, ciBVCI> CiTypeCollection
        {
            get
            {
                if (_CiTypeCollection == null)
                {
                    remotedb = new DataClasses1DataContext(streamType.RemoteConnString);
                    _CiTypeCollection = remotedb.ciBVCI.ToDictionary(e => e.bvci);
                }
                return _CiTypeCollection;
            }
            set
            {
                _CiTypeCollection = value;
            }
        }
        private ILookup<string, ciCoverType> cicovertype;
        public ciType(bool init)
        {
            if (init == true)
                using (DataClasses1DataContext localdb = new DataClasses1DataContext(streamType.LocalConnString))
                    cicovertype = localdb.ciCoverType.Where(e => e.lacCI.IndexOf("-") != -1).ToLookup(e => e.lacCI);
        }
        public IEnumerable<ciBVCI> GetCiTypeCollection(int filenum)
        {
            var m = from p in remotedb.IP_stream
                    where p.FileNum == filenum
                    select new { p.FileNum, p.lac, p.ci, p.bvci };
            var n = m.Where(e => e.ci != null && e.bvci != null).ToLookup(ci => ci.lac + "-" + ci.ci);
            foreach (var ci in n)
            {
                ciBVCI a = new ciBVCI();
                a.fileNum = ci.Select(e => e.FileNum).FirstOrDefault();
                a.bvci = ci.Select(e => e.bvci).FirstOrDefault();
                a.lacCi = ci.Key;
                if (a.lacCi != null)
                {
                    if (cicovertype.Contains(a.lacCi))
                    {
                        a.ciCoverType = cicovertype[a.lacCi].Select(e => e.ciCoverModel).FirstOrDefault();
                        a.ciCoverClass = cicovertype[a.lacCi].Select(e => e.ciCoverClass).FirstOrDefault();
                    }
                }
                yield return a;
            }
        }

        public void InsertCiType(ciType _ciType, int filenum)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            using (SqlConnection con = new SqlConnection(streamType.RemoteConnString))
            {
                con.Open();
                using (SqlTransaction tran = con.BeginTransaction())
                {
                    var newOrders = _ciType.GetCiTypeCollection(filenum);
                    SqlBulkCopy bc = new SqlBulkCopy(con,
                      SqlBulkCopyOptions.CheckConstraints |
                      SqlBulkCopyOptions.FireTriggers |
                      SqlBulkCopyOptions.KeepNulls, tran);
                    bc.BatchSize = 1000;
                    bc.DestinationTableName = "ciBVCI";
                    bc.WriteToServer(newOrders.AsDataReader());
                    tran.Commit();
                }
                con.Close();
            }
            GC.Collect();
            sw.Stop();
            //MessageBox.Show(sw.Elapsed.TotalSeconds.ToString());
        }

    }
}