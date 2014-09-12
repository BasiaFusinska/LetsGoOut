using System;
using System.Web.Mvc;
using LetsGoOut.ActionFilters;
using LetsGoOut.Domain;
using LetsGoOut.Domain.DTOs;
using LetsGoOut.Domain.Requests;
using Activity = LetsGoOut.ReadModel.Activity;

namespace LetsGoOut.Controllers
{
    public class ScheduleController : Controller, IDataBaseContainer
    {
        private readonly ICommandBus _bus;

        public ScheduleController(ICommandBus bus)
        {
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
            var model = _bus.GetModel4Request<EditActivityRequest, EditActivityModel>(new EditActivityRequest { ActivityId = activityId});
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditActivityModel editActivityModel)
        {
            _bus.Send(editActivityModel);
            return RedirectToAction("Index"); 
        }

        public ActionResult Move(int activityId)
        {
            var model = _bus.GetModel4Request<MoveActivityRequest, MoveActivityModel>(new MoveActivityRequest { ActivityId = activityId });
            return View(model);
        }

        [HttpPost]
        public ActionResult Move(MoveActivityModel moveActivityModel)
        {
            _bus.Send(moveActivityModel);
            return RedirectToAction("Index");
        }

        public ActionResult CreateLink(int previous, int next)
        {
            var model = _bus.GetModel4Request<CreateLinkRequest, CreateLinkModel>(new CreateLinkRequest { Next = next, Previous = previous });
            return View(model);
        }

        public ActionResult CreateLinkPost(int previous, int next, int linkType)
        {
            _bus.Send(new CreateLinkModel { LinkType = linkType, Next = next, Previous = previous });

            return RedirectToAction("Index");
        }

        public dynamic DataBase { get; set; }
    }
}