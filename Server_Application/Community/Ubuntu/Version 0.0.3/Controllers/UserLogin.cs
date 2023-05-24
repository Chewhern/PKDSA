using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PKDSA_ServerApp.Helper;
using MySql.Data.MySqlClient;
using ASodium;
using BCASodium;

namespace PKDSA_ServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLogin : ControllerBase
    {
        private MyOwnMySQLConnection myMyOwnMySQLConnection = new MyOwnMySQLConnection();

        [HttpGet]
        public String Login(String User_ID, String Key_Identifier, String URLEncoded_Signed_Challenge)
        {
            String Status = "";
            DecodeDataClass decodeDataClass = new DecodeDataClass();
            String Decoded_Signed_Challenge = "";
            Boolean DecodingSignedChallengeChecker = true;
            MySqlCommand MySQLGeneralQuery = new MySqlCommand();
            String ExceptionString = "";
            int UserIDChecker = 0;
            String Base64EncodedLoginSignedPK = "";
            String Base64EncodedLoginPK = "";
            Byte[] LoginSignedPK = new Byte[] { };
            Byte[] VerifiedLoginPK = new Byte[] { };
            Byte[] LoginPK = new Byte[] { };
            Byte[] Signed_Challenge = new Byte[] { };
            Byte[] Random_Challenge = new Byte[] { };
            int Count = 0;
            DateTime MyUTC8DateTime = DateTime.UtcNow.AddHours(8);
            DateTime DatabaseDateTime = new DateTime();
            TimeSpan MyTimeSpan = new TimeSpan();
            decodeDataClass.DecodeDataFunction(ref DecodingSignedChallengeChecker, ref Decoded_Signed_Challenge, URLEncoded_Signed_Challenge);
            if (DecodingSignedChallengeChecker == true)
            {
                myMyOwnMySQLConnection.LoadConnection(ref ExceptionString);
                MySQLGeneralQuery.CommandText = "SELECT COUNT(*) FROM `User` WHERE `User_ID`=@User_ID";
                MySQLGeneralQuery.Parameters.Add("@User_ID", MySqlDbType.Text).Value = User_ID;
                MySQLGeneralQuery.Connection = myMyOwnMySQLConnection.MyMySQLConnection;
                MySQLGeneralQuery.Prepare();
                UserIDChecker = int.Parse(MySQLGeneralQuery.ExecuteScalar().ToString());
                if (UserIDChecker == 1)
                {
                    MySQLGeneralQuery = new MySqlCommand();
                    MySQLGeneralQuery.CommandText = "SELECT `Login_Signed_PK` FROM `User_Keys` WHERE `Key_Identifier`=@Key_Identifier";
                    MySQLGeneralQuery.Parameters.Add("@Key_Identifier", MySqlDbType.Text).Value = Key_Identifier;
                    MySQLGeneralQuery.Connection = myMyOwnMySQLConnection.MyMySQLConnection;
                    MySQLGeneralQuery.Prepare();
                    Base64EncodedLoginSignedPK = MySQLGeneralQuery.ExecuteScalar().ToString();
                    MySQLGeneralQuery = new MySqlCommand();
                    MySQLGeneralQuery.CommandText = "SELECT `Login_PK` FROM `User_Keys` WHERE `Key_Identifier`=@Key_Identifier";
                    MySQLGeneralQuery.Parameters.Add("@Key_Identifier", MySqlDbType.Text).Value = Key_Identifier;
                    MySQLGeneralQuery.Connection = myMyOwnMySQLConnection.MyMySQLConnection;
                    MySQLGeneralQuery.Prepare();
                    Base64EncodedLoginPK = MySQLGeneralQuery.ExecuteScalar().ToString();
                    LoginSignedPK = Convert.FromBase64String(Base64EncodedLoginSignedPK);
                    LoginPK = Convert.FromBase64String(Base64EncodedLoginPK);
                    if (LoginPK.Length == 57)
                    {
                        VerifiedLoginPK = SecureED448.GetMessageFromSignatureMessage(LoginPK, LoginSignedPK, new Byte[] { });
                    }
                    else
                    {
                        VerifiedLoginPK = SodiumPublicKeyAuth.Verify(LoginSignedPK, LoginPK);
                    }
                    if (VerifiedLoginPK.SequenceEqual(LoginPK) == true)
                    {
                        Signed_Challenge = Convert.FromBase64String(Decoded_Signed_Challenge);
                        if (LoginPK.Length == 57)
                        {
                            Random_Challenge = SecureED448.GetMessageFromSignatureMessage(LoginPK, Signed_Challenge, new Byte[] { });
                        }
                        else
                        {
                            Random_Challenge = SodiumPublicKeyAuth.Verify(Signed_Challenge, LoginPK);
                        }
                        MySQLGeneralQuery = new MySqlCommand();
                        MySQLGeneralQuery.CommandText = "SELECT COUNT(*) FROM `Random_Challenge` WHERE `Challenge`=@Challenge AND `User_ID`=@User_ID AND `Key_Identifier`=@Key_Identifier";
                        MySQLGeneralQuery.Parameters.Add("@Challenge", MySqlDbType.Text).Value = Convert.ToBase64String(Random_Challenge);
                        MySQLGeneralQuery.Parameters.Add("@User_ID", MySqlDbType.Text).Value = User_ID;
                        MySQLGeneralQuery.Parameters.Add("@Key_Identifier", MySqlDbType.Text).Value = Key_Identifier;
                        MySQLGeneralQuery.Connection = myMyOwnMySQLConnection.MyMySQLConnection;
                        MySQLGeneralQuery.Prepare();
                        Count = int.Parse(MySQLGeneralQuery.ExecuteScalar().ToString());
                        if (Count == 1)
                        {
                            MySQLGeneralQuery = new MySqlCommand();
                            MySQLGeneralQuery.CommandText = "SELECT `Valid_Duration` FROM `Random_Challenge` WHERE `User_ID`=@User_ID AND `Key_Identifier`=@Key_Identifier";
                            MySQLGeneralQuery.Parameters.Add("@User_ID", MySqlDbType.Text).Value = User_ID;
                            MySQLGeneralQuery.Parameters.Add("@Key_Identifier", MySqlDbType.Text).Value = Key_Identifier;
                            MySQLGeneralQuery.Connection = myMyOwnMySQLConnection.MyMySQLConnection;
                            MySQLGeneralQuery.Prepare();
                            DatabaseDateTime = DateTime.Parse(MySQLGeneralQuery.ExecuteScalar().ToString());
                            MyTimeSpan = MyUTC8DateTime.Subtract(DatabaseDateTime);
                            if (MyTimeSpan.TotalMinutes <= 8)
                            {
                                Status = "Successed: The user has now logged in with their sub keys";
                            }
                            else
                            {
                                Status = "Error: The challenge has been expired";
                            }
                            MySQLGeneralQuery = new MySqlCommand();
                            MySQLGeneralQuery.CommandText = "DELETE FROM `Random_Challenge` WHERE `User_ID`=@User_ID AND `Key_Identifier`=@Key_Identifier";
                            MySQLGeneralQuery.Parameters.Add("@User_ID", MySqlDbType.Text).Value = User_ID;
                            MySQLGeneralQuery.Parameters.Add("@Key_Identifier", MySqlDbType.Text).Value = Key_Identifier;
                            MySQLGeneralQuery.Connection = myMyOwnMySQLConnection.MyMySQLConnection;
                            MySQLGeneralQuery.Prepare();
                            MySQLGeneralQuery.ExecuteNonQuery();
                        }
                        else
                        {
                            Status = "Error: The challenge does not exist in the database or the slave key has been deleted.";
                        }
                    }
                    else
                    {
                        Status = "Error: Verified login pk is not the same as the login pk in database";
                    }
                }
                else
                {
                    Status = "Error: Such User ID don't exist";
                }
                myMyOwnMySQLConnection.MyMySQLConnection.Close();
            }
            else
            {
                Status = "Error: You didn't pass in correct URL encoded signed challange";
            }
            return Status;
        }
    }
}
