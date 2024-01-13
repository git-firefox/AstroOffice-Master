using ASModels;
using ASModels.Astrooff;
using Microsoft.EntityFrameworkCore;
namespace ASDAL
{
    public class DALUser
    {
        private readonly AstrooffContext _context;

        public DALUser(AstrooffContext context)
        {
            _context = context;
        }

        public int AddUser(AUser au, bool withEncryption = true)
        {
            if (withEncryption)
                au.Password = ENCEK.ENCEK.CellGell_ENC(au.Password!, "cellgell.com");
            _context.AUsers.Add(au);
            return _context.SaveChanges();
        }

        public IEnumerable<AUser> GetAllUsers()
        {
            return _context.AUsers.OrderBy(a => a.Username).ToList();
        }

        public AUser? GetSelectedUser(long sno)
        {
            if (_context.AUsers.FirstOrDefault(e => e.Sno == sno) is AUser existingEntity)
            {
                _context.Entry(existingEntity).State = EntityState.Detached;
                return existingEntity;
            }
            return null;
        }

        public int UpdateUser(AUser updateUserInfo)
        {
            try
            {
                if (_context.AUsers.FirstOrDefault(e => e.Sno == updateUserInfo.Sno) is AUser existingEntity)
                {
                    _context.Entry(existingEntity).State = EntityState.Detached;
                }

                updateUserInfo.Password = ENCEK.ENCEK.CellGell_ENC(updateUserInfo.Password!, "cellgell.com");
                _context.AUsers.Update(updateUserInfo);
                _context.Entry(updateUserInfo).State = EntityState.Modified;
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

        public AUser UserLogin(string? userName, string? password)
        {
            AUser? aUser = _context.AUsers.FirstOrDefault(aa => aa.Username == userName && aa.Active == true);

            if (aUser is null || !ENCEK.ENCEK.CellGell_MilaKya(password, aUser.Password, "cellgell.com"))
                return new AUser();

            var aUserToken = _context.AUserTokenBalances.FirstOrDefault(a => a.AUserSno == aUser.Sno);
            if (aUserToken is null)
            {
                _context.AUserTokenBalances.Add(new AUserTokenBalance
                {
                    TokenBalance = 0,
                    AUserSno = aUser.Sno
                });
                _context.SaveChanges();
            }

            return aUser;
        }

        public AUser? UserNameSearch(string userName)
        {
            if (_context.AUsers.FirstOrDefault(e => e.Username == userName) is AUser existingEntity)
            {
                _context.Entry(existingEntity).State = EntityState.Detached;
                return existingEntity;
            }
            return null;

        }

        public AUser? UserByMobileNumber(string mobileNumber)
        {
            try
            {
                var user = _context.AUsers.FirstOrDefault<AUser>(aa => aa.MobileNumber == mobileNumber);
                return user;
            }
            catch (Exception exception)
            {
                _ = exception;
                //_ = MessageBox.Show(exception.Message);
                return null;
            }
        }

        public bool IsUserPassUpdatedByOtp(string? mobileNumber, string password, string otp)
        {
            if (string.IsNullOrEmpty(password)) return false;

            try
            {
                var user = _context.AUsers.First<AUser>(aa => aa.MobileNumber == mobileNumber && aa.Active == true && aa.MobileOtp == otp);
                user.Password = ENCEK.ENCEK.CellGell_ENC(password, "cellgell.com");
                _context.AUsers.Update(user);
                _context.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                _ = exception;
                return false;
            }
        }
    }
}