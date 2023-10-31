using api_doc_mongodb.domain.Entities;
using api_doc_mongodb.domain.Repositories;
using api_doc_mongodb.domain.Results;
using api_doc_mongodb.infraestructure.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace api_doc_mongodb.infraestructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ILogger<CustomerRepository> _logger;
        private readonly IMongoCollection<Customer> _collection;
        public CustomerRepository(
            ILogger<CustomerRepository> logger,
            IOptions<AppSettings> settings
            )
        {
            _logger = logger;

            var client = new MongoClient(settings.Value.ConnectionStrings.Connection);

            if (client != null)
            {
                try
                {
                    var database = client.GetDatabase("mydevdb");

                    _collection = database.GetCollection<Customer>("customers");
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Erro ao estabelecer a conexão com o MongoDB: {ex.Message}");
                }
            }
        }
        public async Task<ResultRepository<List<Customer>>> GetListAsync()
        {
            try
            {
                var result = await _collection.Find(new BsonDocument()).ToListAsync();

                var ResultRepository = new ResultRepository<List<Customer>>()
                {
                    Data = result,
                    Success = true
                };

                return ResultRepository;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                var ResultRepository = new ResultRepository<List<Customer>>()
                {
                    Data = new List<Customer>(),
                    Success = false,
                    Message = ex.Message
                };

                return ResultRepository;
            }
        }
        public async Task<ResultRepository<Customer>> GetCustomerByObjectIdAsync(ObjectId ObjectId)
        {
            try
            {
                var filter = Builders<Customer>.Filter.Eq("_id", ObjectId);

                var result = await _collection.Find(filter).FirstOrDefaultAsync();

                var ResultRepository = new ResultRepository<Customer>()
                {
                    Data = result,
                    Success = true
                };

                return ResultRepository;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                var ResultRepository = new ResultRepository<Customer>()
                {
                    Data = new Customer(),
                    Success = false,
                    Message = ex.Message
                };

                return ResultRepository;
            }
        }
        public async Task<ResultRepository<ObjectId>> InsertAsync(Customer customer)
        {
            try
            {
                customer.Id = ObjectId.GenerateNewId();

                await _collection.InsertOneAsync(customer);

                var ResultRepository = new ResultRepository<ObjectId>()
                {
                    Data = customer.Id,
                    Success = true
                };

                return ResultRepository;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                var ResultRepository = new ResultRepository<ObjectId>()
                {
                    Data =  ObjectId.Empty,
                    Success = true
                };

                return ResultRepository;
            }
        }
        public async Task<ResultRepository<bool>> UpdateCustomerAsync(ObjectId ObjectId, Customer Customer)
        {
            try
            {
                var filter = Builders<Customer>.Filter.Eq("_id", ObjectId);

                await _collection.ReplaceOneAsync(filter, Customer);

                var ResultRepository = new ResultRepository<bool>()
                {
                    Success = true,
                    Data = true
                };

                return ResultRepository;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                var ResultRepository = new ResultRepository<bool>()
                {
                    Success = false,
                    Message = ex.Message
                };

                return ResultRepository;
            }
        }
        public async Task<ResultRepository<bool>> DeleteAsync(ObjectId ObjectId)
        {
            try
            {
                var filter = Builders<Customer>.Filter.Eq("_id", ObjectId);

                await _collection.DeleteOneAsync(filter);

                var ResultRepository = new ResultRepository<bool>()
                {
                    Success = true,
                    Data = true
                };

                return ResultRepository;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                var ResultRepository = new ResultRepository<bool>()
                {
                    Success = false,
                    Message = ex.Message
                };

                return ResultRepository;
            }
        }
    }
}