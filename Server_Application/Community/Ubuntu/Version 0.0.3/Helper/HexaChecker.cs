using ASodium;
namespace PKDSA_ServerApp.Helper
{
    public static class HexaChecker
    {
        public static Boolean CheckHexa(String Data) 
        {
            Boolean CheckBool = true;
            try
            {
                Byte[] DataByte = SodiumHelper.HexToBinary(Data);
            }
            catch 
            {
                CheckBool = false;
            }
            return CheckBool;
        }
    }
}
