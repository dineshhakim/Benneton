using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class SeasonClass
    {
        public int Id { get; set; }
        public string Season { get; set; }

        public SeasonClass (int id,string season)
        {
            Id = id;
            Season = season;
        }


    }
}
