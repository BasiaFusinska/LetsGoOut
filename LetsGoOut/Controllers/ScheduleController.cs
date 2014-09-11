using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using LetsGoOut.ActionFilters;
using LetsGoOut.Domain.Requests;
using LetsGoOut.Domain.Services;
using LetsGoOut.ReadModel;

namespace LetsGoOut.Controllers
{
    public class ScheduleController : Controller, IDataBaseContainer
    {
        private readonly IActivityService _activityService;
        private readonly DbContext _context;

        public ScheduleController(IActivityService activityService, DbContext context)
        {
            _activityService = activityService;
            _context = context;
        }

        [SimpleDataActionFilter]
        public ActionResult Index()
        {
            var activities = DataBase.ActivityViews.FindAllByDate(DateTime.Today).OrderByStartAt().ToList<Activity>();

            return View(activities);
        }

        public ActionResult Create()
        {
            return View(new CreateActivityRequest());
        }

        [HttpPost]
        public ActionResult Create(CreateActivityRequest createActivityRequest)
        {
            _activityService.CreateActivity(createActivityRequest);

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