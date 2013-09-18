using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace RockstarSeating.Utils
{
    public class CSVExporter
    {

        private static StringBuilder sb = new StringBuilder();

        public CSVExporter(List<List<string>> exportList, string[] colHdrs)
        {
            WriteToCSV(exportList, colHdrs);
        }




        public static void WriteToCSV(List<List<string>> exportList, string[] colHdrs)
        {
            string attachment = "attachment; filename=PersonList.csv";

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.AddHeader("content-disposition", attachment);
            HttpContext.Current.Response.ContentType = "text/csv";
            HttpContext.Current.Response.AddHeader("Pragma", "public");

            WriteColumnNames(colHdrs);

            foreach (List<string> exportItem in exportList)
            {
                foreach (string exportItemFld in exportItem)
                {
                    WriteField(exportItemFld);
                }

                HttpContext.Current.Response.Write(Environment.NewLine);
            }


            HttpContext.Current.Response.End();
        }

        private static void WriteField(string exportItem)
        {

            HttpContext.Current.Response.Write(AddComma(exportItem));
        }

        private static string AddComma(string value)
        {
            value = value + ",";
            return value;
        }



        private static void WriteColumnNames(string[] colNames)
        {

            string columnNames = string.Join("", colNames);
            HttpContext.Current.Response.Write(columnNames);
            HttpContext.Current.Response.Write(Environment.NewLine);
        }
    }
}