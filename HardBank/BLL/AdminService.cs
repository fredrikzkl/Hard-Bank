using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AdminService : IAdminService
    {

        private IAdminRepository _repository;

        public AdminService()
        {
            _repository = new AdminRepository();
        }

        public AdminService(IAdminRepository stub)
        {
            _repository = stub;
        }
    }
}
