﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
        //productla ilgili veritabınında
        //yapılacak olan operasyonları
        //içeren interface !

    }
}
