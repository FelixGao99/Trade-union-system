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

namespace TradeUnionManageSystem.UI.Controllers
{
    public class WorkingTeamController : Controller
    {
        private MyContext db = new MyContext();

        // GET: WorkingTeam
        public ActionResult Index()
        {
            ViewBag.Title = "班组管理";
            return View(db.WorkingTeams.ToList());
        }




        // GET: WorkingTeam/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkingTeam workingTeam = db.WorkingTeams.Find(id);
            if (workingTeam == null)
            {
                return HttpNotFound();
            }
            return View(workingTeam);
        }

        // GET: WorkingTeam/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkingTeam/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UnitCode,TeamName,CarCount,EmployeeCount,MonitorEmployeeID,MonitorPoliticalStatus,SubMonitorEmployeeID,SubMonitorPoliticalStatus")] WorkingTeam workingTeam)
        {
            if (ModelState.IsValid)
            {
                db.WorkingTeams.Add(workingTeam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(workingTeam);
        }

        // GET: WorkingTeam/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkingTeam workingTeam = db.WorkingTeams.Find(id);
            if (workingTeam == null)
            {
                return HttpNotFound();
            }
            return View(workingTeam);
        }

        // POST: WorkingTeam/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UnitCode,TeamName,CarCount,EmployeeCount,MonitorEmployeeID,MonitorPoliticalStatus,SubMonitorEmployeeID,SubMonitorPoliticalStatus")] WorkingTeam workingTeam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workingTeam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workingTeam);
        }

        // GET: WorkingTeam/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkingTeam workingTeam = db.WorkingTeams.Find(id);
            if (workingTeam == null)
            {
                return HttpNotFound();
            }
            return View(workingTeam);
        }

        // POST: WorkingTeam/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkingTeam workingTeam = db.WorkingTeams.Find(id);
            db.WorkingTeams.Remove(workingTeam);
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
