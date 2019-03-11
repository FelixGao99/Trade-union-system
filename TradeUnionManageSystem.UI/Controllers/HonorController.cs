using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TradeUnionManageSystem.BLL;
using TradeUnionManageSystem.BLL.Models;
using TradeUnionManageSystem.UI.Extensions;
using TradeUnionManageSystem.UI.Models.DisplayModel;
using TradeUnionManageSystem.UI.Models.FilterModel;

namespace TradeUnionManageSystem.UI.Controllers
{
    public class HonorController : Controller
    {
        private MyContext db = new MyContext();



        // GET: Honor
        public ActionResult Index()
        {
            ViewBag.Title = "荣誉管理";

            var units = db.WorkingUnits.ToList();
            var positions = db.Positions.ToList();

            SelectList unitSelectList = new SelectList(units, "ID", "WorkingUnitName", "--请选择单位--");
            SelectList positionSelectList = new SelectList(positions, "ID", "PositionName", "--请选择岗位--");

            ViewBag.EmployeeUnits = unitSelectList;
            ViewBag.EmployeePositions = positionSelectList;

            int currentPage = 1;
            int pageSize = 5;

            int count = 0;
            var result = db.Honors.Pagination(t => t.ID, currentPage, pageSize, out count);

            ViewData["totalPages"] = count / pageSize + 1; // 分页后总的页面数
            ViewData["currentPage"] = currentPage;  // 当前页码

            var displayResult = (from honor in result
                                 join employee in db.Employees on honor.EmployeeID equals employee.ID into joinedEmployees
                                 from joinedEmployee in joinedEmployees.DefaultIfEmpty()
                                 join unit in db.WorkingUnits on honor.EmployeeUnitCode equals unit.ID into joinedUnits
                                 from joinedUnit in joinedUnits.DefaultIfEmpty()
                                 join position in db.Positions on honor.EmployeeJobCode equals position.ID into joinedPositions
                                 from joinedPosition in joinedPositions.DefaultIfEmpty()
                                 join workingGroup in db.WorkingUnits on honor.EmployeeGroupCode equals workingGroup.ID into joinedWorkingGroups
                                 from joinedWorkingGroup in joinedWorkingGroups.DefaultIfEmpty()
                                 select new HonorDisplayModel
                                 {
                                     ID = honor.ID,
                                     HonorTarget = honor.HonorTarget,
                                     HonorEmployeeName = joinedEmployee == null ? "" : joinedEmployee.Name,
                                     HonorEmployeeGender = joinedEmployee == null ? "" : (joinedEmployee.Gender == 1 ? "男" : "女"),
                                     HonorEmployeeBirthday = joinedEmployee == null ? "" : joinedEmployee.Birthday.ToString(),
                                     HonorEmployeeWorkingPosition = joinedPosition == null ? "" : joinedPosition.PositionName,
                                     HonorEmployeeWorkingUnit = joinedUnit == null ? "" : joinedUnit.WorkingUnitName,
                                     HonorEmployeeWorkingGroup = joinedWorkingGroup == null ? "" : joinedWorkingGroup.WorkingUnitName,
                                     HonorName = honor.HonorName,
                                     HonorLevel = honor.HonorLevel,
                                     CreateTime = honor.CreateTime
                                 }).ToList();

            return View(displayResult);
        }

