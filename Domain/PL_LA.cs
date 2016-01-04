using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
   public class PL_LA
    {
        private int _LA_ID = 0; public int LA_ID { get { return _LA_ID; } set { _LA_ID = value; } }
        private string _LA_Code = string.Empty; public string LA_Code { get { return _LA_Code; } set { _LA_Code = value; } }
        private string _LA = string.Empty; public string LA { get { return _LA; } set { _LA = value; } }
        private int _LA_ParentID = 0; public int LA_ParentID { get { return _LA_ParentID; } set { _LA_ParentID = value; } }
        private bool _LA_Primary = false; public bool LA_Primary { get { return _LA_Primary; } set { _LA_Primary = value; } }
        private string _LA_Child = string.Empty; public string LA_Child { get { return _LA_Child; } set { _LA_Child = value; } }
        private bool _IsNeeded = false; public bool IsNeeded { get { return _IsNeeded; } set { _IsNeeded = value; } }

        private int _p_headerid = 0; public int p_headerid { get { return _p_headerid; } set { _p_headerid = value; } }
        public char EVENT;
    }
}
