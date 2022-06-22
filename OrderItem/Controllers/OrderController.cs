using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace OrderItem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        [HttpPost("{Id}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> index(int Id)
        {
            Cart order1 = new Cart();
            MenuItem item = new MenuItem();
            string baseApi = "http://20.237.16.241/";
            using (var client = new HttpClient() )
            {
                client.BaseAddress = new Uri(baseApi);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage httpResponseMessage = await client.GetAsync("api/menuitem/"+Id);
                if(httpResponseMessage.StatusCode == HttpStatusCode.OK)
                {
                    string json = await httpResponseMessage.Content.ReadAsStringAsync();
                    item = JsonConvert.DeserializeObject<MenuItem>(json);
                }
                else if(httpResponseMessage.StatusCode == HttpStatusCode.NotFound)
                {
                    return NotFound(); 
                }
                order1.Id = 1;
                order1.UserId = 1;
                order1.MenuItemId = item.Id;
                order1.MenuItemName = item.Name;
                return Ok(order1);
            }

        }
    }
}
