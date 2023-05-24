using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PKDSA_ServerApp.Helper;
using MySql.Data.MySqlClient;
using ASodium;

namespace PKDSA_ServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPublicKeyDigest : ControllerBase
    {
        private MyOwnMySQLConnection myMyOwnMySQLConnection = new MyOwnMySQLConnection();

        [HttpGet]
        public String ComputeAndDisplayMasterKeyDigest(String User_ID) 
        {
            MySqlCommand MySQLGeneralQuery = new MySqlCommand();
            String ExceptionString = "";
            int UserIDChecker = 0;
            String Base64UserMasterPK = "";
            Byte[] UserMasterPK = new Byte[] { };
            Byte[] UserMasterPKDigest = new Byte[] { };
            myMyOwnMySQLConnection.LoadConnection(ref ExceptionString);
            MySQLGeneralQuery.CommandText = "SELECT COUNT(*) FROM `User` WHERE `User_ID`=@User_ID";
            MySQLGeneralQuery.Parameters.Add("@User_ID", MySqlDbType.Text).Value = User_ID;
            MySQLGeneralQuery.Connection = myMyOwnMySQLConnection.MyMySQLConnection;
            MySQLGeneralQuery.Prepare();
            UserIDChecker = int.Parse(MySQLGeneralQuery.ExecuteScalar().ToString());
            if (UserIDChecker == 1)
            {
                MySQLGeneralQuery = new MySqlCommand();
                myMyOwnMySQLConnection.MyMySQLConnection.Close();
                myMyOwnMySQLConnection.LoadConnection(ref ExceptionString);
                MySQLGeneralQuery.CommandText = "SELECT `Master_PK` FROM `User` WHERE `User_ID`=@User_ID";
                MySQLGeneralQuery.Parameters.Add("@User_ID", MySqlDbType.Text).Value = User_ID;
                MySQLGeneralQuery.Connection = myMyOwnMySQLConnection.MyMySQLConnection;
                MySQLGeneralQuery.Prepare();
                Base64UserMasterPK = MySQLGeneralQuery.ExecuteScalar().ToString();
                UserMasterPK = Convert.FromBase64String(Base64UserMasterPK);
                UserMasterPKDigest = SodiumGenericHash.ComputeHash(64, UserMasterPK);
                myMyOwnMySQLConnection.MyMySQLConnection.Close();
                return Convert.ToBase64String(UserMasterPKDigest);
            }
            else 
            {
                return "Error: The user ID don't really exist.";
            }
        }
    }
}
