using MySql.Data.MySqlClient;

namespace PKDSA_ServerApp.Helper
{
    public class MyOwnMySQLConnection
    {
        public MySqlConnection MyMySQLConnection = new MySqlConnection();
        public Boolean CheckConnection;
        //The credentials text file should have the credentials with this format
        //server=localhost;port=3306;database=<database_name>;user=<database_user>;password=<database_user_password>;
        public String SecretPath = "<Path to database credentials>";
        public String ConnectionString = "";

        public void setConnection() {
            using (StreamReader SecretPathReader = new StreamReader(SecretPath))
            {
                while ((ConnectionString = SecretPathReader.ReadLine()) != null)
                {
                    MyMySQLConnection.ConnectionString = ConnectionString;
                }
            }
        }

        public Boolean LoadConnection(ref String Exception) {
            setConnection();
            try
            {
                MyMySQLConnection.Open();
                CheckConnection = true;
            }
            catch (MySqlException exception){
                CheckConnection = false;
                Exception = exception.ToString();
            }
            return CheckConnection;
        }
    }
}
