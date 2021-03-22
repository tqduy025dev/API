using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class Content
    {
        private string time;
        private string message;
        private string link;

        public string Time { get => time; set => time = value; }
        public string Message { get => message; set => message = value; }
        public string Link { get => link; set => link = value; }
    }
}