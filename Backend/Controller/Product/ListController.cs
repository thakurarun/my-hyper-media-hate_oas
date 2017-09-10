using Backend.Mock;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Collections;
using System.Linq;
using HyperMedia;

namespace Backend.Controller.Product
{
    public class ListController : ApiController
    {
        private const int PageSize = 10;
        private IProductDataService productDataService;
        public ListController(IProductDataService productDataService)
        {
            this.productDataService = productDataService;
        }
        public async Task<IEnumerable<ResourceData>> Get(int start, int pageSize)
        {
            var result = await productDataService.GetProductsList(0, pageSize == 0 ? PageSize : pageSize);
            return ToResourceData(result);
        }

        public IEnumerable<ResourceData> ToResourceData(IEnumerable<MockProduct> products)
        {
            var resourceData = new List<ResourceData>();
            foreach (var product in products)
            {
                var data = new ResourceData(product);
                data.WithLink(data.LinkToProduct(product.Id));
                data.WithLink(data.LinkToDeleteProduct(product.Id));
                data.WithLink(data.LinkToEditProduct(product.Id));
                resourceData.Add(data);
            }
            return resourceData;
        }
    }
}
