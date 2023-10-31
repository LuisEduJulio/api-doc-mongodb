using api_doc_mongodb.domain.Entities;
using api_doc_mongodb.domain.Results;
using MongoDB.Bson;

namespace api_doc_mongodb.domain.Repositories
{
    public interface ICustomerRepository
    {
        Task<ResultRepository<ObjectId>> InsertAsync(Customer document);
        Task<ResultRepository<bool>> UpdateCustomerAsync(ObjectId id, Customer document);
        Task<ResultRepository<bool>> DeleteAsync(ObjectId ObjectId);
        Task<ResultRepository<Customer>> GetCustomerByObjectIdAsync(ObjectId ObjectId);
        Task<ResultRepository<List<Customer>>> GetListAsync();
    }
}