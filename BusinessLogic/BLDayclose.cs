using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLogic;
using Domain;

namespace BusinessLogic
{
   public class BLDayclose
    {

       public static string InsUpdDelDayclose(char Event, DayClose obj, out int id)
       {
           id = 0;
           return DLDayClose.InsUpdDelDayCloselog(Event, obj, out id);
       }
       public static void InsertDayOpen(int id,DateTime date,int userid)
       {
         
            DLDayClose.InsertDayOpen(id,date,userid);
       }
       public static string GetOperationDate(int branchid)
       {

          return DLDayClose.GetOperationDate(branchid);
       }
    }
}