        public ActionResult GetHonorList(string searchType, HonorFilterModel filters, int currentPage = 1, int pageSize = 5)
        {
            var items = db.Honors.AsQueryable();

            if (searchType == "AdvancedSearch")
            {
                var employees = db.Employees.AsQueryable();

                if (!string.IsNullOrEmpty(filters.HonorName))
                    items = items.Where(p => p.HonorName.Contains(filters.HonorName));

                items = items.Where(p => p.EmployeeJobCode == filters.EmployeeWorkingPositionID);

                //if (filters.HonorLevel > 0)
                //    items = items.Where(p => p.HonorLevel == filters.HonorLevel);

                //if (!string.IsNullOrEmpty(filters.EmployeeName))
                //{
                //    var employee_ids = employees.Where(e => e.Name.Contains(filters.EmployeeName)).Select(e => e.ID).ToList();
                //    items = items.Where(p => employee_ids.Contains(p.EmployeeID));
                //}

                //if (!string.IsNullOrEmpty(filters.EmployeeWorkingUnit))
                //    items = items.Where(p => p.HonorName.Contains(filters.HonorName));

                //if (!string.IsNullOrEmpty(filters.EmployeeWorkingPosition))
                //    items = items.Where(p => p.HonorName.Contains(filters.HonorName));

                //if (!string.IsNullOrEmpty(filters.EmployeeGender))
                //    items = items.Where(p => p.HonorName.Contains(filters.HonorName));

                //if (filters.HonorStartTime != null)
                //    items = items.Where(p => p.CreateTime >= filters.HonorStartTime);
                //if (filters.HonorEndTime != null)
                //    items = items.Where(p => p.CreateTime <= filters.HonorEndTime);

                //if (!string.IsNullOrEmpty(filters.HonorTarget))
                //    items = items.Where(p => p.HonorTarget == filters.HonorTarget);
            }

            int count = 0;
            var result = items.Pagination(t => t.ID, currentPage, pageSize, out count);

            ViewData["totalPages"] = count / pageSize + 1; // 分页后总的页面数
            ViewData["currentPage"] = currentPage;  // 当前页码

            var displayResult = (from honor in result
                                 join employee in db.Employees on honor.EmployeeID equals employee.ID into joinedEmployees
                                 from joinedEmployee in joinedEmployees.DefaultIfEmpty()
                                 join unit in db.WorkingUnits on honor.EmployeeUnitCode equals unit.ID into joinedUnits
                                 from joinedUnit in joinedUnits.DefaultIfEmpty()
                                 join position in db.Positions on honor.EmployeeJobCode equals position.ID into joinedPositions
                                 from joinedPosition in joinedPositions.DefaultIfEmpty()
                                 join workingGroup in db.WorkingUnits on honor.EmployeeGroupCode equals workingGroup.ID into joinedWorkingGroups
                                 from joinedWorkingGroup in joinedWorkingGroups.DefaultIfEmpty()
                                 select new HonorDisplayModel
                                 {
                                     ID = honor.ID,
                                     HonorTarget = honor.HonorTarget,
                                     HonorEmployeeName = joinedEmployee == null ? "" : joinedEmployee.Name,
                                     HonorEmployeeGender = joinedEmployee == null ? "" : (joinedEmployee.Gender == 1 ? "男" : "女"),
                                     HonorEmployeeBirthday = joinedEmployee == null ? "" : joinedEmployee.Birthday.ToString(),
                                     HonorEmployeeWorkingPosition = joinedPosition == null ? "" : joinedPosition.PositionName,
                                     HonorEmployeeWorkingUnit = joinedUnit == null ? "" : joinedUnit.WorkingUnitName,
                                     HonorEmployeeWorkingGroup = joinedWorkingGroup == null ? "" : joinedWorkingGroup.WorkingUnitName,
                                     HonorName = honor.HonorName,
                                     HonorLevel = honor.HonorLevel,
                                     CreateTime = honor.CreateTime
                                 }).ToList();

            return PartialView("~/Views/Honor/HonorList.cshtml", displayResult);
        }




        // GET: Honor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Honor honor = db.Honors.Find(id);
            if (honor == null)
            {
                return HttpNotFound();
            }
            return View(honor);
        }

        // GET: Honor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Honor/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,HonorTarget,HonorLevel,CreateTime,CreateDeptCode,EmployeeID,EmployeeJobCode,EmployeeUnitCode,EmployeeGroupCode")] Honor honor)
        {
            if (ModelState.IsValid)
            {
                db.Honors.Add(honor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(honor);
        }

        // GET: Honor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Honor honor = db.Honors.Find(id);
            if (honor == null)
            {
                return HttpNotFound();
            }
            return View(honor);
        }

        // POST: Honor/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,HonorTarget,HonorLevel,CreateTime,CreateDeptCode,EmployeeID,EmployeeJobCode,EmployeeUnitCode,EmployeeGroupCode")] Honor honor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(honor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(honor);
        }

        // GET: Honor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Honor honor = db.Honors.Find(id);
            if (honor == null)
            {
                return HttpNotFound();
            }
            return View(honor);
        }

        // POST: Honor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Honor honor = db.Honors.Find(id);
            db.Honors.Remove(honor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
