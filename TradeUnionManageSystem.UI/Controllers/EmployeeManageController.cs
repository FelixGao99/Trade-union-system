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
using TradeUnionManageSystem.UI.Models.FilterModel;

namespace TradeUnionManageSystem.UI.Controllers
{
    public class EmployeeManageController : Controller
    {
        private MyContext db = new MyContext();

        public ActionResult Index()
        {
            int currentPage = 1;
            int pageSize = 5;

            int count = 0;
            var result = db.Employees.Pagination(t => t.ID, currentPage, pageSize, out count);

            ViewData["totalPages"] = count / pageSize + 1; // 分页后总的页面数
            ViewData["currentPage"] = currentPage;  // 当前页码

            return View(result.ToList());
        }

        public ActionResult GetEmployeeList(string searchType, EmployeeFilterModel filters, int currentPage = 1, int pageSize = 5)
        {
            var items = db.Employees.AsQueryable();

            // 高级搜索
            if(searchType == "AdvancedSearch")
            {
                if (!string.IsNullOrEmpty(filters.EmployeeName))
                    items = items.Where(p => p.Name.Contains(filters.EmployeeName));

                if (filters.EmployeeGender >= 0)
                    items = items.Where(p => p.Gender == filters.EmployeeGender);

                if (filters.BirthdayStart >= DateTime.MinValue && filters.BirthdayEnd > filters.BirthdayStart)
                    items = items.Where(p => p.Birthday >= filters.BirthdayStart);
                if (filters.BirthdayEnd > DateTime.MinValue && filters.BirthdayEnd > filters.BirthdayStart)
                    items = items.Where(p => p.Birthday <= filters.BirthdayEnd);
            }

            int count = 0;
            var result = items.Pagination(t => t.ID, currentPage, pageSize, out count);

            ViewData["totalPages"] = count / pageSize + 1; // 分页后总的页面数
            ViewData["currentPage"] = currentPage;  // 当前页码

            return PartialView("~/Views/EmployeeManage/EmployeeList.cshtml", result.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Gender,Birthday,JobCode,UnitCode,GroupCode")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Gender,Birthday,JobCode,UnitCode,GroupCode")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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
