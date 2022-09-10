using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            //Oracle,Sql Server,Postgres,MongoDb 'den geliyormuscasına
            _products = new List<Product>
            {
                new Product{ProductName="Kalem",ProductId=1,UnitInStock=15,UnitPrice=15,CategoryId=1},
                new Product{ProductName="Kask",ProductId=2,UnitInStock=3,UnitPrice=500,CategoryId=1},
                new Product{ProductName="Ceket",ProductId=3,UnitInStock=2,UnitPrice=1500,CategoryId=2},
                new Product{ProductName="Laptop",ProductId=4,UnitInStock=65,UnitPrice=155,CategoryId=2},
                new Product{ProductName="Televizyon",ProductId=5,UnitInStock=1,UnitPrice=85,CategoryId=2},
            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {

            //LINQ - Language Integrated Query
            //eğer linq olmasa alttaki kodu kullanırdık;

            //Product productToDelete = null;
            //foreach (var p in _products)
            //{
            //    if (product.ProductId == p.ProductId)
            //    {
            //        productToDelete = p;
            //    }
            //}

            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId == product.ProductId );  //bu satırdaki kod foreach yerine geçer.
            _products.Remove(productToDelete);



        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p=> p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            //gonderdigim urun idsine sahip listedeki ürünü bul
            Product productToUpdate= _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitInStock = product.UnitInStock;
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice = product.UnitPrice;
            
        }
    }
}
