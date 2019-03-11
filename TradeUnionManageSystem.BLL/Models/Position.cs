using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeUnionManageSystem.BLL.Models
{
    public class Position
    {
        [Key]
        public int ID { get; set; }

        [Display(Name="岗位名称")]
        public string PositionName { get; set; }
    }
}
