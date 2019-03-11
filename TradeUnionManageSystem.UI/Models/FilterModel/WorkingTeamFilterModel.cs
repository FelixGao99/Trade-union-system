using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TradeUnionManageSystem.UI.Models.FilterModel
{
    public class WorkingTeamFilterModel
    {
        public string WorkingUnit { get; set; }

        public string WorkingTeamName { get; set; }

        public int CarCountMin { get; set; }

        public int CarCountMax { get; set; }

        public int PeopleCountMin { get; set; }

        public int PeopleCountMax { get; set; }
    }
}