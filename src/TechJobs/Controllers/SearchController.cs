using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // Search the request and display results
        public IActionResult Results(string searchType, string searchTerm)
        {
            //Create a list to store queried results to be returned
            if (searchType.Equals("all"))
            {

                //Use FindByValue passing searchTerm and store the values in the list
                List<Dictionary<string, string>> jobs = JobData.FindByValue(searchTerm);
                ViewBag.title = "Searched Jobs"; //update to use the search type and term
                ViewBag.columns = ListController.columnChoices;
                ViewBag.jobs = jobs;
                return View("Index");
                //After looking up the search results via the JobData class, you'll need to pass them into the 
                //Views/Search/Index.cshtml view. Note that this is not the default view for this action.
                //You'll also need to pass ListController.columnChoices to the view, as is done in the Index method.
            }
            else
            {
                //Use the searchTerm and the searchType and use the FindByColumnandValue method and save that to the list
                List<Dictionary<string, string>> items = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.title = "Searched Jobs"; //update to use the search type and term
                ViewBag.columns = ListController.columnChoices;
                ViewBag.jobs = items; //Is this needed?
                ViewBag.items = items; 
                return View("Index");
                //After looking up the search results via the JobData class, you'll need to pass them into the 
                //Views/Search/Index.cshtml view. Note that this is not the default view for this action.
                //You'll also need to pass ListController.columnChoices to the view, as is done in the Index method.

            }




        }


    }
}