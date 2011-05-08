using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Data.Linq;
using System.Diagnostics;
using System.Data.SqlClient;

namespace IP_stream
{
    class handleTable
    {
        public handleTable()
        {

        }
        public string AlterPrimaryKey()
        {
            using (DataClasses1DataContext mess = new DataClasses1DataContext(streamType.LocalConnString))
            {
                try
                {
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    mess.CommandTimeout = 0;//sql连接超时的问题
                    mess.ExecuteCommand("alter table IP_stream alter column FileNum int not null");
                    mess.ExecuteCommand("alter table IP_stream alter column PacketNum int not null");
                    mess.ExecuteCommand("alter table IP_stream add constraint sid_pk primary key(FileNum,PacketNum)");
                    sw.Stop();
                    MessageBox.Show(sw.Elapsed.TotalSeconds.ToString());
                    return mess.Connection.ConnectionString;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return mess.Connection.ConnectionString;
                }
                finally
                {
                    mess.Dispose();
                }
            }
        }
        public string InitImeiCiTypeTable()
        {
            DialogResult result; //Messagebox所属于的类
            result = MessageBox.Show("YesOrNo", "你确定要执行查询吗？",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)//Messagebox返回的值
            {
                CreateImeiCiTypeTable();
                using (DataClasses1DataContext mess = new DataClasses1DataContext(streamType.LocalConnString))
                {
                    mess.ExecuteCommand("delete from ciBVCI");
                    mess.ExecuteCommand("delete from msIMEI");
                }
                GC.Collect();
                //MessageBox.Show("OK");
            }
            return streamType.LocalConnString;
        }

        public string InitMlocationTable()
        {
            using (DataClasses1DataContext mess = new DataClasses1DataContext(streamType.LocalConnString))//此处关键，数据插入到何处
            {
                //mess.CommandTimeout = 6000;//sql连接超时的问题
                DialogResult result; //Messagebox所属于的类
                result = MessageBox.Show( "YesOrNo", "你确定要执行查询吗？",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)//Messagebox返回的值
                {
                    var typeName = "System.Data.Linq.SqlClient.SqlBuilder";
                    var type = typeof(DataContext).Assembly.GetType(typeName);
                    var bf = BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.InvokeMethod;
                    var metaTable = mess.Mapping.GetTable(typeof(mLocatingType));
                    var sql = type.InvokeMember("GetCreateTableCommand", bf, null, null, new[] { metaTable });
                    //MessageBox.Show(sql.ToString ());
                    string delSql = @"if exists (select 1 from  sysobjects where  id = object_id('dbo.mLocatingType') and   type = 'U')
                            drop table dbo.mLocatingType";
                    mess.ExecuteCommand(delSql.ToString());
                    mess.ExecuteCommand(sql.ToString());

                    //mess.ExecuteCommand("delete  from mLocatingType");
                    //MessageBox.Show("OK");
                }
                //return mess.Connection.ConnectionString;
            }
            GC.Collect();
            //MessageBox.Show("OK");
            return streamType.LocalConnString;
        }

        private void CreateImeiCiTypeTable()
        {

            using (DataClasses1DataContext mess = new DataClasses1DataContext(streamType.LocalConnString))
            {
                var typeName = "System.Data.Linq.SqlClient.SqlBuilder";
                var type = typeof(DataContext).Assembly.GetType(typeName);
                var bf = BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.InvokeMethod;

                #region 初始化《mlocating》
                /*
                var metaTable = mess.Mapping.GetTable(typeof(mLocatingType));
                var sql = type.InvokeMember("GetCreateTableCommand", bf, null, null, new[] { metaTable });
                //MessageBox.Show(sql.ToString ());
                string delSql = @"if exists (select 1 from  sysobjects where  id = object_id('dbo.mLocatingType') and   type = 'U')
                            drop table dbo.mLocatingType";
                mess.ExecuteCommand(delSql.ToString());
                mess.ExecuteCommand(sql.ToString());
                 * */
                #endregion


                #region  初始化《imei库》和《ci覆盖类型库》的时候 执行
                /*
                metaTable = mess.Mapping.GetTable(typeof(ciCoverType));
                sql = type.InvokeMember("GetCreateTableCommand", bf, null, null, new[] { metaTable });
                delSql = @"if exists (select 1 from  sysobjects where  id = object_id('dbo.ciCoverType') and   type = 'U')
                                            drop table dbo.ciCoverType";
                mess.ExecuteCommand(delSql.ToString());
                mess.ExecuteCommand(sql.ToString());

                metaTable = mess.Mapping.GetTable(typeof(imeiType));
                sql = type.InvokeMember("GetCreateTableCommand", bf, null, null, new[] { metaTable });
                delSql = @"if exists (select 1 from  sysobjects where  id = object_id('dbo.imeiType') and   type = 'U')
                                            drop table dbo.imeiType";
                mess.ExecuteCommand(delSql.ToString());
                mess.ExecuteCommand(sql.ToString());
                 * */
                #endregion

                var metaTable = mess.Mapping.GetTable(typeof(msIMEI));
                var sql = type.InvokeMember("GetCreateTableCommand", bf, null, null, new[] { metaTable });
                string delSql = @"if exists (select 1 from  sysobjects where  id = object_id('dbo.msIMEI') and   type = 'U')
                            drop table dbo.msIMEI";
                mess.ExecuteCommand(delSql.ToString());
                mess.ExecuteCommand(sql.ToString());

                metaTable = mess.Mapping.GetTable(typeof(ciBVCI));
                sql = type.InvokeMember("GetCreateTableCommand", bf, null, null, new[] { metaTable });
                delSql = @"if exists (select 1 from  sysobjects where  id = object_id('dbo.ciBVCI') and   type = 'U')
                            drop table dbo.ciBVCI";
                mess.ExecuteCommand(delSql.ToString());
                mess.ExecuteCommand(sql.ToString());

                //MessageBox.Show("OK");

            }

        }
    }
}
