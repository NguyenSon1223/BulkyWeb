﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models.Models;

namespace Bulky.DataAccess.Repository
{
    public class ProductRepository : Repository<Product> , IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository (ApplicationDbContext db) : base (db)
        {
            _db = db;
        }

        public void Update(Product obj)
        {
            _db.Update(obj);
        }
    }
}
