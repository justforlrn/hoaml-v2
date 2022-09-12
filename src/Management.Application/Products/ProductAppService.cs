using Management;
using Managerment.Categories;
using Managerment.CustomCodes;
using Managerment.Manufacturers;
using Managerment.ProductConditions;
using Managerment.ProductUnits;
using Managerment.Suppliers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace Managerment.Products
{
    [RemoteService(IsEnabled = false)]
    public class ProductAppService : ManagementAppService, IProductAppService
    {
        private readonly IProductRepository _productRepository;
        private readonly ProductManager _productManager;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductUnitRepository _productUnitRepository;
        private readonly IProductConditionRepository _productConditionRepository;
        private readonly IManuFacturerRepository _manufacturerRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly CustomCodeAppService _customCodeAppService;
        private readonly ICustomCodeRepository _customCodeRepository;
        public ProductAppService(
            IProductRepository productRepository,
            ProductManager productManager,
            ICategoryRepository categoryRepository, 
            IProductUnitRepository productUnitRepository,
            IProductConditionRepository productConditionRepository,
            IManuFacturerRepository manufacturerRepositor,
            ISupplierRepository supplierRepository,
            CustomCodeAppService customCodeAppService,
            ICustomCodeRepository customCodeRepository)
        {
            _productRepository = productRepository;
            _productManager = productManager;
            _categoryRepository= categoryRepository;
            _productUnitRepository = productUnitRepository;
            _productConditionRepository = productConditionRepository;
            _manufacturerRepository = manufacturerRepositor;
            _supplierRepository = supplierRepository;
            _customCodeAppService = customCodeAppService;
            _customCodeRepository = customCodeRepository;
        }

        public async Task<ProductDto> CreateAsync(CreateUpdateProductDto input)
        {
            if (await _productRepository.AnyAsync(x => x.Pro_name.ToLower().Trim() == input.Pro_name.ToLower().Trim() && x.Pro_code == input.Pro_code))
            {
                throw new UserFriendlyException("Không được trùng mã code");
            }
            else
            {
                try
                {             
                    var productCode = input.Pro_code ?? await _customCodeAppService.GenerateCode("SP");

                    var product = _productManager.CreateAsync(input.Id_manu, input.Id_sup, input.Id_cat, input.Id_con, input.Id_unit, productCode, input.Pro_name, input.Pro_quanlity, input.Pro_min,
                    input.Pro_max, input.Pro_original_cost, input.Pro_sell_in, input.Pro_sell_out, input.Pro_warranty, input.Description, input.Is_inventory, input.Is_allownegative);

                    await _productRepository.InsertAsync(product);

                    await _customCodeAppService.UpdateAsync("SP");
                    
                    return ObjectMapper.Map<Product, ProductDto>(product);
                }
                catch (Exception ex)
                {
                    throw new UserFriendlyException("Something wrong!!!", ex.Message);
                }
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            await _productRepository.DeleteAsync(id);
        }

        public async Task<ProductDto> GetAsync(Guid id)
        {
            var product = await _productRepository.GetAsync(id);
            return ObjectMapper.Map<Product, ProductDto>(product);
        }

        public async Task<ResultPageProductDto> GetListAsync(int page, int perPage, string filter, Guid idCategory, Guid idProductCondition,  Guid idProductUnit , Guid idManuFacturer)
        {
            var listResult = new List<ListProductDto>();

            var products = await _productRepository.GetListAsync(page, perPage, filter, idCategory, idProductCondition, idProductUnit, idManuFacturer);
            
            var listCateId = products.Item2.Select(x => x.Id_cat).ToList();

            var categories = await _categoryRepository.GetListAsyncByListId(listCateId);
            
            foreach(var item in products.Item2)
            {
                var result = ObjectMapper.Map<Product, ListProductDto>(item);

                var categoryName = categories.Find(x => x.Id == item.Id_cat).Cat_name;

                result.Supplier_name = _supplierRepository.SingleOrDefaultAsync(x => x.Id == item.Id_sup).Result.Name;

                result.Condition_name = _productConditionRepository.SingleOrDefaultAsync(x => x.Id == item.Id_con).Result.Cond_name;

                result.Unit_name = _productUnitRepository.SingleOrDefaultAsync(x => x.Id == item.Id_unit).Result.Unit_name;

                result.Manufacturer_name = _manufacturerRepository.SingleOrDefaultAsync(x => x.Id == item.Id_manu).Result.Name;

                result.Category_name = categoryName;

                listResult.Add(result);
            }

            int pageCout = products.Item1 == 0 ? 0 : products.Item1 / perPage + 1;
            return new ResultPageProductDto()
            {
                Count = products.Item1,
                Page = page,
                Per_page = perPage,
                Total_pages =pageCout,
                Data = listResult,
            };
        }

        public async Task UpdateAsync(Guid id, CreateUpdateProductDto input)
        {
            var product = await _productRepository.GetAsync(id);

            product.Id_cat = input.Id_cat;
            product.Id_con = input.Id_con;
            product.Id_manu = input.Id_manu;
            product.Id_sup = input.Id_sup;
            product.Id_unit = input.Id_unit;
            product.Is_inventory = input.Is_inventory;
            product.Pro_max= input.Pro_max;
            product.Pro_min= input.Pro_min;
            product.Pro_sell_in = input.Pro_sell_in;
            product.Pro_sell_out = input.Pro_sell_out;
            product.Pro_warranty = input.Pro_warranty;
            product.Pro_name = input.Pro_name;


            await _productRepository.UpdateAsync(product);
        }
    }
}
