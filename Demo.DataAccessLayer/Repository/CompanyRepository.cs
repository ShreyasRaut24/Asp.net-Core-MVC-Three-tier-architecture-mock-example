
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
            //DB logic
            string connstring = "Server=.;Database=Demo;Integrated Security=True;TrustServerCertificate=True;";

            SqlConnection con = new SqlConnection(connstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("UpdateCompany", con);
            cmd.Parameters.AddWithValue("@CompanyId", company.Id);
            cmd.Parameters.AddWithValue("@CompanyName", company.CompanyName);
            cmd.Parameters.AddWithValue("@CompanyAddress", company.Address);
            cmd.CommandType = CommandType.StoredProcedure;
            var result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
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
            //DB logic
            string connstring = "Server=.;Database=Demo;Integrated Security=True;TrustServerCertificate=True;";

            SqlConnection con = new SqlConnection(connstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("GetById", con);
            cmd.Parameters.AddWithValue("@CompanyId", id);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sqlDataReader = cmd.ExecuteReader();

            Company company = new Company();

            while (sqlDataReader.Read())
            {
                return new Company
                {
                    Id = Convert.ToInt32(sqlDataReader["CompanyId"]),
                    CompanyName = sqlDataReader.GetString(1),
                    Address = sqlDataReader.GetString(2)
                };
            }
            return company;
        }

        public int Delete(int id)
        {
            //DB logic
            string connstring = "Server=.;Database=Demo;Integrated Security=True;TrustServerCertificate=True;";

            SqlConnection con = new SqlConnection(connstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("DeleteCompany", con);
            cmd.Parameters.AddWithValue("@CompanyId", id);
            cmd.CommandType = CommandType.StoredProcedure;
            var result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
