using Pizzapan.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzapan.BusinessLayer.Abstarct
{
    public interface IContactService : IGenericService<Contact>
    {
        List<Contact> TGetContactBySubjectWithThanks();
    }
}
