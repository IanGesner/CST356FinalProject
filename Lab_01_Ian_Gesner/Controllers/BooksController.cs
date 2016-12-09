using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lab_01_Ian_Gesner.Models;
using Microsoft.AspNet.Identity;
using Lab_01_Ian_Gesner.Data;

namespace Lab_01_Ian_Gesner.Controllers
{
    public class BooksController : Controller
    {
        //private DatabaseContext db = new DatabaseContext();
        private readonly IDataRepository _dataRepository;

        public BooksController(IDataRepository dataRepository)
        {
            //_dataRepository = new EfDataRepository();
            _dataRepository = dataRepository;
        }


        // GET: Books
        public ActionResult Index()
        {
            //var books = db.Books.Include(b => b.ApplicationUser);
            //return View(books.ToList());
            var user = User.Identity.GetUserId();
            return View(_dataRepository.GetAllBooks(user));
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = _dataRepository.GetBook(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
           // ViewBag.Id = new SelectList(db.ApplicationUsers, "Id", "Email");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookID,Title,Author")] Book book)
        {
            if (ModelState.IsValid)
            {
                //db.Books.Add(book);
                //db.SaveChanges();
                book.Id = User.Identity.GetUserId();
                _dataRepository.AddBook(book);
                return RedirectToAction("Index");
            }

           // ViewBag.Id = new SelectList(db.ApplicationUsers, "Id", "Email", book.Id);
            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = _dataRepository.GetBook(id);
            if (book == null)
            {
                return HttpNotFound();
            }
           // ViewBag.Id = new SelectList(db.ApplicationUsers, "Id", "Email", book.Id);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookID,Title,Author")] Book book)
        {
            book.Id = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                _dataRepository.UpdateBook(book);
                return RedirectToAction("Index");
            }
            //ViewBag.Id = new SelectList(db.ApplicationUsers, "Id", "Email", book.Id);
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = _dataRepository.GetBook(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = _dataRepository.GetBook(id);
            _dataRepository.RemoveBook(book);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dataRepository.DisposeContext();
            }
            base.Dispose(disposing);
        }
    }
}
