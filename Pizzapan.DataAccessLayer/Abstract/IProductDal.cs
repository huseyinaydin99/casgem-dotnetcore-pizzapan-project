﻿using Pizzapan.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzapan.DataAccessLayer.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
        public List<Product> GetProductsWithCategory();
    }
}