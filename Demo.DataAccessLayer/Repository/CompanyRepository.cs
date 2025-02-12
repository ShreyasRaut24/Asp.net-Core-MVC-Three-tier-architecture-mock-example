
using System.Data;
using System.Runtime.InteropServices;
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
             string connstring = "Server=.;Database=Demo;Integrated Security=True;TrustServerCertificate=True;";

            SqlConnection con = new SqlConnection(connstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("CreateCompany",con);
            cmd.Parameters.AddWithValue("@CompanyName", company.CompanyName);
            cmd.Parameters.AddWithValue("@CompanyAddress", company.Address);
            cmd.CommandType = CommandType.StoredProcedure;
            var result= cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int Update(Company company)
        {
            return 1;
        }

        public List<Company> List()
        {
            //DB logic
            string connstring = "Server=.;Database=Demo;Integrated Security=True;TrustServerCertificate=True;";

            SqlConnection con = new SqlConnection(connstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("GetCompanies", con);
            SqlDataReader sqlDataReader = cmd.ExecuteReader();

            var companies = new List<Company>();

            while (sqlDataReader.Read())
            {
                Company company = new Company();
                company.Id = Convert.ToInt32(sqlDataReader["CompanyId"]);
                company.CompanyName = sqlDataReader.GetString(1);
                company.Address = sqlDataReader.GetString(2);
                companies.Add(company);

            }
            return companies;
        }

        public Company GetById(int id)
        {
            return new Company();
        }
    }
}
