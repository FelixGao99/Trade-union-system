using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeUnionManageSystem.BLL.Models
{
    /// <summary>
    /// 团体
    /// </summary>
    public class EmployeeGroup
    {
        [Key]
        public int ID { get; set; }

        [Display(Name="团体名称")]
        public string Name { get; set; }

        [Display(Name = "是否启用")]
        public bool Enabled { get; set; }
    }
}
