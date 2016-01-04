using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataLogic;
using Domain;

namespace BusinessLogic
{
    public class BllImportExcel
    {
        public static string InsUpdDelExcelImport(char Event, ImportExcel obj, out int id)
        {
            id = 0;
            return DllImportExcel.InsUpdDelExcelImport(Event, obj, out id);
        }

        public static DataTable GetImportList(int Event, int id, string code, string code1)
        {
            return DllImportExcel.GetImportList(Event, id, code, code1);
        }
        public static DataTable GetImportListByDate(int Event, int id, string code, string code1,DateTime date)
        {
            return DllImportExcel.GetImportListByDate(Event, id, code, code1,date);
        }
    }
}
