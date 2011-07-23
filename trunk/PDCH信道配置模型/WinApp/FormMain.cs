using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinApp
{
    public partial class FormMain : DevComponents.DotNetBar.Office2007Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                List<PdchModel> pdchmodelN = new List<PdchModel>();
                pdchmodelN = PdchModel.PdchSimulink(pdchmodel);
                foreach (var p in pdchmodelN)
                    p.PdchPlan = (int)Math.Floor(p.PdchSim) + subsense;
                PdchModel.ListExportExel(pdchmodelN);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            /*
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "选择保存结果路径..";
            sfd.Filter = "Excel (*.xlsx)|*.xlsx|(*.xls)|*.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {

                
            }
             * */
        }

        private void SelectFile(TextBox obj)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel (*.xlsx)|*.xlsx|(*.xls)|*.xls";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                obj.Text = ofd.FileName;
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }
        ExcelHelper excelhelper = new ExcelHelper();
        List<PdchModel> pdchmodel = new List<PdchModel>();
        private void btnOption1_Click(object sender, EventArgs e)
        {
            try
            {
                SelectFile(txtPath1);
                if (txtPath1.Text.Length < 2) return;
                DataSet stream = new DataSet();
                stream = excelhelper.ReadExcel(txtPath1.Text);
                for (int i = 0; i < stream.Tables[0].Rows.Count; i++)
                {
                    PdchModel pm = new PdchModel();
                    pm.LacCi = stream.Tables[0].Rows[i][0].ToString();
                    pm.IMr = double.Parse(stream.Tables[0].Rows[i][1].ToString());
                    pm.GDr = double.Parse(stream.Tables[0].Rows[i][2].ToString());
                    pm.BCr = double.Parse(stream.Tables[0].Rows[i][3].ToString());
                    pm.MMSr = double.Parse(stream.Tables[0].Rows[i][4].ToString());
                    pm.OCr = double.Parse(stream.Tables[0].Rows[i][5].ToString());
                    pdchmodel.Add(pm);
                }
                MessageBox.Show(stream.Tables[0].Rows.Count.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnOption2_Click(object sender, EventArgs ee)
        {
            try
            {
                SelectFile(txtPath2);
                if (txtPath2.Text.Length < 2) return;
                DataSet paging = new DataSet();
                paging = excelhelper.ReadExcel(txtPath2.Text);
                for (int i = 0; i < paging.Tables[0].Rows.Count; i++)
                {
                    foreach (var p in pdchmodel)
                        if (p.LacCi == paging.Tables[0].Rows[i][0].ToString())
                            p.PsPagingTime = double.Parse(paging.Tables[0].Rows[i][1].ToString());
                }
                MessageBox.Show(paging.Tables[0].Rows.Count.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnOption3_Click(object sender, EventArgs e)
        {
            try
            {
                SelectFile(txtPath3);
                if (txtPath3.Text.Length < 2) return;
                DataSet pdch = new DataSet();
                pdch = excelhelper.ReadExcel(txtPath3.Text);
                for (int i = 0; i < pdch.Tables[0].Rows.Count; i++)
                {
                    foreach (var p in pdchmodel)
                        if (p.LacCi == pdch.Tables[0].Rows[i][0].ToString())
                            p.PdchUse = double.Parse(pdch.Tables[0].Rows[i][1].ToString());
                }
                MessageBox.Show(pdch.Tables[0].Rows.Count.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private int subsense = 1;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem.ToString())
            {
                case "一般":
                    subsense = 1;
                    break;
                case "较好":
                    subsense = 2;
                    break;
                case "良好":
                    subsense = 3;
                    break;
                default:
                    subsense = 1;
                    break;
            }
            MessageBox.Show(comboBox1.SelectedItem.ToString());
        }
    }
}