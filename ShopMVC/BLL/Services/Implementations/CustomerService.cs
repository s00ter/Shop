using AutoMapper;
using BLL.Dto;
using BLL.Services.Abstractions;
using DAL.Entities;
using DAL.Repositories.Abstractions;

namespace BLL.Services.Implementations;

public class CustomerService : ServiceBase<ICustomerRepository, int, CustomerDto, Customer>, ICustomerService
{
    public CustomerService(ICustomerRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}