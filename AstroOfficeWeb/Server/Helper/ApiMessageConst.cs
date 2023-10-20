namespace AstroOfficeWeb.Server.Helper
{
    public static class AccountMessageConst
    {
        public static string UserNotFound = "User not found. Please check the username.";
        public static string UserPassUpdated = "Password updated successfully.";
        public static string UserPassNotUpdated = "Failed to update the password.";
        public static string UnknownError = "An unknown error occurred. Please try again later or contact support.";
        public static string InvalidCredentials = "Sorry, the credentials you provided are invalid. Please double-check and try again.";
        public static string LoginSuccessful = "Hello there! You've successfully logged in.";
        public static string AccountNotFound = "Oops! We couldn't find your account. Please make sure you entered the correct information.";
        public static string AccountLocked = "Your account has been locked.Please contact support for assistance.";
        public static string AccessDenied = "Access denied. You may not have the necessary permissions to access this resource.";
        public static string AuthenticationFailed = "Authentication failed. Please ensure you provided the correct information.";
        public static string AccessTokenExpiredExpired = "Your session has expired. Please log in again to continue.";
        public static string ServerError = "Oops! Something went wrong on our end. Please try again later or contact support.";
        public static string AccountSuspended = "Your account has been suspended. Please contact support for more information.";
        public static string MobileNumberNotFound = "No user was found associated with this mobile number. Please check the number and try again.";

    }

    public static class SMSMessageConst
    {
        public static string InvalidOTP = "Verification failed. The one-time password (OTP) you provided is incorrect. Please ensure you entered the correct OTP.";
        public static string ValidOTP = "OTP has been successfully verified.";
    }
}
