using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class APIController : Controller
    {
        // GET: API
        public async Task<ActionResult> Index(DisbursedAmt modle)
        {
            string apiUrl = "https://od.moi.gov.tw/api/v1/rest/datastore/301110000A-001859-001";
            
            WebRequest request = WebRequest.Create(apiUrl);
            request.Method = "GET";
            
            using (var httpResponse = (HttpWebResponse)request.GetResponse())
            
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                string result = streamReader.ReadToEnd();

                Newtonsoft.Json.Linq.JObject obj = (Newtonsoft.Json.Linq.JObject)JsonConvert.DeserializeObject(result);
                //var zone = obj["result"]["records"].ToString();
                var collection = JsonConvert.DeserializeObject<IEnumerable<DisbursedAmt>>(obj["result"]["records"].ToString());
                var table = JsonConvert.DeserializeObject<System.Data.DataTable>(obj["result"]["records"].ToString());
               
                var handler = new APIHandler();
                handler.CreateData(table);
              

                return View(collection); 
            }
            
        }
       

    }
}