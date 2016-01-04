using System;
using System.Data;
using DataLogic;
using Domain;

namespace BusinessLogic
{
    public class BlLa
    {
        public static string GetLA_CODE(int v1, int v2, string value)
        {
            return DlLa.GetLa_CODE(v1, v2, value);
        }

        public static DataTable GetLa(int v1, int v2, string v3)
        {
            return DlLa.GetLa(v1, v2, v3);
        }

        public string InsUpdDelLa(PL_LA obj ,out  int Id)
        {
            return DlLa.InsUpdDelLA(obj , out Id);
        }
    }
}