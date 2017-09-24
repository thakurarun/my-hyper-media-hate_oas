using HyperMedia;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace Backend.Controller.Product
{
    public class ProductController : ApiController
    {
        private readonly IMyResourceLinker linker;
        private IProductDataService productDataService;

        public ProductController(IMyResourceLinker linker)
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
        public static Link LinkToProduct(this IMyResourceLinker linker, int id)
        {
            return linker.From<ProductController>("self",  r => r.Get(id));
        }

        public static Link LinkToEditProduct(this IMyResourceLinker linker, int id)
        {
            return linker.From<EditController>("edit", r=> r.Post(id, null));
        }

        public static Link LinkToDeleteProduct(this IMyResourceLinker linker, int id)
        {
            return linker.From<DeleteController>("delete", c=> c.Delete(id));
        }
    }
}