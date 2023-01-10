using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PKDSA_ServerApp.Helper;
using PKDSA_ServerApp.Model;
using MySql.Data.MySqlClient;

namespace PKDSA_ServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterAccount : ControllerBase
    {
        private MyOwnMySQLConnection MyMyOwnMySQLConnectionClass = new MyOwnMySQLConnection();

        [HttpGet]
        public RegisterModel CreateAccount(String User_ID,String URLEncoded_Master_Signed_PK,String URLEncoded_Master_PK)
        {
            RegisterModel MyRegisterModel = new RegisterModel();
            DecodeDataClass decodeDataClass = new DecodeDataClass();
            String DecodedMaster_Signed_PK = "";
            Boolean DecodingMaster_Signed_PK = true;
            String DecodedMaster_PK = "";
            Boolean DecodingMaster_PK = true;
            MySqlCommand MySQLGeneralQuery = new MySqlCommand();
            String ExceptionString = "";
            int UserIDChecker = 0;
            decodeDataClass.DecodeDataFunction(ref DecodingMaster_Signed_PK, ref DecodedMaster_Signed_PK, URLEncoded_Master_Signed_PK);
            decodeDataClass.DecodeDataFunction(ref DecodingMaster_PK, ref DecodedMaster_PK, URLEncoded_Master_PK);
            if (DecodingMaster_Signed_PK == true && DecodingMaster_PK == true)
            {
                MyMyOwnMySQLConnectionClass.LoadConnection(ref ExceptionString);
                MySQLGeneralQuery.CommandText = "SELECT COUNT(*) FROM `User` WHERE `User_ID`=@User_ID";
                MySQLGeneralQuery.Parameters.Add("@User_ID", MySqlDbType.Text).Value = User_ID;
                MySQLGeneralQuery.Connection = MyMyOwnMySQLConnectionClass.MyMySQLConnection;
                MySQLGeneralQuery.Prepare();
                UserIDChecker = int.Parse(MySQLGeneralQuery.ExecuteScalar().ToString());
                if (UserIDChecker == 0)
                {
                    MySQLGeneralQuery = new MySqlCommand();
                    MyMyOwnMySQLConnectionClass.MyMySQLConnection.Close();
                    MyMyOwnMySQLConnectionClass.LoadConnection(ref ExceptionString);
                    MySQLGeneralQuery.CommandText = "INSERT INTO `User`(`User_ID`, `Master_Signed_PK`, `Master_PK`) VALUES (@User_ID,@Master_Signed_PK,@Master_PK)";
                    MySQLGeneralQuery.Parameters.Add("@User_ID", MySqlDbType.Text).Value = User_ID;
                    MySQLGeneralQuery.Parameters.Add("@Master_Signed_PK", MySqlDbType.Text).Value = DecodedMaster_Signed_PK;
                    MySQLGeneralQuery.Parameters.Add("@Master_PK", MySqlDbType.Text).Value = DecodedMaster_PK;
                    MySQLGeneralQuery.Connection = MyMyOwnMySQLConnectionClass.MyMySQLConnection;
                    MySQLGeneralQuery.Prepare();
                    MySQLGeneralQuery.ExecuteNonQuery();
                    MyRegisterModel.Status = "Congratulations: Your account has been registered ...";
                    MyRegisterModel.UserIDChecker = "Congratulations: This ID does not exists and all corresponding data has been recorded into the database";
                    MyRegisterModel.UserIDCount = "Congratulations: This ID has count of 0 in database rows";
                }
                else
                {
                    MyRegisterModel.Status = "Error: The user ID have already existed ... Use another one instead";
                    MyRegisterModel.UserIDChecker = "Error: Existed";
                    MyRegisterModel.UserIDCount = "Error: User ID count =" + UserIDChecker.ToString();
                }
                MyMyOwnMySQLConnectionClass.MyMySQLConnection.Close();
            }
            else
            {
                MyRegisterModel.Status = "Error: You didn't pass in correct URL encoded parameter value...";
                MyRegisterModel.UserIDChecker = "Error: Not Valid";
                MyRegisterModel.UserIDCount = "Error: Not Valid";
            }
            return MyRegisterModel;
        }

    }
}
