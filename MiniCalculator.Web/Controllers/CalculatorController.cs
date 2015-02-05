using System.Web.Mvc;
using MiniCalculator.Json;

namespace MiniCalculator.Controllers
{
    public class CalculatorController : Controller
    {
        public CalculatorController(
            IJsonCombinedProbabilityCalculator jsonCombinedProbabilityCalculator,
            IJsonEitherProbabilityCalculator jsonEitherProbabilityCalculator)
        {
            this.jsonCombinedProbabilityCalculator = jsonCombinedProbabilityCalculator;
            this.jsonEitherProbabilityCalculator = jsonEitherProbabilityCalculator;
        }

        public ActionResult Index()
        {
            return View("Calculator");
        }

        public ActionResult Combined(float probabilityA, float probabilityB)
        {
            var jsonResponse = this.jsonCombinedProbabilityCalculator.Evaluate(probabilityA, probabilityB);
            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Either(float probabilityA, float probabilityB)
        {
            var jsonResponse = this.jsonEitherProbabilityCalculator.Evaluate(probabilityA, probabilityB);
            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }

        private readonly IJsonCombinedProbabilityCalculator jsonCombinedProbabilityCalculator;
        private readonly IJsonEitherProbabilityCalculator jsonEitherProbabilityCalculator;
    }
}
