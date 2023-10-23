using api_doc_mongodb.domain.Dtos;
using api_doc_mongodb.domain.ModelView;
using api_doc_mongodb.domain.Results;
using MongoDB.Bson;

namespace api_doc_mongodb.domain.Services
{
    public interface ICustomerService
    {
        Task<ResultService<GetCustomersModelView>> GetByObjectIdAsync(string ObjectId);
        Task<ResultService<List<GetCustomersModelView>>> CustomerAllAsync();
        Task<ResultService<CustomerCreatedModelView>> PostCreateCustomerAsync(CustomerCreateDto customerAddDto);
        Task<ResultService<bool>> UpdateCreateCustomerAsync(string ObjectId, CustomerUpdateDto customerUpdateDto);
        Task<ResultService<bool>> DeleteAsync(string id);
    }
}