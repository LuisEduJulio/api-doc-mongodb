using api_doc_mongodb.domain.Dtos;
using api_doc_mongodb.domain.Entities;
using api_doc_mongodb.domain.ModelView;
using api_doc_mongodb.utility.Utils;
using AutoMapper;

namespace api_doc_mongodb.infraestructure.Mapper
{
    public class MapperCustomerProfile : Profile
    {
        public MapperCustomerProfile()
        {
            CreateMap<CustomerCreateDto, Customer>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Age))
                .ForMember(dest => dest.Doc, opt => opt.MapFrom(src => src.Doc));

            CreateMap<Customer, CustomerCreatedModelView>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => HelpersObjectId.ConvertToObjectIdForString(src.Id)))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.DateCreated, opt => opt.MapFrom(src => DateTime.Now.ToString("d")));

            CreateMap<Customer, GetCustomersModelView>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => HelpersObjectId.ConvertToObjectIdForString(src.Id)))
               .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<CustomerUpdateDto, Customer>()
              .ForMember(dest => dest.Id, opt => opt.Ignore())
              .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
              .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
              .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
              .ForMember(dest => dest.Doc, opt => opt.MapFrom(src => src.Doc))
              .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Age))
              .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate));

            CreateMap<Customer, CustomerUpdateModelView>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => HelpersObjectId.ConvertToObjectIdForString(src.Id)))
              .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
              .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
              .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
              .ForMember(dest => dest.Doc, opt => opt.MapFrom(src => src.Doc))
              .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Age))
              .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate));
        }
    }
}