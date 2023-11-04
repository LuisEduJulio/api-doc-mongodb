using api_doc_mongodb.application.Services;
using api_doc_mongodb.domain.Entities;
using api_doc_mongodb.domain.ModelView;
using api_doc_mongodb.domain.Repositories;
using api_doc_mongodb.domain.Results;
using api_doc_mongodb.infraestructure.Repositories;
using api_doc_mongodb.test.Domain.Dtos;
using api_doc_mongodb.test.Domain.Entities;
using api_doc_mongodb.utility.Utils;
using AutoMapper;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using Moq;

namespace api_doc_mongodb.test.Application.Service
{
    public class CustomerServiceTests
    {
        private readonly Mock<ILogger<CustomerService>> _loggerMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<ICustomerRepository> _customerRepositoryMock;
        private readonly Mock<IEmailSenderRepository> _emailSenderRepositoryMock;
        private readonly CustomerService _customerServiceMock;
        public CustomerServiceTests()
        {
            _loggerMock = new Mock<ILogger<CustomerService>>();
            _mapperMock = new Mock<IMapper>();
            _customerRepositoryMock = new Mock<ICustomerRepository>();
            _emailSenderRepositoryMock = new Mock<IEmailSenderRepository>();

            _customerServiceMock = new CustomerService(_loggerMock.Object,
                _mapperMock.Object,
                _customerRepositoryMock.Object,
                _emailSenderRepositoryMock.Object);
        }
        [Fact(DisplayName = "GetByObjectIdAsync: customer exist return valid result")]
        public async Task GetByObjectIdAsync_CustomerExists_ReturnsValidResult()
        {
            // Arrange
            var customerService = new CustomerService(_loggerMock.Object,
                _mapperMock.Object,
                _customerRepositoryMock.Object,
                _emailSenderRepositoryMock.Object);

            var customerEntity = new CustomerEntityFixture().CustomerEntityMock();
            var getCustomersModelView = new GetCustomersModelView();

            _customerRepositoryMock
                .Setup(r => r.GetCustomerByObjectIdAsync(customerEntity.Id))
                    .ReturnsAsync(new ResultRepository<CustomerEntity>
                    {
                        Success = true,
                        Data = customerEntity
                    });

            _mapperMock
                .Setup(m => m.Map<GetCustomersModelView>(customerEntity))
                .Returns(getCustomersModelView);

            var objectIdString = HelpersObjectId.ConvertToObjectIdForString(customerEntity.Id);

            // Act
            var result = await _customerServiceMock.GetByObjectIdAsync(objectIdString);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(getCustomersModelView, result.Data);
            Assert.Null(result.Message);
        }
        [Fact(DisplayName = "GetByObjectIdAsync: customer exist return valid message result")]
        public async Task GetByObjectIdAsync_CustomerExists_ReturnsValidMessageResult()
        {
            // Arrange
            var customerService = new CustomerService(_loggerMock.Object,
                _mapperMock.Object,
                _customerRepositoryMock.Object,
                _emailSenderRepositoryMock.Object);

            var customerEntity = new CustomerEntityFixture().CustomerEntityMock();
            var getCustomersModelView = new GetCustomersModelView();

            _customerRepositoryMock
                .Setup(r => r.GetCustomerByObjectIdAsync(customerEntity.Id))
                    .ReturnsAsync(new ResultRepository<CustomerEntity>
                    {
                        Success = true,
                        Data = customerEntity,
                        Message = "Client Exist!"
                    });

            _mapperMock
                .Setup(m => m.Map<GetCustomersModelView>(customerEntity))
                .Returns(getCustomersModelView);

            var objectIdString = HelpersObjectId.ConvertToObjectIdForString(customerEntity.Id);

            // Act
            var result = await _customerServiceMock.GetByObjectIdAsync(objectIdString);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(getCustomersModelView, result.Data);
            Assert.Equal("Client Exist!", result.Message);
        }
        [Fact(DisplayName = "GetByObjectIdAsync: customer not exist return invalid result")]
        public async Task GetByObjectIdAsync_CustomerNotExists_ReturnsInValidResult()
        {
            // Arrange
            var customerService = new CustomerService(_loggerMock.Object,
                _mapperMock.Object,
                _customerRepositoryMock.Object,
                _emailSenderRepositoryMock.Object);

            var customerEntity = new CustomerEntityFixture().CustomerEntityMock();
            var getCustomersModelView = new GetCustomersModelView();

            _customerRepositoryMock
                .Setup(r => r.GetCustomerByObjectIdAsync(customerEntity.Id))
                    .ReturnsAsync(new ResultRepository<CustomerEntity>
                    {
                        Success = false,
                        Data = null
                    });

            _mapperMock
                .Setup(m => m.Map<GetCustomersModelView>(customerEntity))
                .Returns(getCustomersModelView);

            var objectIdString = HelpersObjectId.ConvertToObjectIdForString(customerEntity.Id);

            // Act
            var result = await _customerServiceMock.GetByObjectIdAsync(objectIdString);

            // Assert
            Assert.False(result.Success);
            Assert.Null(result.Data);
            Assert.Equal("Customer Not Exist!", result.Message);
        }
        [Fact(DisplayName = "GetCustomersAsync: customers exists returns valid result")]
        public async Task GetCustomersAsync_CustomersExists_ReturnsValidResult()
        {
            // Arrange
            var customerService = new CustomerService(
                _loggerMock.Object,
                _mapperMock.Object,
                _customerRepositoryMock.Object,
                _emailSenderRepositoryMock.Object
            );

            var customerEntityList = new CustomerEntityFixture().CustomerEntityListMock();

            var getCustomersModelViewList = new List<GetCustomersModelView>();

            foreach (var customerEntity in customerEntityList)
            {
                var GetCustomersModelView = new GetCustomersModelView()
                {
                    Id = customerEntity.Id.ToString(),
                    Name = customerEntity.Name,
                    Email = customerEntity.Email
                };

                getCustomersModelViewList.Add(GetCustomersModelView);
            }

            _customerRepositoryMock
                .Setup(r => r.GetListAsync())
                .ReturnsAsync(new ResultRepository<List<CustomerEntity>>
                {
                    Success = true,
                    Data = customerEntityList
                });

            foreach (var customerEntity in customerEntityList)
            {
                _=_mapperMock
                    .Setup(m => m.Map<GetCustomersModelView>(customerEntity))
                    .Returns(getCustomersModelViewList.Find(c => c.Id == customerEntity.Id.ToString()));
            }

            // Act
            var result = await customerService.CustomerAllAsync();

            // Assert
            Assert.True(result.Success);
            Assert.Null(result.Message);
            Assert.Equal(getCustomersModelViewList, result.Data);
        }
        [Fact(DisplayName = "GetCustomersAsync: customers not exists returns valid result")]
        public async Task GetCustomersAsync_CustomersNotExists_ReturnsValidResult()
        {
            // Arrange
            var customerService = new CustomerService(
                _loggerMock.Object,
                _mapperMock.Object,
                _customerRepositoryMock.Object,
                _emailSenderRepositoryMock.Object
            );

            var customerEntityList = new List<CustomerEntity>();

            var getCustomersModelViewList = new List<GetCustomersModelView>();

            _customerRepositoryMock
                .Setup(r => r.GetListAsync())
                .ReturnsAsync(new ResultRepository<List<CustomerEntity>>
                {
                    Success = true,
                    Data = customerEntityList
                });

            // Act
            var result = await customerService.CustomerAllAsync();

            // Assert
            Assert.True(result.Success);
            Assert.Null(result.Message);
            Assert.False(getCustomersModelViewList.Any());
            Assert.False(result.Data.Any());
            Assert.Equal(getCustomersModelViewList, result.Data);
        }
        [Fact(DisplayName = "CreateCustomerAsync: return valid result")]
        public async Task CreateCustomerAsync_ReturnValidResult()
        {
            // Arrange
            var customerService = new CustomerService(
                _loggerMock.Object,
                _mapperMock.Object,
                _customerRepositoryMock.Object,
                _emailSenderRepositoryMock.Object
            );

            var customerEntity = new CustomerEntity();
            var customerCreateDto = new CustomerCreateDtoFixture().CustomerCreateDtoMock();
            var emailEntity = new EmailEntityFixture().EmailEntityMock();
            var CustomerCreatedModelView = new CustomerCreatedModelView();
            var objectId = new ObjectId();

            _customerRepositoryMock
                .Setup(r => r.InsertAsync(customerEntity))
                .ReturnsAsync(new ResultRepository<ObjectId>()
                {
                    Data = objectId,
                    Success = true
                });

            _customerRepositoryMock
                .Setup(r => r.GetCustomerByObjectIdAsync(objectId))
                .ReturnsAsync(new ResultRepository<CustomerEntity>()
                {
                    Data = customerEntity,
                    Success = true
                });

            _emailSenderRepositoryMock
                .Setup(e => e.SendEmailAsync(emailEntity, "Novo Cliente!"))
                .ReturnsAsync(true);

            _mapperMock
                .Setup(m => m.Map<CustomerCreatedModelView>(customerEntity))
                .Returns(CustomerCreatedModelView);

            _mapperMock
                .Setup(m => m.Map<CustomerEntity>(customerCreateDto))
                .Returns(customerEntity);

            // Act
            var result = await customerService.PostCreateCustomerAsync(customerCreateDto);

            // Assert
            Assert.True(result.Success);
            Assert.Null(result.Message);
            Assert.Equal(CustomerCreatedModelView, result.Data);
        }
        [Fact(DisplayName = "CreateCustomerAsync: customer not creater return in valid result")]
        public async Task CreateCustomerAsync_CustomerNotCreater_ReturnInValidResult()
        {
            // Arrange
            var customerService = new CustomerService(
                _loggerMock.Object,
                _mapperMock.Object,
                _customerRepositoryMock.Object,
                _emailSenderRepositoryMock.Object
            );

            var customerEntity = new CustomerEntity();
            var customerCreateDto = new CustomerCreateDtoFixture().CustomerCreateDtoMock();
            var CustomerCreatedModelView = new CustomerCreatedModelView();
            var objectId = ObjectId.Empty;

            _customerRepositoryMock
                .Setup(r => r.InsertAsync(customerEntity))
                .ReturnsAsync(new ResultRepository<ObjectId>()
                {
                    Data = objectId,
                    Success = false
                });

            _mapperMock
                .Setup(m => m.Map<CustomerCreatedModelView>(customerEntity))
                .Returns(CustomerCreatedModelView);

            _mapperMock
                .Setup(m => m.Map<CustomerEntity>(customerCreateDto))
                .Returns(customerEntity);

            // Act
            var result = await customerService.PostCreateCustomerAsync(customerCreateDto);

            // Assert
            Assert.False(result.Success);
            Assert.Null(result.Message);
            Assert.Null(result.Data);
        }
        [Fact(DisplayName = "UpdateCustomerAsync: return valid result")]
        public async Task UpdateCustomerAsync_ReturnValidResult()
        {
            // Arrange
            var customerService = new CustomerService(
                _loggerMock.Object,
                _mapperMock.Object,
                _customerRepositoryMock.Object,
                _emailSenderRepositoryMock.Object
            );

            var customerEntity = new CustomerEntityFixture().CustomerEntityMock();
            var customerUpdateDto = new CustomerUpdateDtoFixture().CustomerUpdateDtoMock();
            customerEntity.Id = ObjectId.GenerateNewId();
            var objectIdString = HelpersObjectId.ConvertToObjectIdForString(customerEntity.Id);

            _mapperMock
               .Setup(m => m.Map<CustomerEntity>(customerUpdateDto))
               .Returns(customerEntity);

            _customerRepositoryMock
                .Setup(r => r.UpdateCustomerAsync(customerEntity.Id, customerEntity))
                .ReturnsAsync(new ResultRepository<bool>()
                {
                    Data = true,
                    Success = true
                });

            // Act
            var result = await customerService.UpdateCreateCustomerAsync(objectIdString, customerUpdateDto);

            // Assert
            Assert.True(result.Success);
            Assert.Null(result.Message);
            Assert.True(result.Data);
        }
        [Fact(DisplayName = "UpdateCustomerAsync: objectId ivalid return invalid result")]
        public async Task UpdateCustomerAsync_ObjectIdInvalid_ReturnValidResult()
        {
            // Arrange
            var customerService = new CustomerService(
                _loggerMock.Object,
                _mapperMock.Object,
                _customerRepositoryMock.Object,
                _emailSenderRepositoryMock.Object
            );

            var customerEntity = new CustomerEntityFixture().CustomerEntityMock();
            var customerUpdateDto = new CustomerUpdateDtoFixture().CustomerUpdateDtoMock();
            customerEntity.Id = ObjectId.Empty;
            var objectIdString = HelpersObjectId.ConvertToObjectIdForString(customerEntity.Id);

            _mapperMock
               .Setup(m => m.Map<CustomerEntity>(customerUpdateDto))
               .Returns(customerEntity);

            _customerRepositoryMock
                .Setup(r => r.UpdateCustomerAsync(customerEntity.Id, customerEntity))
                .ReturnsAsync(new ResultRepository<bool>()
                {
                    Data = false,
                    Success = false
                });

            // Act
            var result = await customerService.UpdateCreateCustomerAsync(objectIdString, customerUpdateDto);

            // Assert
            Assert.False(result.Success);
            Assert.Equal("ObjectId not Exist!", result.Message);
            Assert.False(result.Data);
        }
        [Fact(DisplayName = "DeleteAsync: return valid result")]
        public async Task DeleteAsync_ReturnValidResult()
        {
            // Arrange
            var customerService = new CustomerService(
                _loggerMock.Object,
                _mapperMock.Object,
                _customerRepositoryMock.Object,
                _emailSenderRepositoryMock.Object
            );

            var customerEntity = new CustomerEntityFixture().CustomerEntityMock();
            customerEntity.Id = ObjectId.GenerateNewId();
            var objectIdString = HelpersObjectId.ConvertToObjectIdForString(customerEntity.Id);

            _customerRepositoryMock
                .Setup(r => r.DeleteAsync(customerEntity.Id))
                .ReturnsAsync(new ResultRepository<bool>()
                {
                    Data = true,
                    Success = true
                });

            // Act
            var result = await customerService.DeleteCustomerByObjectIdAsync(objectIdString);

            // Assert
            Assert.True(result.Success);
            Assert.Null(result.Message);
            Assert.True(result.Data);
        }
        [Fact(DisplayName = "DeleteAsync: objectId invalid return valid result")]
        public async Task DeleteAsync_ObjectIdInvalid_ReturnValidResult()
        {
            // Arrange
            var customerService = new CustomerService(
                _loggerMock.Object,
                _mapperMock.Object,
                _customerRepositoryMock.Object,
                _emailSenderRepositoryMock.Object
            );

            var customerEntity = new CustomerEntityFixture().CustomerEntityMock();
            customerEntity.Id = ObjectId.Empty;
            var objectIdString = HelpersObjectId.ConvertToObjectIdForString(customerEntity.Id);

            _customerRepositoryMock
                .Setup(r => r.DeleteAsync(customerEntity.Id))
                .ReturnsAsync(new ResultRepository<bool>()
                {
                    Data = true,
                    Success = true
                });

            // Act
            var result = await customerService.DeleteCustomerByObjectIdAsync(objectIdString);

            // Assert
            Assert.False(result.Success);
            Assert.Equal("ObjectId not Exist!", result.Message);
            Assert.False(result.Data);
        }
    }
}