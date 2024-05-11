using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Business.Abstract;
using Project.Data.Entities;
using Project.DataAccess.Concrete;
using Project.DTO.ProductDTO;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var productList = _mapper.Map<List<ResultProductDTO>>(_productService.TGetAll());
            return Ok(productList);
        }

        [HttpGet("PRODUCT_LIST_WITH_CATEGORY")]
        public IActionResult ProductListWithCategory()
        {
            var context = new SignalRContext();
            var productListByCategory =
                //_mapper.Map<List<ResultProductWithCategoryDTO>>(_productService.TGetProductsByCategory());
                context.Products.Include(p => p.Category).Select(c => new ResultProductWithCategoryDTO
                {
                    ProductId = c.ProductId,
                    ProductName = c.ProductName,
                    ProductDescription = c.ProductDescription,
                    ProductPrice = c.ProductPrice,
                    ProductImageURL = c.ProductImageURL,
                    ProductStatus = c.ProductStatus,
                    CategoryName = c.Category.CategoryName
                }).ToList();

            return Ok(productListByCategory.ToList());
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDTO createProductDTO)
        {
            _productService.TAdd(new Product()
            {
                ProductName = createProductDTO.ProductName,
                ProductDescription = createProductDTO.ProductDescription,
                ProductPrice = createProductDTO.ProductPrice,
                ProductImageURL = createProductDTO.ProductImageURL,
                CategoryId = createProductDTO.CategoryId,
                ProductStatus = createProductDTO.ProductStatus
            });
            return Ok("Ürün Eklendi!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _productService.TGetById(id);
            _productService.TDelete(product);
            return Ok("Ürün Silindi!");
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDTO updateProductDTO)
        {
            _productService.TUpdate(new Product()
            {
                ProductId = updateProductDTO.ProductId,
                ProductName = updateProductDTO.ProductName,
                ProductDescription = updateProductDTO.ProductDescription,
                ProductPrice = updateProductDTO.ProductPrice,
                ProductImageURL = updateProductDTO.ProductImageURL,
                CategoryId = updateProductDTO.CategoryId,
                ProductStatus = updateProductDTO.ProductStatus
            });
            return Ok("Ürün Güncellendi!");
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _productService.TGetById(id);
            return Ok(product);
        }
    }
}
