using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeUnionManageSystem.BLL.Models;

namespace TradeUnionManageSystem.BLL
{
    public class MyDBInitializer : DropCreateDatabaseAlways<MyContext>
    {
        protected override void Seed(MyContext context)
        {
            base.Seed(context);

            #region 初始会员

            context.Employees.Add(new Employee { Name = "Member1", Gender = 0, Birthday = DateTime.Parse("2018-12-22") });
            context.Employees.Add(new Employee { Name = "Member2", Gender = 0, Birthday = DateTime.Parse("2018-12-22") });
            context.Employees.Add(new Employee { Name = "Member3", Gender = 0, Birthday = DateTime.Parse("2018-12-22") });
            context.Employees.Add(new Employee { Name = "Member4", Gender = 1, Birthday = DateTime.Parse("2018-12-24") });
            context.Employees.Add(new Employee { Name = "Member5", Gender = 1, Birthday = DateTime.Parse("2018-12-24") });
            context.Employees.Add(new Employee { Name = "Member6", Gender = 1, Birthday = DateTime.Parse("2018-12-24") });

            #endregion

            #region 初始荣誉

            context.Honors.Add(new Honor { HonorTarget = "个人", HonorName = "荣誉1", HonorLevel = 1, CreateTime = DateTime.Parse("2018-12-22"), EmployeeID = 1, EmployeeJobCode = 1, EmployeeUnitCode = 1, EmployeeGroupCode = 1 });
            context.Honors.Add(new Honor { HonorTarget = "个人", HonorName = "荣誉2", HonorLevel = 1, CreateTime = DateTime.Parse("2018-12-22"), EmployeeID = 1, EmployeeJobCode = 1, EmployeeUnitCode = 1, EmployeeGroupCode = 1 });
            context.Honors.Add(new Honor { HonorTarget = "单位", HonorName = "荣誉3", HonorLevel = 2, CreateTime = DateTime.Parse("2018-12-22"), EmployeeID = 2, EmployeeJobCode = 2, EmployeeUnitCode = 2, EmployeeGroupCode = 2 });
            context.Honors.Add(new Honor { HonorTarget = "单位", HonorName = "荣誉4", HonorLevel = 2, CreateTime = DateTime.Parse("2018-12-24"), EmployeeID = 2, EmployeeJobCode = 2, EmployeeUnitCode = 2, EmployeeGroupCode = 2 });
            context.Honors.Add(new Honor { HonorTarget = "团队", HonorName = "荣誉5", HonorLevel = 3, CreateTime = DateTime.Parse("2018-12-24"), EmployeeID = 3, EmployeeJobCode = 3, EmployeeUnitCode = 3, EmployeeGroupCode = 3 });
            context.Honors.Add(new Honor { HonorTarget = "团队", HonorName = "荣誉6", HonorLevel = 3, CreateTime = DateTime.Parse("2018-12-24"), EmployeeID = 3, EmployeeJobCode = 3, EmployeeUnitCode = 3, EmployeeGroupCode = 3 });

            #endregion

            #region 初始岗位

            context.Positions.Add(new Position { PositionName = "Position1" });
            context.Positions.Add(new Position { PositionName = "Position2" });
            context.Positions.Add(new Position { PositionName = "Position3" });
            context.Positions.Add(new Position { PositionName = "Position4" });
            context.Positions.Add(new Position { PositionName = "Position5" });
            context.Positions.Add(new Position { PositionName = "Position6" });

            #endregion

            #region 初始工作单位

            context.WorkingUnits.Add(new WorkingUnit { WorkingUnitName = "Unit1" });
            context.WorkingUnits.Add(new WorkingUnit { WorkingUnitName = "Unit2" });
            context.WorkingUnits.Add(new WorkingUnit { WorkingUnitName = "Unit3" });
            context.WorkingUnits.Add(new WorkingUnit { WorkingUnitName = "Unit4" });
            context.WorkingUnits.Add(new WorkingUnit { WorkingUnitName = "Unit5" });
            context.WorkingUnits.Add(new WorkingUnit { WorkingUnitName = "Unit6" });

            #endregion

            #region 初始团体

            context.WorkingGroups.Add(new WorkingGroup { WorkingGroupName = "Group1" });
            context.WorkingGroups.Add(new WorkingGroup { WorkingGroupName = "Group2" });
            context.WorkingGroups.Add(new WorkingGroup { WorkingGroupName = "Group3" });
            context.WorkingGroups.Add(new WorkingGroup { WorkingGroupName = "Group4" });
            context.WorkingGroups.Add(new WorkingGroup { WorkingGroupName = "Group5" });
            context.WorkingGroups.Add(new WorkingGroup { WorkingGroupName = "Group6" });

            #endregion

        }
    }
}
