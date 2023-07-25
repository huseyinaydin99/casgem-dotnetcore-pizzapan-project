using Pizzapan.BusinessLayer.Abstarct;
using Pizzapan.DataAccessLayer.Abstract;
using Pizzapan.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzapan.BusinessLayer.Concrete
{
    public class OurTeamManager : IOurTeamService
    {
        private IOurTeamDal _ourTeamDal;

        public OurTeamManager(IOurTeamDal ourTeamDal)
        {
            _ourTeamDal = ourTeamDal;
        }

        public void TDelete(OurTeam t)
        {
            _ourTeamDal.Delete(t);
        }

        public OurTeam TGetByID(int id)
        {
            return _ourTeamDal.GetByID(id);
        }

        public List<OurTeam> TGetList()
        {
            return _ourTeamDal.GetList();
        }

        public void TInsert(OurTeam t)
        {
            _ourTeamDal.Insert(t);
        }

        public void TUpdate(OurTeam t)
        {
            _ourTeamDal.Update(t);
        }
    }
}