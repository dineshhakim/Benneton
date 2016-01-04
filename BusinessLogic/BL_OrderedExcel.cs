using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataLogic;
using Domain;

namespace BusinessLogic
{
  public class BL_OrderedExcel
    {
      public static string InsUpdDelExcelOrder(char Event, ImportExcel obj, out int id)
      {
          id = 0;
          return DlOrderedItem.InsUpdDelOrderedItem(Event, obj, out id);
      }
      public static DataTable GetOrderedList(int Event, int id, string code, string code1)
      {
          var dt = DlOrderedItem.GetOrderedList(Event, id, code, code1);
          return dt;
      }
      public static DataTable GetOrderedListByDate(int Event, int id, string code, string code1,DateTime date)
      {
          var dt = DlOrderedItem.GetOrderedListByDate(Event, id, code, code1, date);
          return dt;
      }
    }
}
