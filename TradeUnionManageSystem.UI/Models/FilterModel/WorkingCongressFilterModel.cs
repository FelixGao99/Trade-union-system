using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TradeUnionManageSystem.UI.Models.FilterModel
{
    public class WorkingCongressFilterModel
    {
        public string UnitName { get; set; }

        public DateTime CreateDateMin { get; set; }

        public DateTime CreateDateMax { get; set; }

        public int RepresentCountMin { get; set; }

        public int RepresentCountMax { get; set; }

        public int AttendanceCountMin { get; set; }

        public int AttendanceCountMax { get; set; }

        public int ProposalCountMin { get; set; }

        public int ProposalCountMax { get; set; }
    }
}