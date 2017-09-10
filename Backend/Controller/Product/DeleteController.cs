using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Backend.Controller.Product
{
    public class DeleteController : ApiController
    {
        private IProductDataService productDataService;
        public DeleteController(IProductDataService productDataService)
        {
            this.productDataService = productDataService;
        }

        public async Task<IHttpActionResult> Delete(int id)
        {
          //  await productDataService.GetProductsList(0, 15);
            return Ok();
        }
    }
}