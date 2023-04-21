using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using ASodium;
using PKDSA_ServerApp.Helper;
using PKDSA_ServerApp.Model;

namespace PKDSA_ServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterChallengeRequestor : ControllerBase
    {
        private MyOwnMySQLConnection myMyOwnMySQLConnection = new MyOwnMySQLConnection();

        [HttpGet]
        public LoginModels RequestChallenge(String User_ID)
        {
            LoginModels MyLoginModels = new LoginModels();
            VerifyDataClass verifyDataClass = new VerifyDataClass();
            DecodeDataClass decodeDataClass = new DecodeDataClass();
            RevampedKeyPair ServerED25519KeyPair = SodiumPublicKeyAuth.GenerateRevampedKeyPair();
            Byte[] RandomData = SodiumRNG.GetRandomBytes(128);
            Byte[] SignedRandomData = new Byte[] { };
            MySqlCommand MySQLGeneralQuery = new MySqlCommand();
            int Count = 0;
            String ExceptionString = "";
            DateTime MyUTC8DateTime = DateTime.UtcNow.AddHours(8);
            myMyOwnMySQLConnection.LoadConnection(ref ExceptionString);
            MySQLGeneralQuery = new MySqlCommand();
            MySQLGeneralQuery.CommandText = "SELECT COUNT(*) FROM `Master_Random_Challenge` WHERE `Challenge`=@Challenge";
            MySQLGeneralQuery.Parameters.Add("@Challenge", MySqlDbType.Text).Value = Convert.ToBase64String(RandomData);
            MySQLGeneralQuery.Connection = myMyOwnMySQLConnection.MyMySQLConnection;
            MySQLGeneralQuery.Prepare();
            Count = int.Parse(MySQLGeneralQuery.ExecuteScalar().ToString());
            while (Count != 0)
            {
                RandomData = SodiumRNG.GetRandomBytes(128);
                MySQLGeneralQuery = new MySqlCommand();
                MySQLGeneralQuery.CommandText = "SELECT COUNT(*) FROM `Master_Random_Challenge` WHERE `Challenge`=@Challenge";
                MySQLGeneralQuery.Parameters.Add("@Challenge", MySqlDbType.Text).Value = Convert.ToBase64String(RandomData);
                MySQLGeneralQuery.Connection = myMyOwnMySQLConnection.MyMySQLConnection;
                MySQLGeneralQuery.Prepare();
                Count = int.Parse(MySQLGeneralQuery.ExecuteScalar().ToString());
            }
            MySQLGeneralQuery = new MySqlCommand();
            MySQLGeneralQuery.CommandText = "INSERT INTO `Master_Random_Challenge`(`Challenge`, `Valid_Duration`, `User_ID`) VALUES (@Challenge,@Valid_Duration,@User_ID)";
            MySQLGeneralQuery.Parameters.Add("@Challenge", MySqlDbType.Text).Value = Convert.ToBase64String(RandomData);
            MySQLGeneralQuery.Parameters.Add("@Valid_Duration", MySqlDbType.DateTime).Value = MyUTC8DateTime;
            MySQLGeneralQuery.Parameters.Add("@User_ID", MySqlDbType.Text).Value = User_ID;
            MySQLGeneralQuery.Connection = myMyOwnMySQLConnection.MyMySQLConnection;
            MySQLGeneralQuery.Prepare();
            MySQLGeneralQuery.ExecuteNonQuery();
            SignedRandomData = SodiumPublicKeyAuth.Sign(RandomData, ServerED25519KeyPair.PrivateKey);
            MyLoginModels.RequestStatus = "Successed: Kindly verify the signed challenge received from the server";
            MyLoginModels.ServerECDSAPKBase64String = Convert.ToBase64String(ServerED25519KeyPair.PublicKey);
            MyLoginModels.SignedRandomChallengeBase64String = Convert.ToBase64String(SignedRandomData);
            myMyOwnMySQLConnection.MyMySQLConnection.Close();
            ServerED25519KeyPair.Clear();
            return MyLoginModels;
        }

        [HttpGet("GetLostChallenge")]
        public LoginModels GetChallenge(String User_ID)
        {
            LoginModels MyLoginModels = new LoginModels();
            VerifyDataClass verifyDataClass = new VerifyDataClass();
            DecodeDataClass decodeDataClass = new DecodeDataClass();
            RevampedKeyPair ServerED25519KeyPair = SodiumPublicKeyAuth.GenerateRevampedKeyPair();
            Byte[] RandomData = new Byte[] { };
            Byte[] SignedRandomData = new Byte[] { };
            MySqlCommand MySQLGeneralQuery = new MySqlCommand();
            int Count = 0;
            String ExceptionString = "";
            DateTime MyUTC8DateTime = DateTime.UtcNow.AddHours(8);
            DateTime DatabaseDateTime = new DateTime();
            TimeSpan MyTimeSpan = new TimeSpan();
            myMyOwnMySQLConnection.LoadConnection(ref ExceptionString);
            MySQLGeneralQuery = new MySqlCommand();
            MySQLGeneralQuery.CommandText = "SELECT COUNT(*) FROM `Master_Random_Challenge` WHERE `User_ID`=@User_ID";
            MySQLGeneralQuery.Parameters.Add("@User_ID", MySqlDbType.Text).Value = User_ID;
            MySQLGeneralQuery.Connection = myMyOwnMySQLConnection.MyMySQLConnection;
            MySQLGeneralQuery.Prepare();
            Count = int.Parse(MySQLGeneralQuery.ExecuteScalar().ToString());
            if (Count == 0)
            {
                MyLoginModels.RequestStatus = "Error: There's no challenge requested from this pair of data";
                MyLoginModels.ServerECDSAPKBase64String = "";
                MyLoginModels.SignedRandomChallengeBase64String = "";
            }
            else
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
                    MySQLGeneralQuery.CommandText = "SELECT `Challenge` FROM `Master_Random_Challenge` WHERE `User_ID`=@User_ID";
                    MySQLGeneralQuery.Parameters.Add("@User_ID", MySqlDbType.Text).Value = User_ID;
                    MySQLGeneralQuery.Connection = myMyOwnMySQLConnection.MyMySQLConnection;
                    MySQLGeneralQuery.Prepare();
                    RandomData = Convert.FromBase64String(MySQLGeneralQuery.ExecuteScalar().ToString());
                    SignedRandomData = SodiumPublicKeyAuth.Sign(RandomData, ServerED25519KeyPair.PrivateKey);
                    MyLoginModels.RequestStatus = "Successed: Getting challenge previously generated for you..";
                    MyLoginModels.ServerECDSAPKBase64String = Convert.ToBase64String(ServerED25519KeyPair.PublicKey);
                    MyLoginModels.SignedRandomChallengeBase64String = Convert.ToBase64String(SignedRandomData);
                }
                else
                {
                    MySQLGeneralQuery = new MySqlCommand();
                    MySQLGeneralQuery.CommandText = "DELETE FROM `Master_Random_Challenge` WHERE `User_ID`=@User_ID";
                    MySQLGeneralQuery.Parameters.Add("@User_ID", MySqlDbType.Text).Value = User_ID;
                    MySQLGeneralQuery.Connection = myMyOwnMySQLConnection.MyMySQLConnection;
                    MySQLGeneralQuery.Prepare();
                    MySQLGeneralQuery.ExecuteNonQuery();
                    MyLoginModels.RequestStatus = "Error: Deleted the expired challenge..";
                    MyLoginModels.ServerECDSAPKBase64String = "";
                    MyLoginModels.SignedRandomChallengeBase64String = "";
                }
            }
            myMyOwnMySQLConnection.MyMySQLConnection.Close();
            ServerED25519KeyPair.Clear();
            return MyLoginModels;
        }
    }
}
