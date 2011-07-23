using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Xml;
using System.Xml.Xsl;

namespace WinApp
{
    public partial class ExcelHelper
    {
        #region ExcelHelper

        #region 读取Excel
        public System.Data.DataSet ReadExcel(string path)
        {
            System.Data.DataSet ds = new System.Data.DataSet();
            string extension = System.IO.Path.GetExtension(path.ToLower());
            string connString = string.Empty;
            if (extension == ".xls")
            {
                connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
            }
            else if (extension == ".xlsx")
            {
                connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
            }
            string query = "SELECT * FROM [Sheet1$]";
            try
            {
                OleDbConnection conn = new OleDbConnection();
                OleDbCommand cmd = new OleDbCommand();
                OleDbDataAdapter da = new OleDbDataAdapter();
                conn = new OleDbConnection(connString);
                //Open connection
                if (conn.State == ConnectionState.Closed) conn.Open();
                //Create the command object
                cmd = new OleDbCommand(query, conn);
                da = new OleDbDataAdapter(cmd);
                da.Fill(ds);
            }
            catch (Exception ex)
            { throw ex; }
            return ds;
        }
        #endregion

        #region 导出DataSet为Excel
        /// <summary>
        /// 导出DataSet为Excel
        /// </summary>
        /// <param name="DetailsTable"></param>
        /// <param name="FormatType"></param>
        /// <param name="FileName"></param>
        public void ExportWindowsExcel(DataSet AmeiSet, string fileName)
        {
            try
            {
                if (AmeiSet.Tables[0].Rows.Count == 0)
                    throw new Exception("没有数据可导出!");

                // Create Dataset
                AmeiSet.DataSetName = "Export";
                int maxcolumns = 0;
                foreach (System.Data.DataTable dt in AmeiSet.Tables)
                {
                    if (dt.Columns.Count > maxcolumns)
                        maxcolumns = dt.Columns.Count;
                }

                for (int i = 0; i < AmeiSet.Tables.Count; i++)
                {
                    DataTable dt = AmeiSet.Tables[i].Copy();
                    string[] sHeaders = new string[dt.Columns.Count];
                    string[] sFileds = new string[dt.Columns.Count];

                    dt.TableName = "Values";
                    // Getting Field Names
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        //sHeaders[i] = ReplaceSpclChars(dtExport.Columns[i].ColumnName);
                        sHeaders[j] = dt.Columns[j].ColumnName;
                        sFileds[j] = dt.Columns[j].ColumnName;
                    }
                    System.Data.DataSet dsexport = new System.Data.DataSet();
                    dsexport.Tables.Add(dt);
                    dsexport.DataSetName = "Export";
                    ExportWindowsExcel(dsexport, sHeaders, sFileds, fileName.Substring(0, fileName.LastIndexOf(".")) + i.ToString() + ".xls");
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion // ExportDetails OverLoad : Type#1

        #region 导出DataSet为Excel
        /// <summary>
        /// 导出为窗体Excel
        /// </summary>
        /// <param name="path"></param>
        /// <param name="sheetName"></param>
        private void ExportWindowsExcel(System.Data.DataSet dsExport, string[] sHeaders, string[] sFileds, string fileName)
        {
            try
            {
                // XSLT to use for transforming this dataset.      
                MemoryStream stream = new MemoryStream();
                XmlTextWriter writer = new XmlTextWriter(stream, Encoding.Unicode);

                CreateExcelStyleSheet(writer, sHeaders, sFileds);
                writer.Flush();
                stream.Seek(0, SeekOrigin.Begin);

                XmlDataDocument xmlDoc = new XmlDataDocument(dsExport);
                //XslTransform xslTran = new XslTransform();
                XslCompiledTransform xslTran = new XslCompiledTransform();
                xslTran.Load(new XmlTextReader(stream), null, null);

                System.IO.StringWriter sw = new System.IO.StringWriter();
                //xslTran.Transform(xmlDoc, null, sw, null);
                xslTran.Transform(xmlDoc, null, sw);

                //Writeout the Content         
                StreamWriter strwriter = new StreamWriter(fileName);
                strwriter.WriteLine(sw.ToString());
                strwriter.Close();

                sw.Close();
                writer.Close();
                stream.Close();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region CreateStylesheet
        /// <summary>
        /// 创建excel表单
        /// Creates XSLT file to apply on dataset's XML file
        /// </summary>
        /// <param name="writer">xmltextwriter</param>
        /// <param name="sHeaders">表头</param>
        /// <param name="sFileds">替换后的表头</param>
        private void CreateExcelStyleSheet(XmlTextWriter writer, string[] sHeaders, string[] sFileds)
        {
            try
            {
                ///<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
                ///<xsl:output method="text" version="4.0">
                ///</xsl;output>
                ///<xsl:template match="/">
                ///</xsl:template>
                ///</xsl:stylesheet>

                // xsl:stylesheet表头
                string ns = "http://www.w3.org/1999/XSL/Transform";
                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();
                writer.WriteStartElement("xsl", "stylesheet", ns);
                writer.WriteAttributeString("version", "1.0");
                writer.WriteStartElement("xsl:output");
                writer.WriteAttributeString("method", "text");
                writer.WriteAttributeString("version", "4.0");
                writer.WriteEndElement();

                // xsl-template
                writer.WriteStartElement("xsl:template");
                writer.WriteAttributeString("match", "/");

                // xsl:value-of for headers标题
                for (int j = 0; j < sHeaders.GetLength(0); j++)
                {
                    writer.WriteString("\"");
                    writer.WriteStartElement("xsl:value-of");
                    writer.WriteAttributeString("select", "'" + sHeaders[j] + "'");
                    writer.WriteEndElement(); // xsl:value-of
                    writer.WriteString("\"");
                    if (j != sFileds.Length - 1) writer.WriteString(" ");
                }

                // xsl:for-each迭代Datatable
                writer.WriteStartElement("xsl:for-each");
                writer.WriteAttributeString("select", "Export/Values");
                writer.WriteString("\r\n");

                // xsl:value-of for data fields数据域
                for (int j = 0; j < sFileds.GetLength(0); j++)
                {
                    writer.WriteString("\"");
                    writer.WriteStartElement("xsl:value-of");
                    writer.WriteAttributeString("select", sFileds[j]);
                    writer.WriteEndElement(); // xsl:value-of
                    writer.WriteString("\"");
                    if (j != sFileds.Length - 1) writer.WriteString(" ");
                }

                writer.WriteEndElement(); // xsl:for-each
                writer.WriteEndElement(); // xsl-template
                writer.WriteEndElement(); // xsl:stylesheet
                writer.WriteEndDocument();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #endregion
    }
}
