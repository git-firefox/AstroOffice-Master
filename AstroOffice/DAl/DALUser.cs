// Ignore Spelling: Astro

using AstroOffice.Models;
using AstroOffice.Models.Astrooff;
namespace AstroOffice.DAl
{
    internal class DALUser
    {
        private readonly AstrooffContext _context;

        public DALUser()
        {
            _context = new AstrooffContext();
        }

        public void AddUser(AUser au)
        {
            try
            {
                _context.AUsers.Add(au);
                _ = _context.SaveChanges();
            }
            catch (Exception exception)
            {
                _ = MessageBox.Show(string.Concat("Access Denied..!!\n", exception.ToString()));
            }
        }

        public IEnumerable<AUser> GetAllUsers()
        {
            return _context.AUsers.OrderBy(a => a.Username).ToList();
        }

        public AUser GetSelectedUser(long sno)
        {
            return _context.AUsers.FirstOrDefault<AUser>(uu => uu.Sno == sno);
        }

        public int UpdateUser(AUser au)
        {
            var aUsers = _context.AUsers.FirstOrDefault(u => u.Sno == au.Sno);

            if (aUsers == null)
            {
                return 0;
            }

            try
            {
                _context.AUsers.Update(au);
                return _context.SaveChanges();
            }
            catch
            {
                return 0;
            }

            //EntityKey entityKey = null;
            //object obj = null;
            //int num = 0;
            //asd.AUsers.U
            //entityKey = this.asd.A_astro("AUsers", au);
            //if (!this.asd.TryGetObjectByKey(entityKey, out obj))
            //{
            //    this.asd.Attach(au);
            //}
            //else
            //{
            //    this.asd.ApplyPropertyChanges(entityKey.EntitySetName, au);
            //    num = 1;
            //}
            //this.asd.SaveChanges();
            //return num;
        }

        public AUser UserLogin(string userName, string password)
        {
            AUser aUser = _context.AUsers.FirstOrDefault(aa => aa.Username == userName && aa.Active == true);

            if (aUser is null || !ENCEK.ENCEK.CellGell_MilaKya(password, aUser.Password, "cellgell.com"))
                return new AUser();

            return aUser;
        }

        public AUser UserNameSearch(string userName)
        {
            AUser aUser = null;
            try
            {
                aUser = _context.AUsers.First<AUser>(aa => aa.Username == userName);
            }
            catch (Exception exception)
            {
                _ = MessageBox.Show(exception.Message);
            }
            return aUser;
        }
    }
}