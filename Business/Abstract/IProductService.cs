using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll(); //hem işlem sonucunu hem mesajı hem de döndüreceği şeyi içeren bir yapı görevi görecek
        IDataResult<List<Product>> GetAllByCategoryId(int id);
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IDataResult<Product> GetById(int productId); //tek başına bir ürün döndürür.
        IResult Add(Product product); //bu yapı mesaj ve işlem sonucu içerir.
        IResult Update(Product product);
        IResult AddTransactionalTest(Product product);
    }
}
