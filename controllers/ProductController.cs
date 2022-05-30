using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDoperationmvc.Models;
using CRUDoperationmvc.ProductRepository;

namespace CRUDoperationmvc.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult GetAllProductDetails(int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            //return View(this.allProducts.ToPagedList(currentPageIndex, DefaultPageSize));
            ProductRespository ProRepo = new ProductRespository();
            ModelState.Clear();
            return View(ProRepo.GetAllProduct());
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

        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(ProductModel Pro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ProductRespository EmpRepo = new ProductRespository();

                    if (EmpRepo.AddProduct(Pro))
                    {
                        ViewBag.Message = "Product details added successfully";
                        return RedirectToAction("GetAllProductDetails");
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
        public ActionResult EditProDetails(int id)
        {
            ProductRespository ProRepo = new ProductRespository();
            return View(ProRepo.GetAllProduct().Find(Pro => Pro.ProductID == id));
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult EditProDetails(int id, ProductModel collection)
        {
            try
            {
                ProductRespository ProRepo = new ProductRespository();

                ProRepo.UpdateProduct(collection);
                return RedirectToAction("GetAllProductDetails");
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
        public ActionResult DeleteProduct(int id)
        {
            try
            {
                ProductRespository ProRepo = new ProductRespository();
                if (ProRepo.DeleteProduct(id))
                {
                    ViewBag.AlertMsg = "Product details deleted successfully";

                }
                return RedirectToAction("GetAllProductDetails");

            }
            catch
            {
                return View();
            }
        }
    }
}
