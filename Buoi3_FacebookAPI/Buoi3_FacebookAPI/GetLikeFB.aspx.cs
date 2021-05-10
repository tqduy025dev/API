using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Buoi3_FacebookAPI
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            var req = WebRequest.Create("https://graph.facebook.com/102475348692304/feed?fields=comments.summary(true),likes.summary(true)&access_token=EAAAAZAw4FxQIBACFMRZCVuZCSpao1YDzIF4YatVsxZAUAjPpDDiu558ssDFpybeR9QiAFWrsQz5t8fGwm7f1haPJ6q4TK4VlkBrHyHlBsVhZAsyQaGcNWjI6E7uypVMxngxRwoDtJcSOkPlAkNWZAYSm9B8rwqYwwdxGVwMHETEXP6xPJhxGIN");
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();

            Stream stream = res.GetResponseStream();
            StreamReader reader = new StreamReader(stream);

            string responseString = reader.ReadToEnd();

            dynamic data = JsonConvert.DeserializeObject(responseString);


           
            string contentString = "<h2>3 Bài đăng gần nhất</h2></br>";
            for (int i = 0; i < 3; i++)
            {
                contentString += "<b></br>Bài thứ </b>" + (i + 1) + " có số like là:  "+ data.data[i].likes.summary.total_count;
                contentString += "<br>---------------------------------------------------------";
            }
            Label1.Text = contentString;

        }
    }


}