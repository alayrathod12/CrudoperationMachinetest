using CRUDoperationmvc.Models.Models_cat;
using CRUDoperationmvc.ProductRepository.Category_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDoperationmvc.Controllers.Controllers_cat
{
    public class CategoryController : Controller
    {
        public ActionResult GetAllCategoryDetails(int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            //return View(this.allProducts.ToPagedList(currentPageIndex, DefaultPageSize));
            CategoryRepository ProRepo = new CategoryRepository();
            ModelState.Clear();
            return View(ProRepo.GetAllCategory());
            // return View();
        }

        //// GET: Product/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: Product/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(CategoryModel Pro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CategoryRepository EmpRepo = new CategoryRepository();

                    if (EmpRepo.AddCategory(Pro))
                    {
                        ViewBag.Message = "Category details added successfully";
                        return RedirectToAction("GetAllCategoryDetails");
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        //// POST: Product/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Product/Edit/5
        public ActionResult EditCatDetails(int id)
        {
            CategoryRepository ProRepo = new CategoryRepository();
            return View(ProRepo.GetAllCategory().Find(Pro => Pro.CategoryID == id));
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult EditCatDetails(int id, CategoryModel collection)
        {
            try
            {
                CategoryRepository ProRepo = new CategoryRepository();

                ProRepo.UpdateCategory(collection);
                return RedirectToAction("GetAllCategoryDetails");
            }
            catch
            {
                return View();
            }
        }


        //// GET: Product/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: Product/Delete/5

        [HttpPost]
        public ActionResult DeleteCategory(int id)
        {
            try
            {
                CategoryRepository ProRepo = new CategoryRepository();
                if (ProRepo.DeleteCategory(id))
                {
                    ViewBag.AlertMsg = "Category details deleted successfully";

                }
                return RedirectToAction("GetAllCategoryDetails");

            }
            catch
            {
                return View();
            }
        }
    }
}
    
