﻿using Lab_01_Ian_Gesner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net.Http.Formatting;
using System.Web;

namespace Lab_01_Ian_Gesner.Proxies
{
    public class BookProxy : IBookProxy
    {
        private static HttpClient _client;
        public List<Book> _books;

        public BookProxy()
        {
            _client = new HttpClient();

            //string serviceBaseUrl = ConfigurationManager.AppSettings["DateServiceBaseUrl"];

            _client.BaseAddress = new Uri("http://localhost:23407/api/");

            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            List<Book> booksList = new List<Book>();

            HttpResponseMessage response = await _client.GetAsync("Book");
            if (response.IsSuccessStatusCode)
            {
                booksList = await response.Content.ReadAsAsync<List<Book>>();
            }
            return booksList;
        }

        //static public async Task<IEnumerable<Book>> RunAsync()
        //{
        //    _client.BaseAddress = new Uri("http://localhost:23407/api/");
        //    _client.DefaultRequestHeaders.Accept.Clear();
        //    _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //    var Books = await GetBooksAsync("Books");

        //    return Books;
        //}

        //public async Task<IEnumerable<Book>> GetBooksAsync(string path)
        //{


        //    IEnumerable<Book> books = null;
        //    HttpResponseMessage response = await _client.GetAsync(path);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        books = await response.Content.ReadAsAsync<IEnumerable<Book>>();
        //    }
        //    return books;
        //}
    }
}
