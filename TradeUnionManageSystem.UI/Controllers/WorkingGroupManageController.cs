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

namespace TradeUnionManageSystem.UI.Controllers
{
    public class WorkingGroupManageController : Controller
    {
        private MyContext db = new MyContext();

        // GET: WorkingGroupManage
        public ActionResult Index()
        {
            return View(db.WorkingGroups.ToList());
        }

        // GET: WorkingGroupManage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkingGroup workingGroup = db.WorkingGroups.Find(id);
            if (workingGroup == null)
            {
                return HttpNotFound();
            }
            return View(workingGroup);
        }

        // GET: WorkingGroupManage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkingGroupManage/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,WorkingGroupName")] WorkingGroup workingGroup)
        {
            if (ModelState.IsValid)
            {
                db.WorkingGroups.Add(workingGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(workingGroup);
        }

        // GET: WorkingGroupManage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkingGroup workingGroup = db.WorkingGroups.Find(id);
            if (workingGroup == null)
            {
                return HttpNotFound();
            }
            return View(workingGroup);
        }

        // POST: WorkingGroupManage/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,WorkingGroupName")] WorkingGroup workingGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workingGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workingGroup);
        }

        // GET: WorkingGroupManage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkingGroup workingGroup = db.WorkingGroups.Find(id);
            if (workingGroup == null)
            {
                return HttpNotFound();
            }
            return View(workingGroup);
        }

        // POST: WorkingGroupManage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkingGroup workingGroup = db.WorkingGroups.Find(id);
            db.WorkingGroups.Remove(workingGroup);
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
