﻿using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        //liste class'ın içinde ama methodların dışında
        // bu tip değişkenlere o class için global olur
        //bu yüzden alt çizgiyle yazılır.
        List<Product> _products;

        public InMemoryProductDal()
        {
            _products = new List<Product> {
                new Product{ProductId=1, CategoryId=1, ProductName="Bardak",UnitPrice=15,UnitsInStock=15},
                new Product{ProductId=2, CategoryId=1, ProductName="Kamera",UnitPrice=500,UnitsInStock=3},
                new Product{ProductId=3, CategoryId=2, ProductName="Telefon",UnitPrice=1500,UnitsInStock=2},
                new Product{ProductId=4, CategoryId=2, ProductName="Klavye",UnitPrice=150,UnitsInStock=65},
                new Product{ProductId=5, CategoryId=2, ProductName="Fare",UnitPrice=85,UnitsInStock=1}

            };
                
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = null; //referansı yok
            //LINQ => Language Integrated Query
            //foreach (var p in _products)
            //{
            //    if (product.ProductId == p.ProductId)
            //    {
            //        productToDelete = p;
            //    }

            //}
            //C# 7.gün 2:20:48 !
            productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId); //lambda
                                        //bu sinlge kodu yukarıdaki foreach'i yapar
                                        //p iterate için alyans !


            _products.Remove(productToDelete);

        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<ProductDetailDto> GetProcutDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {   //gönderdiğim ürün Id'sine sahip olan listedeki ürünü bul
            Product productToUpdate = _products.SingleOrDefault(p=> product.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitsInStock = product.UnitsInStock;
            productToUpdate.UnitPrice = product.UnitPrice;
        }
    }
}
