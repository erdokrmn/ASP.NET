using ActionTypes.Models;
using Microsoft.AspNetCore.Mvc;

namespace ActionTypes.Controllers
{
    public class ActionController : Controller
    {
        #region ViewResult
        //public IActionResult ShowActions()
        //{
        //    ViewResult result = View();
        //    return result;
        //}
        #endregion

        #region PartialViewResult
        //public IActionResult ShowActions()
        //{
        //    //Bir sayfanın tamamını getirmek yerine parça kısmını getirir.(Client işlemlerinde kullanılır)

        //    PartialViewResult result = PartialView();
        //    return result;
        //}
        #endregion

        #region JsonResult
        //public JsonResult ShowActions()
        //{
        //    JsonResult result = Json(new Cat
        //    {
        //        Id = 1,
        //        Name = "Ragnar",
        //        CatBreed = "None"
        //    });

        //    return result;
        //}
        #endregion

        #region EmptyResult
        //public EmptyResult ShowActions()
        //{


        //    return new EmptyResult();
        //}
        #endregion

        #region ContentResult
        //public ContentResult ShowActions()
        //{
        //    ContentResult result = Content("Result Content");

        //    return result;
        //}
        #endregion

        #region ActionResult
        public ActionResult ShowActions()
        {
            if (true)
            {
                return Json(new Cat
                {
                    Id = 1,
                    Name = "Ragnar",
                    CatBreed = "None"
                });
            }
            else
            {
                return Content("asd123");
            }
        }
        #endregion

    }
}
