using System;
using System.Windows.Forms;
using System.Reflection;
using System.Data.Linq;
using System.Diagnostics;
using IP_stream.Linq;

namespace IP_stream
{
    class handleTable
    {
        private DataClasses1DataContext localdb = new DataClasses1DataContext(streamType.LocalConnString);
        public handleTable()
        {
        }
        public string AlterPrimaryKey()
        {
            //try
            //{
            localdb = new DataClasses1DataContext(streamType.LocalConnString);
            localdb.CommandTimeout = 0;//sql连接超时的问题
            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            string sqlstr = @"if exists(select 1 from sysobjects where parent_obj=object_id('tb') and xtype='PK')
                                  begin
                                    alter table IP_stream alter column FileNum int not null
                                    alter table IP_stream alter column PacketNum int not null
                                    alter table IP_stream add constraint sid_pk primary key(FileNum,PacketNum)
                                  end";

            localdb.ExecuteCommand(sqlstr);
            CreateTable(typeof(msIMEI));
            CreateTable(typeof(ciBVCI));
            CreateTable(typeof(mLocatingType));

            //sw.Stop();
            //MessageBox.Show(sw.Elapsed.TotalSeconds.ToString());
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
            //finally
            //{
            //    localdb.Dispose();
            //}
            return localdb.Connection.ConnectionString;
        }
        //public string InitImeiCiTypeTable()
//        {
//            //DialogResult result; //Messagebox所属于的类
//            //result = MessageBox.Show("YesOrNo", "你确定要执行查询吗？",
//            //    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
//            //if (result == DialogResult.Yes)//Messagebox返回的值
//            //{
//                //CreateImeiCiTypeTable();
//                //localdb = new DataClasses1DataContext(streamType.LocalConnString);
//                ////using (DataClasses1DataContext mess = new DataClasses1DataContext(streamType.LocalConnString))
//                ////{
//                //localdb.ExecuteCommand("delete from ciBVCI");
//                //localdb.ExecuteCommand("delete from msIMEI");
//                //}
//                //GC.Collect();
//                //MessageBox.Show("OK");

//                CreateTable(typeof(msIMEI));
//                CreateTable(typeof(ciBVCI));

//            //}
//            return streamType.LocalConnString;
//        }

//        //public string InitMlocationTable()
//        {
//            CreateTable(typeof(mLocatingType));
//            //localdb = new DataClasses1DataContext(streamType.LocalConnString);
//            //using (DataClasses1DataContext mess = new DataClasses1DataContext(streamType.LocalConnString))//此处关键，数据插入到何处
//            //{
//            //mess.CommandTimeout = 6000;//sql连接超时的问题
////            DialogResult result; //Messagebox所属于的类
////            result = MessageBox.Show("YesOrNo", "你确定要执行查询吗？",
////                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
////            if (result == DialogResult.Yes)//Messagebox返回的值
////            {
////                CreateTable(typeof(mLocatingType));
//////                var typeName = "System.Data.Linq.SqlClient.SqlBuilder";
//////                var type = typeof(DataContext).Assembly.GetType(typeName);
//////                var bf = BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.InvokeMethod;
//////                var metaTable = localdb.Mapping.GetTable(typeof(mLocatingType));
//////                var sql = type.InvokeMember("GetCreateTableCommand", bf, null, null, new[] { metaTable });
//////                //MessageBox.Show(sql.ToString ());
//////                string delSql = @"if exists (select 1 from  sysobjects where  id = object_id('dbo.mLocatingType') and   type = 'U')
//////                            drop table dbo.mLocatingType";
//////                localdb.ExecuteCommand(delSql.ToString());
//////                localdb.ExecuteCommand(sql.ToString());

////                //mess.ExecuteCommand("delete  from mLocatingType");
////                //MessageBox.Show("OK");
////            }
//            //return mess.Connection.ConnectionString;
//            //}
//            //GC.Collect();
//            //MessageBox.Show("OK");
//            return streamType.LocalConnString;
//        }

//        private void CreateImeiCiTypeTable()
//        {
//            localdb = new DataClasses1DataContext(streamType.LocalConnString);

//            //using (DataClasses1DataContext mess = new DataClasses1DataContext(streamType.LocalConnString))
//            //{
//            var typeName = "System.Data.Linq.SqlClient.SqlBuilder";
//            var type = typeof(DataContext).Assembly.GetType(typeName);
//            var bf = BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.InvokeMethod;

//            #region 初始化《mlocating》
//            /*
//                var metaTable = mess.Mapping.GetTable(typeof(mLocatingType));
//                var sql = type.InvokeMember("GetCreateTableCommand", bf, null, null, new[] { metaTable });
//                //MessageBox.Show(sql.ToString ());
//                string delSql = @"if exists (select 1 from  sysobjects where  id = object_id('dbo.mLocatingType') and   type = 'U')
//                            drop table dbo.mLocatingType";
//                mess.ExecuteCommand(delSql.ToString());
//                mess.ExecuteCommand(sql.ToString());
//                 * */
//            #endregion


//            #region  初始化《imei库》和《ci覆盖类型库》的时候 执行
//            /*
//                metaTable = mess.Mapping.GetTable(typeof(ciCoverType));
//                sql = type.InvokeMember("GetCreateTableCommand", bf, null, null, new[] { metaTable });
//                delSql = @"if exists (select 1 from  sysobjects where  id = object_id('dbo.ciCoverType') and   type = 'U')
//                                            drop table dbo.ciCoverType";
//                mess.ExecuteCommand(delSql.ToString());
//                mess.ExecuteCommand(sql.ToString());

//                metaTable = mess.Mapping.GetTable(typeof(imeiType));
//                sql = type.InvokeMember("GetCreateTableCommand", bf, null, null, new[] { metaTable });
//                delSql = @"if exists (select 1 from  sysobjects where  id = object_id('dbo.imeiType') and   type = 'U')
//                                            drop table dbo.imeiType";
//                mess.ExecuteCommand(delSql.ToString());
//                mess.ExecuteCommand(sql.ToString());
//                 * */
//            #endregion

//            var metaTable = localdb.Mapping.GetTable(typeof(msIMEI));
//            var sql = type.InvokeMember("GetCreateTableCommand", bf, null, null, new[] { metaTable });
//            string delSql = @"if exists (select 1 from  sysobjects where  id = object_id('dbo.msIMEI') and   type = 'U')
//                            drop table dbo.msIMEI";
//            localdb.ExecuteCommand(delSql.ToString());
//            localdb.ExecuteCommand(sql.ToString());

//            metaTable = localdb.Mapping.GetTable(typeof(ciBVCI));
//            sql = type.InvokeMember("GetCreateTableCommand", bf, null, null, new[] { metaTable });
//            delSql = @"if exists (select 1 from  sysobjects where  id = object_id('dbo.ciBVCI') and   type = 'U')
//                            drop table dbo.ciBVCI";
//            localdb.ExecuteCommand(delSql.ToString());
//            localdb.ExecuteCommand(sql.ToString());

//            //MessageBox.Show("OK");
//        }
       public static  bool  CreateTable(Type linqTableClass)
        {
            bool suc = true;
            string createtable = linqTableClass.Name;
            //MessageBox.Show(createtable);
            //混淆以后反射名称被改变出现问题
            using (DataClasses1DataContext localdb = new DataClasses1DataContext(streamType.LocalConnString))
            {
                try
                {
                    var metaTable = localdb.Mapping.GetTable(linqTableClass);
                    var typeName = "System.Data.Linq.SqlClient.SqlBuilder";
                    var type = typeof(DataContext).Assembly.GetType(typeName);
                    var bf = BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.InvokeMethod;
                    var sql = type.InvokeMember("GetCreateTableCommand", bf, null, null, new[] { metaTable });
                    string delSql = @"if exists (select 1 from  sysobjects where  id = object_id('dbo." + createtable + @"') and   type = 'U')
                            drop table dbo." + createtable;
                    localdb.ExecuteCommand(delSql.ToString());
                    localdb.ExecuteCommand(sql.ToString());
                }
                catch (Exception ex)
                {
                    suc = false;
                    MessageBox.Show(ex.ToString());
                }
            }
            return suc;
        }
    }
}
