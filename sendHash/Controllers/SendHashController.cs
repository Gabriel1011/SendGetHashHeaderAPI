using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace sendHash.Controllers
{
    [Route("sendHash")]
    [ApiController]
    public class SendHashController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> SendHash()
        {
            var hashcode = Guid.NewGuid().ToString();
            string url = "https://localhost:44302/getHash";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();

                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("text/html"));
                client.DefaultRequestHeaders.Add("Hash", hashcode);


                HttpResponseMessage response = await client.GetAsync(url);
                string responsestr = "";
                if (response.IsSuccessStatusCode)
                {
                    responsestr = await response.Content.ReadAsStringAsync();

                    return Json(new { success = true, response = responsestr, hash = hashcode });
                }
            }

            return Ok();
        }
    }
}