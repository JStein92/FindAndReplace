using Microsoft.AspNetCore.Mvc;
using System;

namespace FindAndReplace.Models
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
    [HttpPost("/Result")]
    public ActionResult Result()
    {
      string original = Request.Form["original"];
      string replace = Request.Form["word-find"];
      string newStr = Request.Form["replacement-string"];

      FARP myFap = new FARP(original, replace, newStr);
      myFap.FindReplacePartials();

      return View(myFap);
    }

  }
}
