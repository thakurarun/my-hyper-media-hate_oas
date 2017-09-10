using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Backend.Controller.Product
{
    public class EditController : ApiController
    {
        private IProductDataService productDataService;

        public EditController(IProductDataService productDataService)
        {
            this.productDataService = productDataService;
        }

        public IHttpActionResult Post(int id, [FromBody] ProductBodyData data)
        {
            data.Name = $"{data.Name}: Modified";
            return Ok(data);
        }
    }

    public class ProductBodyData
    {
        public string Name { get; set; }
        public decimal Quantity { get; set; }
    }
}