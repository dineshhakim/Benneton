using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataLogic;
using Domain;

namespace BusinessLogic
{
   public class BL_Stock_In
    {
       public static string InsUpdDelStockIn(char Event, OrderedItemClass obj, ProductStockIn obj1, out int id)
       {
           id = 0;
           return DlStockIn.InsUpdDelStockIn(Event, obj,obj1, out id);
       }
       public static DataTable GetStockInDetail(int Event, int id, string code, string code1)
       {
           var dt = DlStockIn.GetStockInDetail(Event, id, code, code1);
           return dt;
       }
    }
}
