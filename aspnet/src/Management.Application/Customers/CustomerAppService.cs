using Management;
using Managerment.CustomCodes;
using Managerment.CustomerTypes;
using Managerment.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace Managerment.Customers
{
    [RemoteService(IsEnabled = false)]
    public class CustomerAppService : ManagementAppService, ICustomerAppService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly CustomerManager _customerManager;
        private readonly CustomCodeAppService _customCodeAppService;

        public CustomerAppService(
            ICustomerRepository customerRepository,
            CustomerManager customerManager,
            CustomCodeAppService customCodeAppService)
        {
            _customerRepository = customerRepository;
            _customerManager = customerManager;
            _customCodeAppService = customCodeAppService;
        }
        public async Task<CustomerDto> CreateAsync(CreateUpdateCustomerDto input)
        {
            if (await _customerRepository.AnyAsync(x=> x.C_phone == input.C_phone))
            {
                throw new UserFriendlyException("Khách hàng đã tồn tại !! Hãy thử đặt tên khác");
            }
            else
            {
                try
                {
                    var productCode = await _customCodeAppService.GenerateCode("KH");

                    var customer = _customerManager.CreateAsync(productCode, input.C_name , input.C_phone, input.C_email, input.C_address, input.C_gender
                        , input.C_birthday, input.C_imageURL, input.Notes,input.Customer_type);

                    await _customerRepository.InsertAsync(customer);

                    await _customCodeAppService.UpdateAsync("KH");

                    return ObjectMapper.Map<Customer, CustomerDto>(customer);
                }
                catch (Exception ex)
                {
                    throw new UserFriendlyException("Something wrong!!!", ex.Message);
                }
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                await _customerRepository.DeleteAsync(id);
            }
            catch(Exception ex)
            {
                throw new BusinessException("Có lỗi xảy ra " + ex.Message);
            }

        }

        public async Task<CustomerDto> GetAsync(Guid id)
        {
            var customer = await _customerRepository.GetAsync(id);
            return ObjectMapper.Map<Customer, CustomerDto>(customer);
        }

        public async Task<ResultPageCustomerDto> GetListAsync(int page, int perPage, string filter, DateTime fromDate, DateTime toDate, ECustomerTypeEnum? customerTypeEnum)
        {
            var customers = await _customerRepository.GetListAsync(page, perPage, filter, fromDate, toDate , customerTypeEnum);

            var customersMap = ObjectMapper.Map<List<Customer>, List<CustomerListDto>>(customers.Item2);

            foreach (var customer in customersMap)
            {
                customer.Customer_type_name = EnumAppService.GetNameEnum<ECustomerTypeEnum>(customer.Customer_type); ;
            }
            int pageCout = customers.Item1 == 0 ? 0 : customers.Item1 / perPage + 1;

            return new ResultPageCustomerDto()
            {
                Count = customers.Item1,
                Page = page,
                Per_page = perPage,
                Total_pages = pageCout,
                Data = customersMap
            };
        }

        public async Task UpdateAsync(Guid id, CreateUpdateCustomerDto input)
        {
            var customer = await _customerRepository.GetAsync(id);

            customer.C_address = input.C_address;
            customer.C_birthday = input.C_birthday;
            customer.C_email = input.C_email;
            customer.C_gender = input.C_gender;
            customer.C_imageURL = input.C_imageURL;
            customer.C_name = input.C_name;
            customer.C_phone = input.C_phone;
            customer.Customer_type = input.Customer_type;

            await _customerRepository.UpdateAsync(customer);
        }
    }
}
