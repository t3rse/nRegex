using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using nRegex.Models;
using nRegex.Utils;
using System.Diagnostics;

namespace nRegex.Controllers
{
    public class RegexController : Controller
    {
        [HttpPost]
        public ActionResult EvaluateExpression(string queryObject) 
        {
            try
            {
                var regexQuery = JsonConvert.DeserializeObject<RegexQueryBuilder>(queryObject);
                var result = RegexProcessor.Evaluate(regexQuery);

                RegexMatchDataModel matchDataModel = new RegexMatchDataModel() { 
                    OriginalTarget = regexQuery.Target, 
                    Matches = result.Matches, 
                    MatchSortedList = result.MatchSortedList
                };
                return PartialView("~/Views/Regex/_RegexMatchView.cshtml", matchDataModel);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString()); // logging here?
                return Json(new { Success = false, JsonDetails = ex.Message });
            }

        }
    }
}
