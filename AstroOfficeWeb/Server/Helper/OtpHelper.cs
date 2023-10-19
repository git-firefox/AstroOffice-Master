namespace AstroOfficeWeb.Server.Helper
{
    public class OtpHelper
    {
        public static string GenerateOtp()
        {
            Random random = new Random();
            int otp = random.Next(100000, 999999); // Generates a random 6-digit number

            return otp.ToString();
        }
    }
}
