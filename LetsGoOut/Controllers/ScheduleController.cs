using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using LetsGoOut.ActionFilters;
using LetsGoOut.ReadModel;

namespace LetsGoOut.Controllers
{
    public class ScheduleController : Controller, IDataBaseContainer
    {
        private readonly DbContext _context;

        public ScheduleController(DbContext context)
        {
            _context = context;
        }

        [SimpleDataActionFilter]
        public ActionResult Index()
        {
            var activities = DataBase.ActivityViews.FindAllByDate(DateTime.Today).OrderByStartAt().ToList<Activity>();
            var model = new ActivitiesModel
            {
                Activities = activities
            };

            return View(model);
        }

        public ActionResult Create()
        {
            return View(new Activity());
        }

        [HttpPost]
        public ActionResult Create(Activity activity)
        {
            _context.Set<Domain.Activity>().Add(new Domain.Activity {Name = activity.Name});

            return RedirectToAction("Index");
        }

        public ActionResult Move(int activityId, string name)
        {
            return View(new ActivityMove { ActivityId = activityId, Move = name });
        }

        [HttpPost]
        public ActionResult Move(ActivityMove activityMove)
        {
            var activity = _context.Set<Domain.Activity>().FirstOrDefault(a => a.ActivityId == activityMove.ActivityId);
            activity.Name = activityMove.Move;

            return RedirectToAction("Index");
        }
        public class ActivitiesModel
        {
            public IEnumerable<Activity> Activities { get; set; } 
        }

        public class ActivityMove
        {
            public int ActivityId { get; set; }
            public string Move { get; set; }
        }

        public dynamic DataBase { get; set; }
    }
}