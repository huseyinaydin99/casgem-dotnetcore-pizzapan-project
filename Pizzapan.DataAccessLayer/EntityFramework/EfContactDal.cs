﻿using Pizzapan.DataAccessLayer.Abstract;
using Pizzapan.DataAccessLayer.Concrete;
using Pizzapan.DataAccessLayer.Repositories;
using Pizzapan.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzapan.DataAccessLayer.EntityFramework
{
    public class EfContactDal : GenericRepository<Contact>, IContactDal
    {
        public List<Contact> GetContactBySubjectWithThanks()
        {
            using var context = new Context();
            var values = context.Contacts.Where(x => x.Subject == "Thanks").ToList();
            return values;
        }
    }
}