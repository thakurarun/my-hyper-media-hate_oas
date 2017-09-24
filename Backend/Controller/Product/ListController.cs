using Backend.Mock;
using HyperMedia;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Backend.Controller.Product
{
    public interface IListController
    {
        Task<IEnumerable<ResourceData>> Get(int start, int pageSize);
    }
    public class ListController : ApiController, IListController
    {
        private const int PageSize = 10;
        private IProductDataService productDataService;
        private IMyResourceLinker linker;

         public ListController(IProductDataService productDataService)
        // public ListController(IMyResourceLinker linker)
        {
            linker = new MyResourceLinker(this.Request);
            // this.productDataService = new ProductDataService();
            this.productDataService = productDataService;
        }
        public async Task<IEnumerable<ResourceData>> Get(int start, int pageSize)
        {
            var result = await productDataService.GetProductsList(0, pageSize == 0 ? PageSize : pageSize);
            return ToResourceData(result);
        }

        private IEnumerable<ResourceData> ToResourceData(IEnumerable<MockProduct> products)
        {
            var resourceData = new List<ResourceData>();
            foreach (var product in products)
            {
                var data = new ResourceData(product);
                data.WithLink(linker.LinkToProduct(product.Id));
                data.WithLink(linker.LinkToDeleteProduct(product.Id));
                data.WithLink(linker.LinkToEditProduct(product.Id));
                resourceData.Add(data);
            }
            return resourceData;
        }
    }
}
