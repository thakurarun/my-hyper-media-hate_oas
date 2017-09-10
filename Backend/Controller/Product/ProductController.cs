using Backend.Mock;
using HyperMedia;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace Backend.Controller.Product
{
    public class ProductController : ApiController
    {
        private IProductDataService productDataService;

        public ProductController(IProductDataService productDataService)
        {
            this.productDataService = productDataService;
        }
        public async Task<IHttpActionResult> Get(int id)
        {
            var result = await this.productDataService.GetProductsList(0, 15);
            var product = result.FirstOrDefault(item => item.Id == id);
            var data = new ResourceData(product);
            data.WithLink(data.LinkToProduct(id));
            data.WithLink(data.LinkToEditProduct(id));
            data.WithLink(data.LinkToDeleteProduct(id));
            return Ok(data);
        }
    }

    public static class ProductExtensions
    {
        public static Link LinkToProduct(this ResourceData resource, int id)
        {
            return new ResourceLinker()
                        .From<ProductController>("self", c => c.Get(id));
        }

        public static Link LinkToEditProduct(this ResourceData resource, int id)
        {
            return new ResourceLinker()
                        .From<EditController>("edit", c => c.Post(id, null));
        }

        public static Link LinkToDeleteProduct(this ResourceData resource, int id)
        {
            return new ResourceLinker()
                        .From<DeleteController>("delete", c => c.Delete(id));
        }
    }
}