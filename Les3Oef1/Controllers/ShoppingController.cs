using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Les3Oef1.Controllers
{
    public class ShoppingController : Controller
    {
        private List<ShoppingList> items = new List<ShoppingList>();
        public ActionResult Index()
        {
            if (TempData.Peek("items") != null)
            {
                items = JsonConvert.DeserializeObject<List<ShoppingList>>(TempData["items"].ToString());
            }
            return View(items);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View(new ShoppingList { });
        }

        [HttpPost]
        public ActionResult Create(ShoppingList item)
        {
            items.Add(item);
            TempData["items"] = JsonConvert.SerializeObject(items);
            return View("Finish", item);
        }
    }
}