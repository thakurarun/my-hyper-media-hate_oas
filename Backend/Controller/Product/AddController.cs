using Backend.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Backend.Controller.Product
{
    public class AddController : ApiController
    {
        private IProductDataService productDataService;

        public AddController(IProductDataService productDataService)
        {
            this.productDataService = productDataService;
        }

        public IHttpActionResult Post([FromBody] MockProduct product)
        {
            // productDataService.
            return Ok(product);
        }
    }
}