using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class Title
    {
        public int TitleId { get; set; }
        public string TitleName { get; set; }

        public Title(int titleId,string titleName)
        {
            TitleId = titleId;
            TitleName = titleName;
        }
    }
}
