using OrgOffering.Data;
using OrgOffering.Models;
using System.Collections.Generic;
using System.Linq;


namespace OrgOffering.Repository
{
    public class ProductRepository
    {

        protected readonly OferringDBContext _context = new OferringDBContext();

        // GET ALL: Products   
        public IEnumerable<Product> GetAll()
        {
            return _context.Product.ToList();
        }

        // TO DO: Add ‘Get By Id’


        // TO DO: Add ‘Create’
        // TO DO: Add ‘Edit’
        // TO DO: Add ‘Delete’
        // TO DO: Add ‘Exists’
        public Product GetById(int id)
        {
            return _context.Product.FirstOrDefault(p => p.ProductId == id);
        }
        public void Create(Product product)
        {
            _context.Product.Add(product);
            _context.SaveChanges();
        }
        public void Edit(Product product)
        {
            var existingProduct = _context.Product.Find(product.ProductId);
            if (existingProduct != null)
            {
                // Update the properties of the existing product with the new values
                existingProduct.ProductName = product.ProductName;
                existingProduct.ProductDescription = product.ProductDescription;
                existingProduct.CreatedDate = product.CreatedDate;
                

                _context.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            var product = _context.Product.Find(id);
            if (product != null)
            {
                _context.Product.Remove(product);
                _context.SaveChanges();
            }
        }
        public bool Exists(int id)
        {
            return _context.Product.Any(p => p.ProductId == id);
        }




    }

}

