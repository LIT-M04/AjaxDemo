using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication27.Controllers
{
    public class RandomNumber
    {
        public int Number { get; set; }
        public int[] MoreNums { get; set; }
    }
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetRandom(int min, int max)
        {
            Random rnd = new Random();
            int num = rnd.Next(min, max);
            RandomNumber r = new RandomNumber();
            int[] x = new int[rnd.Next(10, 20)];
            for (int i = 0; i < x.Length; i++)
            {
                x[i] = rnd.Next(min, max);
            }
            r.Number = num;
            r.MoreNums = x;
            return Json(r, JsonRequestBehavior.AllowGet);
        }

        public ActionResult IsUsernameAvailable(string username)
        {
            return Json(new { isAvailable = username.Length == 5 }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Reversed(string text)
        {
            var obj = new { reversed = ReverseString(text) };
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        private string ReverseString(string text)
        {
            return new String(text.Reverse().ToArray());
        }

        private string ReverseString2(string text)
        {
            string result = "";
            for (int i = text.Length - 1; i >= 0; i--)
            {
                result += text[i];
            }

            return result;
        }
    }
}
