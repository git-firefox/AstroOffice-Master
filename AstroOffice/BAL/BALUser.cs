using AstroOffice.DAl;
using AstroOffice.Models.Astrooff;

namespace AstroOffice.BAL
{
    internal class BALUser
    {
        private readonly DALUser _du;

        public BALUser()
        {
            _du = new DALUser();
        }

        public void AddUser(AUser au)
        {
            _du.AddUser(au);
        }

        public IEnumerable<AUser> GetAllUsers()
        {
            return _du.GetAllUsers();
        }

        public AUser GetSelectedUser(long sno)
        {
            return _du.GetSelectedUser(sno);
        }

        public int UpdateUser(AUser au)
        {
            return _du.UpdateUser(au);
        }

        public AUser UserLogin(string userName, string password)
        {
            return _du.UserLogin(userName, password);
        }

        public AUser UserNameSearch(string userName)
        {
            return _du.UserNameSearch(userName);
        }
    }
}