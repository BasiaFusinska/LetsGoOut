using System;
using System.Web.Mvc;
using LetsGoOut.ActionFilters;
using LetsGoOut.Domain;
using LetsGoOut.Domain.DTOs;
using LetsGoOut.Domain.Requests;
using LetsGoOut.Domain.Services;
using Activity = LetsGoOut.ReadModel.Activity;

namespace LetsGoOut.Controllers
{
    public class ScheduleController : Controller, IDataBaseContainer
    {
        private readonly IActivityService _activityService;
        private readonly ILinkService _linkService;
        private readonly ICommandBus _bus;

        public ScheduleController(IActivityService activityService,
                                  ILinkService linkService,
                                  ICommandBus bus)
        {
            _activityService = activityService;
            _linkService = linkService;
            _bus = bus;
        }

        [SimpleDataActionFilter]
        public ActionResult Index()
        {
            var activities = DataBase.ActivityViews.FindAllByDate(DateTime.Today).OrderByStartAt().ToList<Activity>();

            return View(activities);
        }

        public ActionResult Create()
        {
            var model = _bus.GetModel4Request<CreateActivityRequest, CreateActivityModel>(new CreateActivityRequest());
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateActivityModel createActivityModel)
        {
            _bus.Send(createActivityModel);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int activityId)
        {
            var model = _activityService.EditActivityModel(new EditActivityRequest { ActivityId = activityId});
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditActivityModel editActivityModel)
        {
            _activityService.EditActivity(editActivityModel);
            return RedirectToAction("Index"); 
        }

        public ActionResult Move(int activityId)
        {
            var model = _activityService.MoveActivityModel(new MoveActivityRequest {ActivityId = activityId});
            return View(model);
        }

        [HttpPost]
        public ActionResult Move(MoveActivityModel moveActivityModel)
        {
            _activityService.Move(moveActivityModel);

            return RedirectToAction("Index");
        }

        public ActionResult CreateLink(int previous, int next)
        {
            var model = _linkService.CreateLinkModel(new CreateLinkRequest { Next = next, Previous = previous });
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateLink(CreateLinkModel createLinkModel)
        {
            _linkService.CreateLink(createLinkModel);

            return RedirectToAction("Index");
        }

        public dynamic DataBase { get; set; }
    }
}