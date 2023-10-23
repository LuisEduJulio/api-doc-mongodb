using api_doc_mongodb.domain.Dtos;
using api_doc_mongodb.domain.Entities;
using api_doc_mongodb.domain.ModelView;
using api_doc_mongodb.domain.Repositories;
using api_doc_mongodb.domain.Results;
using api_doc_mongodb.domain.Services;
using api_doc_mongodb.utility.Utils;
using AutoMapper;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;

namespace api_doc_mongodb.application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ILogger<CustomerService> _logger;
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(
            ILogger<CustomerService> logger,
            IMapper mapper,
            ICustomerRepository customerRepository
            )
        {
            _logger = logger;
            _mapper = mapper;
            _customerRepository = customerRepository;
        }
        public async Task<ResultService<GetCustomersModelView>> GetByObjectIdAsync(string ObjectId)
        {
            var ResultService = new ResultService<GetCustomersModelView>();

            var objectId = HelpersObjectId.ConvertToStringForObjectId(ObjectId);

            var ResultRepository = await _customerRepository.GetCustomerByObjectIdAsync(objectId);

            if (!ResultRepository.Success)
            {
                ResultService.Success = ResultRepository.Success;
                ResultService.Message = ResultRepository.Message;

                return ResultService;
            }

            var GetCustomersModelView = _mapper.Map<GetCustomersModelView>(ResultRepository.Data);

            ResultService.Success = ResultRepository.Success;
            ResultService.Message = ResultRepository.Message;
            ResultService.Data = GetCustomersModelView;

            return ResultService;
        }
        public async Task<ResultService<List<GetCustomersModelView>>> CustomerAllAsync()
        {
            var ResultService = new ResultService<List<GetCustomersModelView>>();

            var GetCustomersModelViewList = new List<GetCustomersModelView>();

            var ResultRepository = await _customerRepository.GetListAsync();

            if (!ResultRepository.Success)
            {
                ResultService.Success = ResultRepository.Success;
                ResultService.Message = ResultRepository.Message;

                return ResultService;
            }

            foreach (var customer in ResultRepository.Data)
            {
                var GetCustomersModelView = _mapper.Map<GetCustomersModelView>(customer);

                GetCustomersModelViewList.Add(GetCustomersModelView);
            }

            ResultService.Success = ResultRepository.Success;
            ResultService.Message = ResultRepository.Message;
            ResultService.Data = GetCustomersModelViewList;

            return ResultService;
        }
        public async Task<ResultService<CustomerCreatedModelView>> PostCreateCustomerAsync(CustomerCreateDto customerAddDto)
        {
            var ResultService = new ResultService<CustomerCreatedModelView>();

            var Customer = _mapper.Map<Customer>(customerAddDto);

            var ResultRepository = await _customerRepository.InsertAsync(Customer);

            if (!ResultRepository.Success && !ResultRepository.Success)
            {
                ResultService.Success = ResultRepository.Success;
                ResultService.Message = ResultRepository.Message;

                return ResultService;
            }

            var newCustomer = await _customerRepository.GetCustomerByObjectIdAsync(ResultRepository.Data);

            if (!newCustomer.Success)
            {
                ResultService.Success = ResultRepository.Success;
                ResultService.Message = ResultRepository.Message;

                return ResultService;
            }

            var CustomerCreatedModelView = _mapper.Map<CustomerCreatedModelView>(newCustomer.Data);

            ResultService.Success = ResultRepository.Success;
            ResultService.Message = ResultRepository.Message;
            ResultService.Data = CustomerCreatedModelView;

            return ResultService;
        }
        public async Task<ResultService<bool>> UpdateCreateCustomerAsync(string ObjectId, CustomerUpdateDto customerUpdateDto)
        {
            var ResultService = new ResultService<bool>();

            var customer = _mapper.Map<Customer>(customerUpdateDto);

            var objectId = HelpersObjectId.ConvertToStringForObjectId(ObjectId);

            customer.Id = objectId;

            var ResultRepository = await _customerRepository.UpdateCustomerAsync(objectId, customer);

            if (!ResultRepository.Success && !ResultRepository.Success)
            {
                ResultService.Success = ResultRepository.Success;
                ResultService.Message = ResultRepository.Message;

                return ResultService;
            }
           
            ResultService.Success = ResultRepository.Success;
            ResultService.Message = ResultRepository.Message;
            ResultService.Data = ResultRepository.Data;

            return ResultService;
        }
        public Task<ResultService<bool>> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
