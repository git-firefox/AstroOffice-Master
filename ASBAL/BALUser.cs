using ASDAL;
using ASModels.Astrooff;

namespace ASBAL
{
    public class BALUser
    {
        private readonly DALUser _du;

        public BALUser(DALUser dALUser)
        {
            _du = dALUser;
        }

        public int AddUser(AUser au, bool withEncryption = true)
        {
            return _du.AddUser(au, withEncryption);
        }

        public IEnumerable<AUser> GetAllUsers()
        {
            return _du.GetAllUsers();
        }

        public AUser? GetSelectedUser(long sno)
        {
            return _du.GetSelectedUser(sno);
        }

        public int UpdateUser(AUser au)
        {
            return _du.UpdateUser(au);
        }

        public AUser UserLogin(string? userName, string? password)
        {
            return _du.UserLogin(userName, password);
        }

        public AUser? UserNameSearch(string userName)
        {
            return _du.UserNameSearch(userName);
        }
        public AUser? GetUserByMobileNumber(string? mobileNumber)
        {
            if (string.IsNullOrEmpty(mobileNumber)) return null;
            return _du.UserByMobileNumber(mobileNumber);
        }

        public bool IsUserPassUpdatedByOtp(string? mobileNumber, string password, string otp)
        {
            return _du.IsUserPassUpdatedByOtp(mobileNumber, password, otp); ;
        }
    }
}