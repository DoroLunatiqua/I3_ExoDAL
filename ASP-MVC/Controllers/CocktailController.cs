using ASP_MVC.Mappers;
using ASP_MVC.Models.Cocktail;
using BLL.Entities;
using Common.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ASP_MVC.Controllers
{
    public class CocktailController : Controller
    {


        private ICocktailRepository<BLL.Entities.Cocktail> _cocktailService;

        public CocktailController(ICocktailRepository<BLL.Entities.Cocktail> cocktailSerice) 
        {
            _cocktailService = cocktailSerice;
        }


        // GET: CocktailController
        public ActionResult Index()
        {
            try {
                IEnumerable<CocktailListItem> model = _cocktailService.Get().Select(bll => bll.ToListItem()); //ICI creation du mapper 
                return View(model);
            }
            catch (Exception ex) { return RedirectToAction("Error", "Home"); }
            
        }

        // GET: CocktailController/Details/5
        public ActionResult Details(Guid id)
        {
            try
            {
                CocktailDetails model = _cocktailService.Get(id).ToCocktailDetails();
                return View(model);
            }
            catch (Exception ex) { return RedirectToAction("Error", "Home"); }
        }

        // GET: CocktailController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CocktailController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CocktailController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CocktailController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CocktailController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CocktailController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
