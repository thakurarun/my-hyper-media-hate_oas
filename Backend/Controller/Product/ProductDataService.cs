using Backend.Mock;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Backend.Controller.Product
{
    public interface IProductDataService
    {
        Task<IEnumerable<MockProduct>> GetProductsList(int start, int count);
        Task<MockProduct> GetProduct(int id);
        Task<bool> DeleteProduct(int id);
    }

    public class ProductDataService : IProductDataService
    {
        public Task<bool> DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<MockProduct> GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MockProduct>>  GetProductsList(int start, int pageSize)
        {
            return await CreateBatchofList(start, pageSize);

        }

        private async Task<IEnumerable<MockProduct>> CreateBatchofList(int start, int pageSize)
        {
            var task = Task.Run(() =>
            {
                return ProductRepository
                            .GetProducts(ProductRepository.Option.WithMoreThanPageSize)
                            .Skip(start)
                            .Take(pageSize);
            });
            return await task;
            
        }
    }
}