using MySql.Data.MySqlClient;

namespace PKDSA_ServerApp.Helper
{
    public class MyOwnMySQLConnection
    {
        public MySqlConnection MyMySQLConnection = new MySqlConnection();
        public Boolean CheckConnection;
        public String SecretPath = "<Path to MySQL full connection/credential string>";
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
