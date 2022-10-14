using System.Data.SqlClient;

namespace AzureWebappServiceSqlSample.Service
{
    public class EmployeeContext
    {
        private static string db_source = "soujanya.database.windows.net";
        private static string db_user = "testadmin";
        private static string db_password = "Sowji1234$";
        private static string db_databasename = "sowji123";

        public SqlConnection GetConnection()
        {
            var _builder = new SqlConnectionStringBuilder();
            _builder.DataSource = db_source;
            _builder.UserID = db_user;
            _builder.Password = db_password;
            _builder.InitialCatalog = db_databasename;
            return new SqlConnection(_builder.ConnectionString);

        }

        public List<Employee> GetEmployees()
        {
            SqlConnection con = GetConnection();
            List<Employee> _employee = new List<Employee>();
            string sql = "Select * from Employee";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Employee employee = new Employee()
                {
                    Id = reader.GetInt32(0),
                    name = reader.GetString(1),
                    salary = reader.GetString(2),
                    gender = reader.GetString(3),
                    place = reader.GetString(4)


                };
                _employee.Add(employee);
            }
            return _employee;
        }

    }
}
