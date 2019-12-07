using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DropDownList
{
    public interface IStream
    {
        IEnumerable<Tuple<string, int>> IterRowsUnivers();
        IEnumerable<Tuple<string, string>> IterRowsInfor(string univer);
        string GetNameUniver(int index);
        string CreateSynonum(string nameUniversity, string Synonum);
    }
    public class SqlConn:IStream
    {
        string stringConn = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Pooling=False";
                
        public IEnumerable<Tuple<string, int>> IterRowsUnivers()
        {
            string query = "SELECT name, 0 FROM universities UNION SELECT name, id_university FROM synonum";
            using (SqlConnection connection = new SqlConnection(stringConn))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return new Tuple<string,int>(reader.GetString(0),(int)reader[1]);
                        }
                    }
                }
            }
        }
        public IEnumerable<Tuple<string,string>> IterRowsInfor(string univer)
        {
            string query = string.Format("SELECT countries.name, universities.url FROM countries INNER JOIN universities ON universities.name = '{0}' AND countries.id = universities.country_id", univer);
            using (SqlConnection connection = new SqlConnection(stringConn))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return new Tuple<string,string>(reader.GetString(0), reader.GetString(1));
                        }
                    }
                }
            }
        }
        public string CreateSynonum(string nameUniversity, string Synonum)
        {
            string query = string.Format("INSERT INTO dbo.synonum (name, id_university) VALUES  ('{0}', (SELECT id FROM universities WHERE universities.name = '{1}'))", Synonum, nameUniversity);
            using (SqlConnection connection = new SqlConnection(stringConn))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        return "Success " + "Rows: " + command.ExecuteNonQuery().ToString();
                    }
                    catch (SqlException ex)
                    {
                        return "Failure: " + ex.Message;
                    }
                }
            }
        }
        public string GetNameUniver(int index)
        {
            string query = string.Format("SELECT name FROM universities WHERE id = {0}",index);
            using (SqlConnection connection = new SqlConnection(stringConn))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        return reader.GetString(0); 
                    }
                }
            }
        }
    }
}
