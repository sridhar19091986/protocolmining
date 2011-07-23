using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using System.Collections;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using MathWorks.MATLAB.NET.Arrays;
using PdchNew;
using System.Windows.Forms;

namespace WinApp
{
    class PdchModel
    {
        public string LacCi { get; set; }
        public double PsPagingTime { get; set; }
        public double PdchUse { get; set; }
        public double IMr { get; set; }
        public double GDr { get; set; }
        public double BCr { get; set; }
        public double MMSr { get; set; }
        public double OCr { get; set; }
        public double PdchSim { get; set; }
        public int PdchPlan { get; set; }
        public static void ListExportExel(List<PdchModel> outputRows)
        {
            object oOpt = System.Reflection.Missing.Value; //for optional arguments
            Excel.Application oXL = new Excel.Application();
            Excel.Workbooks oWBs = oXL.Workbooks;
            Excel.Workbook oWB = oWBs.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet oSheet = (Excel.Worksheet)oWB.ActiveSheet;

            //outputRows is a List<List<object>>
            int numberOfRows = outputRows.Count;
            int numberOfColumns = 4;

            Excel.Range oRng = oSheet.get_Range("A2", oOpt).get_Resize(numberOfRows, numberOfColumns);

            object[,] outputArray = new object[numberOfRows, numberOfColumns];
            for (int row = 0; row < numberOfRows; row++)
            {
                outputArray[row, 0] = outputRows[row].LacCi;
                outputArray[row, 1] = outputRows[row].PdchUse;
                outputArray[row, 2] = outputRows[row].PdchSim;
                outputArray[row, 3] = outputRows[row].PdchPlan;
            }

            oRng.set_Value(oOpt, outputArray);

            Excel.Range nRng = oSheet.get_Range("A1", oOpt).get_Resize(1, numberOfColumns);
            nRng.set_Value(oOpt, new string[] { "LacCi", "PdchUse", "PdchSim", "PdchPlan" });
            oXL.Visible = true;
        }
        public static List<PdchModel> PdchSimulink(List<PdchModel> input)
        {
            List<PdchModel> pm = new List<PdchModel>();
            pm = input.OrderBy(e => e.PsPagingTime).ToList();
            PdchNewclass pnc = new PdchNewclass();
            int size = input.Count();
            double[,] X = new double[size, 5];
            double[,] Y = new double[size, 1];

            for (int i = 0; i < size; i++)
            {
                X[i, 0] = pm[i].BCr;
                X[i, 1] = pm[i].GDr;
                X[i, 2] = pm[i].IMr;
                X[i, 3] = pm[i].MMSr;
                X[i, 4] = pm[i].OCr;
                Y[i, 0] = pm[i].PdchUse;
            }
            MWNumericArray mtraffic = new MWNumericArray(X);
            MWNumericArray mpdchuse = new MWNumericArray(Y);

            MWArray mpdchnew = pnc.pdchsim(mtraffic, mpdchuse);
            MWNumericArray mx_y1 = (MWNumericArray)mpdchnew;
            double[,] csArray = (double[,])mx_y1.ToArray(MWArrayComponent.Real);
            for (int i = 0; i < csArray.Length; i++)
                pm[i].PdchSim = csArray[i, 0];
            return pm;
        }
    }
}
