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
    public class ChangeKey : ControllerBase
    {
        private MyOwnMySQLConnection myMyOwnMySQLConnection = new MyOwnMySQLConnection();

        [HttpGet]
        public String ChangeMasterKey(String User_ID, String URLEncoded_Signed_Challenge, String URLEncoded_Signed_PK, String URLEncoded_PK)
        {
            String Status = "";
            DecodeDataClass decodeDataClass = new DecodeDataClass();
            String Decoded_Signed_Challenge = "";
            Boolean DecodingSignedChallengeChecker = true;
            String Decoded_Signed_PK = "";
            Boolean DecodingSigned_PKChecker = true;
            String Decoded_PK = "";
            Boolean DecodingPKChecker = true;
            MySqlCommand MySQLGeneralQuery = new MySqlCommand();
            String ExceptionString = "";
            int UserIDChecker = 0;
            String Base64EncodedMasterSignedPK = "";
            String Base64EncodedMasterPK = "";
            Byte[] MasterSignedPK = new Byte[] { };
            Byte[] VerifiedMasterPK = new Byte[] { };
            Byte[] MasterPK = new Byte[] { };
            Byte[] Signed_Challenge = new Byte[] { };
            Byte[] Random_Challenge = new Byte[] { };
            int Count = 0;
            DateTime MyUTC8DateTime = DateTime.UtcNow.AddHours(8);
            DateTime DatabaseDateTime = new DateTime();
            TimeSpan MyTimeSpan = new TimeSpan();
            decodeDataClass.DecodeDataFunction(ref DecodingSignedChallengeChecker, ref Decoded_Signed_Challenge, URLEncoded_Signed_Challenge);
            decodeDataClass.DecodeDataFunction(ref DecodingSigned_PKChecker, ref Decoded_Signed_PK, URLEncoded_Signed_PK);
            decodeDataClass.DecodeDataFunction(ref DecodingPKChecker, ref Decoded_PK, URLEncoded_PK);
            if (DecodingSignedChallengeChecker == true && DecodingSigned_PKChecker == true && DecodingPKChecker == true)
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
                    MySQLGeneralQuery.CommandText = "SELECT `Master_Signed_PK` FROM `User` WHERE `User_ID`=@User_ID";
                    MySQLGeneralQuery.Parameters.Add("@User_ID", MySqlDbType.Text).Value = User_ID;
                    MySQLGeneralQuery.Connection = myMyOwnMySQLConnection.MyMySQLConnection;
                    MySQLGeneralQuery.Prepare();
                    Base64EncodedMasterSignedPK = MySQLGeneralQuery.ExecuteScalar().ToString();
                    MySQLGeneralQuery = new MySqlCommand();
                    MySQLGeneralQuery.CommandText = "SELECT `Master_PK` FROM `User` WHERE `User_ID`=@User_ID";
                    MySQLGeneralQuery.Parameters.Add("@User_ID", MySqlDbType.Text).Value = User_ID;
                    MySQLGeneralQuery.Connection = myMyOwnMySQLConnection.MyMySQLConnection;
                    MySQLGeneralQuery.Prepare();
                    Base64EncodedMasterPK = MySQLGeneralQuery.ExecuteScalar().ToString();
                    MasterSignedPK = Convert.FromBase64String(Base64EncodedMasterSignedPK);
                    MasterPK = Convert.FromBase64String(Base64EncodedMasterPK);
                    if (MasterPK.Length == 57)
                    {
                        VerifiedMasterPK = SecureED448.GetMessageFromSignatureMessage(MasterPK, MasterSignedPK, new Byte[] { });
                    }
                    else
                    {
                        VerifiedMasterPK = SodiumPublicKeyAuth.Verify(MasterSignedPK, MasterPK);
                    }
                    if (VerifiedMasterPK.SequenceEqual(MasterPK) == true)
                    {
                        Signed_Challenge = Convert.FromBase64String(Decoded_Signed_Challenge);
                        if (MasterPK.Length == 57)
                        {
                            Random_Challenge = SecureED448.GetMessageFromSignatureMessage(MasterPK, Signed_Challenge, new Byte[] { });
                        }
                        else
                        {
                            Random_Challenge = SodiumPublicKeyAuth.Verify(Signed_Challenge, MasterPK);
                        }
                        MySQLGeneralQuery = new MySqlCommand();
                        MySQLGeneralQuery.CommandText = "SELECT COUNT(*) FROM `Master_Random_Challenge` WHERE `Challenge`=@Challenge";
                        MySQLGeneralQuery.Parameters.Add("@Challenge", MySqlDbType.Text).Value = Convert.ToBase64String(Random_Challenge);
                        MySQLGeneralQuery.Connection = myMyOwnMySQLConnection.MyMySQLConnection;
                        MySQLGeneralQuery.Prepare();
                        Count = int.Parse(MySQLGeneralQuery.ExecuteScalar().ToString());
                        if (Count == 1)
                        {
                            MySQLGeneralQuery = new MySqlCommand();
                            MySQLGeneralQuery.CommandText = "SELECT `Valid_Duration` FROM `Master_Random_Challenge` WHERE `User_ID`=@User_ID";
                            MySQLGeneralQuery.Parameters.Add("@User_ID", MySqlDbType.Text).Value = User_ID;
                            MySQLGeneralQuery.Connection = myMyOwnMySQLConnection.MyMySQLConnection;
                            MySQLGeneralQuery.Prepare();
                            DatabaseDateTime = DateTime.Parse(MySQLGeneralQuery.ExecuteScalar().ToString());
                            MyTimeSpan = MyUTC8DateTime.Subtract(DatabaseDateTime);
                            if (MyTimeSpan.TotalMinutes <= 8)
                            {
                                MySQLGeneralQuery = new MySqlCommand();
                                MySQLGeneralQuery.CommandText = "UPDATE `User` SET `Master_Signed_PK`=@Master_Signed_PK,`Master_PK`=@Master_PK WHERE `User_ID`=@User_ID";
                                MySQLGeneralQuery.Parameters.Add("@User_ID", MySqlDbType.Text).Value = User_ID;
                                MySQLGeneralQuery.Parameters.Add("@Master_Signed_PK", MySqlDbType.Text).Value = Decoded_Signed_PK;
                                MySQLGeneralQuery.Parameters.Add("@Master_PK", MySqlDbType.Text).Value = Decoded_PK;
                                MySQLGeneralQuery.Connection = myMyOwnMySQLConnection.MyMySQLConnection;
                                MySQLGeneralQuery.Prepare();
                                MySQLGeneralQuery.ExecuteNonQuery();
                                Status = "Successed: The master keys have been updated";
                            }
                            else
                            {
                                Status = "Error: The challenge has been expired";
                            }
                            MySQLGeneralQuery = new MySqlCommand();
                            MySQLGeneralQuery.CommandText = "DELETE FROM `Master_Random_Challenge` WHERE `User_ID`=@User_ID";
                            MySQLGeneralQuery.Parameters.Add("@User_ID", MySqlDbType.Text).Value = User_ID;
                            MySQLGeneralQuery.Connection = myMyOwnMySQLConnection.MyMySQLConnection;
                            MySQLGeneralQuery.Prepare();
                            MySQLGeneralQuery.ExecuteNonQuery();
                        }
                        else
                        {
                            Status = "Error: The challenge does not exist in the database";
                        }
                    }
                    else
                    {
                        Status = "Error: Verified master pk is not the same as the master pk in database";
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
                Status = "Error: You didn't pass in correct URL encoded data";
            }
            return Status;
        }
    }
}
