

using Demo.BusinessLayer.Model;

namespace Demo.BusinessLayer.IRepository
{
    public interface ICompanyRepository
    {
        public int Create(Company company);
        public int Update(Company company);
        public List<Company> List();
        public Company GetById(int id);

        int Delete(int id);


    }
}
