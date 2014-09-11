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
        private readonly ILinkService _linkService;
        private readonly DbContext _context;

        public ScheduleController(IActivityService activityService,
                                  ILinkService linkService,
                                  DbContext context)
        {
            _activityService = activityService;
            _linkService = linkService;
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

        public ActionResult Edit(int activityId)
        {
            return View(_activityService.GetActivity(activityId));
        }

        [HttpPost]
        public ActionResult Edit(EditActivityRequest editActivityRequest)
        {
            _activityService.EditActivity(editActivityRequest);
            return RedirectToAction("Index"); 
        }

        public ActionResult Move(int activityId)
        {
            return View(new MoveActivityRequest { ActivityId = activityId });
        }

        [HttpPost]
        public ActionResult Move(MoveActivityRequest moveActivityRequest)
        {
            _activityService.Move(moveActivityRequest);

            return RedirectToAction("Index");
        }

        public ActionResult CreateLink(int previous, int next)
        {
            return View(new CreateLinkRequest { Next = next, Previous = previous});
        }

        [HttpPost]
        public ActionResult CreateLink(CreateLinkRequest createLinkRequest)
        {
            _linkService.CreateLink(createLinkRequest);

            return RedirectToAction("Index");
        }

        public dynamic DataBase { get; set; }
    }
}