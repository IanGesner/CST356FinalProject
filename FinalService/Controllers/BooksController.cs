﻿using Lab_01_Ian_Gesner.Data;
using Lab_01_Ian_Gesner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinalService.Controllers
{
    public class BooksController : ApiController
    {
        private IDataRepository _dataRepository;

        public BooksController()
        {
            _dataRepository = new EfDataRepository();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            List<Book> books = _dataRepository.GetAllBooksForAllUsers();

            return books;
        }

        //public IHttpActionResult GetProduct(int id)
        //{
        //    var product = products.FirstOrDefault((p) => p.Id == id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(product);
        //}
    }
}
