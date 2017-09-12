using Backend.Mock;
using HyperMedia;
using Ploeh.Hyprlinkr;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace Backend.Controller.Product
{
    public class ProductController : ApiController
    {
        private IProductDataService productDataService;
        private readonly RouteLinker linker;
        public ProductController(RouteLinker linker)
        {
            this.linker = linker;
            this.productDataService = new ProductDataService();
        }
        public async Task<IHttpActionResult> Get(int id)
        {
            var result = await this.productDataService.GetProductsList(0, 15);
            var product = result.FirstOrDefault(item => item.Id == id);
            var data = new ResourceData(product);
            data.WithLink(linker.LinkToProduct(id));
            data.WithLink(linker.LinkToEditProduct(id));
            data.WithLink(linker.LinkToDeleteProduct(id));
            return Ok(data);
        }
    }

    public static class ProductExtensions
    {
        public static Link LinkToProduct(this RouteLinker linker, int id)
        {
            return new ResourceLinker()
                        .From<ProductController>("self",  linker.GetUri<ProductController>(r => r.Get(id)));
        }

        public static Link LinkToEditProduct(this RouteLinker linker, int id)
        {
            return new ResourceLinker()
                        .From<EditController>("edit", linker.GetUri<EditController>(r=> r.Post(id, null)));
        }

        public static Link LinkToDeleteProduct(this RouteLinker linker, int id)
        {
            return new ResourceLinker()
                        .From<DeleteController>("delete", linker.GetUri<DeleteController>(r => r.Delete(id)));
        }
    }
}