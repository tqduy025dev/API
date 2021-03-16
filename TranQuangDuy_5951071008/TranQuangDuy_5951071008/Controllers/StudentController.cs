using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TranQuangDuy_5951071008.Models;

namespace TranQuangDuy_5951071008.Controllers
{
    public class StudentController : ApiController
    {

        public IEnumerable<StudentInfo> Get()
        {
            var weatherInfList = new List<StudentInfo>();
            for (int i = 0; i < 10; i++)
            {
                var WeatherInfo = new StudentInfo
                {
                    MSV = $"{595107100 + i}",
                    Name = $"{"Nguyễn Van " + i}",
                    Birthday = DateTime.Parse("2000/11/11"),
                    Phone = "0123456789"
                };
                weatherInfList.Add(WeatherInfo);
            }
            return weatherInfList;
        }


        public StudentInfo Get(int id)
        {
            return new StudentInfo
            {
                MSV = $"595107100{id}",
                Name = $"{"Nguyễn Van " + id}",
                Birthday = DateTime.Parse("2000/11/11"),
                Phone = "0123456789"
            };
        }
    }
}
