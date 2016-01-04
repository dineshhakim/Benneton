using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
   public class PL_IncomeExp
    {
        public PL_IncomeExp()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private int _IE_ID = 0; public int IE_ID { get { return _IE_ID; } set { _IE_ID = value; } }
        private string _IE_Code = string.Empty; public string IE_Code { get { return _IE_Code; } set { _IE_Code = value; } }
        private string _IE = string.Empty; public string IE { get { return _IE; } set { _IE = value; } }
        private int _IE_ParentID = 0; public int IE_ParentID { get { return _IE_ParentID; } set { _IE_ParentID = value; } }
        private bool _IE_Primary = false; public bool IE_Primary { get { return _IE_Primary; } set { _IE_Primary = value; } }
        private string _Ie_Child = string.Empty; public string Ie_Child { get { return _Ie_Child; } set { _Ie_Child = value; } }
        private bool _IsNeeded = false; public bool IsNeeded { get { return _IsNeeded; } set { _IsNeeded = value; } }

        private int _p_headerid = 0; public int p_headerid { get { return _p_headerid; } set { _p_headerid = value; } }
        public char EVENT;

    }
}
