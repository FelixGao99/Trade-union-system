﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TradeUnionManageSystem.UI.Models.DisplayModel
{
    /// <summary>
    /// 提案展示类
    /// </summary>
    public class ProposalDisplayModel
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "提案类型")]
        public string ProposalType { get; set; }

        [Display(Name = "提案人")]
        public string ProposalEmployeeID { get; set; }

        [Display(Name = "提案提交日期")]
        public DateTime ProposalDate { get; set; }

        [Display(Name = "提案简介")]
        public string ProposalDescription { get; set; }

        [Display(Name = "提案处理情况")]
        public string ProposalDealStatus { get; set; }
    }
}