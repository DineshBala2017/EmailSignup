using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using excel = Microsoft.Office.Interop.Excel;
//namespace WhataburgerEmailSignup.Datatable
namespace Whataburger_Dotcom_EmailSignup.datatable
{
    public class Exceldata
    {
        public string Fname = null;
        public string Lname = null;
        public String email = null;
        public String cemail = null;
        public String month = null;
        public String year = null;
        public String date = null;
        //public double Zipcode=0;
        public String Zipcode = null;
        public int Count;
        public excel.Application excelapp;
        public excel.Workbook exworkbook;
        public excel.Range xlRange;
        public double rowCount;
        public double colCount;

        public void Openexcel(String Sheetname)
        {
            excelapp = new excel.Application();
            exworkbook = (excel.Workbook)(excelapp.Workbooks.Open(@"C:\Users\dbalaguru\Desktop\Datafile\EmailSignup.xlsx", Type.Missing, true, Type.Missing, Type.Missing, Type.Missing,
        true, Type.Missing, Type.Missing, false, Type.Missing,
        Type.Missing, Type.Missing, Type.Missing, Type.Missing));
            excel.Worksheet eworksheet = (excel.Worksheet)

            exworkbook.Worksheets[Sheetname];
            xlRange = eworksheet.UsedRange;
            excelapp.Visible = false;

            rowCount = xlRange.Rows.Count;
            colCount = xlRange.Columns.Count;
            // Count = rowCount;

            // for (int i = 2; i < rowCount; i++)
        }
            public void Readexcel(int i)
            {
            //{
            Fname = xlRange.Cells[i, "A"].value;
            Lname = xlRange.Cells[i, "B"].value;
            email = xlRange.Cells[i, "C"].value;
            cemail = xlRange.Cells[i, "D"].value;
            date = Convert.ToString(xlRange.Cells[i, "E"].value);
            month = Convert.ToString(xlRange.Cells[i, "F"].value);
            year = Convert.ToString(xlRange.Cells[i, "G"].value);


            //= DOB.ToShortDateString();
            Zipcode = Convert.ToString(xlRange.Cells[i, "H"].value);
            //  }
        }

            public void writedata(int i,String  ActualResult)
            {
            xlRange.Cells[i, "I"] = ActualResult;
            }
        public void savedata()
        {
            DateTime dateTime = DateTime.UtcNow.Date;
            var date = dateTime.ToString("dd-yy");
            String Output = @"C:\Users\dbalaguru\Desktop\Datafile";
            exworkbook.SaveAs(Output+date+".xlsx", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
        false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            exworkbook.Close();

        }

        }
    }



