using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TodoKnockout.Models;

namespace TodoKnockout.Controllers
{
    public class TodoController : Controller
    {
        // Variável que vai simular o db.
        private static IList<Todo> _db;

        public TodoController()
        {
            // Se o db existe não faz nada
            if (_db != null) return;
            _db = new List<Todo>();
            var todo1 = new Todo
            {
                CreatedIn = DateTime.Now,
                Done = true,
                Id = Guid.NewGuid().ToString(),
                Title = "Todo1"
            };
            var todo2 = new Todo
            {
                CreatedIn = DateTime.Now,
                Done = false,
                Id = Guid.NewGuid().ToString(),
                Title = "Todo2"
            };
            var todo3 = new Todo
            {
                CreatedIn = DateTime.Now,
                Done = true,
                Id = Guid.NewGuid().ToString(),
                Title = "Todo3"
            };
            _db.Add(todo1);
            _db.Add(todo2);
            _db.Add(todo3);
        }

        //
        // GET: /Todo/
        public ActionResult Index()
        {
            return View(_db.ToList());
        }

        [HttpPost]
        public JsonResult Add(string title)
        {
            var model = new Todo
            {
                Title = title,
                Id = Guid.NewGuid().ToString()
            };
            _db.Add(model);
            return Json(model);
        }

        [HttpPost]
        public JsonResult Edit(Todo model)
        {
            var edit = _db.SingleOrDefault(x => string.Equals(x.Id, model.Id));
            if (edit == null) throw new Exception("Todo não existe!"); 
            edit.Done = model.Done;
            return Json(model);
        }

        [HttpPost]
        public JsonResult Delete(string id)
        {
            var todo = _db.SingleOrDefault(x => string.Equals(x.Id, id));
            _db.Remove(todo);
            return Json(id);
        }
    }
}