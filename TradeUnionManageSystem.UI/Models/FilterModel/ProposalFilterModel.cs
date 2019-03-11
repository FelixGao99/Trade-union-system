using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TradeUnionManageSystem.UI.Models.FilterModel
{
    public class ProposalFilterModel
    {
        public string ProposalType { get; set; }

        public string ProposalEmployee { get; set; }

        public DateTime ProposalSubmitDateMin { get; set; }

        public DateTime ProposalSubmitDateMax { get; set; }
    }
}