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
        // search request and display results
        public IActionResult Results (string searchType, string searchTerm)
        {
            //Create a list to store queried results to be returned
            if (searchType.Equals("all"))
            {

                //Use FindByValue passing searchTerm and store the values in the list
                List<Dictionary<string, string>> jobs = JobData.FindByValue(searchTerm);
                ViewBag.title = "Searched Jobs"; //update to use the search type and term
                ViewBag.columns = ListController.columnChoices;
                ViewBag.jobs = jobs;
                return View("");
            }
            else
            {

                //Use the searchTerm and the searchType and use the FindByColumnandValue method and save that to the list
                List<Dictionary<string, string>> items = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.title = "Searched Jobs"; //update to use the search type and term
                ViewBag.columns = ListController.columnChoices;
                ViewBag.items = items;
                return View("");


            }

            //set the value of Viewbag.columns property to the columnChoices of the ListController class
            //then set the Viewbag.jobs property to the list
            //then return the index view
        } 


    }
}
