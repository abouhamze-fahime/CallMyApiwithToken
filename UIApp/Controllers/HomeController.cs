using Application.Dto;
using Application.Interface;
using Application.Services;
using Infrastructure.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UIApp.Models;

namespace UIApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPersonService _service;
     //   private IHttpClientFactory _httpClientFactory;
        public HomeController(ILogger<HomeController> logger, IPersonService service )
        {
            _logger = logger;
            _service = service;
          //  _httpClientFactory = new IHttpClientFactory();
        }

        public ActionResult Index()
        {
           // GetToken token = new GetToken();
           // LoginModel us = new LoginModel();
           // us.UserName = "sadra";
           // us.Password = "123";
           //// var to = token.GetToken(us);
           // var to2 = token.GetToken2(us);
           // // string token = User.FindFirst("AccessKey").Value;
          
           // var res = _service.GetPersonByBuilding("کالج" , to2);
            return View();
        }

        [HttpGet]

        public List<PersonDto> getlst()
        {
            GetToken token = new GetToken();
            LoginModel us = new LoginModel();
            us.UserName = "sadra";
            us.Password = "123";
            // var to = token.GetToken(us);
            var to2 = token.GetToken2(us);
            // string token = User.FindFirst("AccessKey").Value;

            var res = _service.GetPersonByBuilding("کالج", to2);
            return res;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public List<PersonDto> GetPeopleByInfo([FromBody] PersonInfo person)
        {
            GetToken token = new GetToken();
            LoginModel us = new LoginModel();
            us.UserName = "sadra";
            us.Password = "123";
            // var to = token.GetToken(us);
            var to2 = token.GetToken2(us);
            // string token = User.FindFirst("AccessKey").Value;
            var person1 = _service.GetPersonByInfo(person , to2);
            return person1;
        }

        [HttpPost]
        public PersonDto add([FromBody] PersonDto person)
        {

            var person1 = _service.AddPerson(person);
            return person1;
        }

        [HttpPut]
        public PersonDto Edit([FromBody] PersonDto person)
        {

            var person1 = _service.UpdatePerson(person);
            return person1;
        }
        [HttpDelete]
        public PersonDto Delete( int id)
        {

            var person1 = _service.DeletePerson(id);
            return person1;
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



    }
}
