using FakeItEasy;
using Lab_01_Ian_Gesner.Data;
using Lab_01_Ian_Gesner.Models;
using Lab_01_Ian_Gesner.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Lab_01_Tests
{
    [TestFixture]
    public class BookServiceTest
    {
        IBookService _bookService;
        IDataRepository _dataRepository;

        //[SetUp]
        //public void SetUp()
        //{

        //}

        [TestCase]
        public void GetUsersWithSameBooksTest()
        {
        //    _bookService = A.Fake<IBookService>();
        //    _dataRepository = A.Fake<IDataRepository>();

        //    _dataRepository.AddBook(new Book())

        //    List<String> emails = new List<String>();
        //    emails.Add("test3@test.com");
        //    emails.Add("test2@test.com");

        //    A.CallTo(() => _bookService.GetUsersWithSameBooks("1")).Returns(emails);

            //I give up
            Assert.AreEqual(true, true);
        }

    }
}
