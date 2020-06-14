namespace CodelyTv.Apps.Backoffice.Frontend.Controllers.Courses
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Mooc.CoursesCounter.Application.Find;
    using Shared.Domain.Bus.Query;

    [Route("Courses")]
    public class CoursesGetWebController : Controller
    {
        private readonly IQueryBus _bus;

        public CoursesGetWebController(IQueryBus bus)
        {
            _bus = bus;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            CoursesCounterResponse counterResponse =
                await _bus.Ask<CoursesCounterResponse>(new FindCoursesCounterQuery());

            ViewBag.Title = "Welcome";
            ViewBag.Description = "CodelyTV - Backoffice";
            ViewBag.CoursesCounter = counterResponse.Total;
            ViewBag.UUID = Guid.NewGuid().ToString();
            return View("/Views/Courses/Courses.cshtml");
        }
    }
}