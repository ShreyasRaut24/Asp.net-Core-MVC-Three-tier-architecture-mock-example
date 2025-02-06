
using Demo.BusinessLayer.IRepository;
using Demo.BusinessLayer.Model;
using Microsoft.Data.SqlClient;

namespace Demo.DataAccessLayer.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        public int Create(Company company)
        {
            //DB logic
            SqlConnection con = new SqlConnection();
            return 1;
        }
        public int Update(Company company)
        {
            return 1;
        }

        public List<Company> List()
        {
            return new List<Company>();
        }

        public Company GetById(int id)
        {
            return new Company();
        }
    }
}
