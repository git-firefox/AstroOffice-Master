using AstroOfficeWeb.Shared.Utilities;

namespace AstroOfficeWeb.Shared.DTOs
{
    public class BaseUserDTO
    {
        public long Sno { get; set; }
        public string Username { get; set; } = null!;
        public bool AdminUser { get; set; }
        public bool CanAdd { get; set; }
        public bool CanEdit { get; set; }
        public bool CanReport { get; set; }
        public bool Active { get; set; }
        public string? MobileNumber { get; set; }
        public UserRole Role { get; set; }
        public UserStatus Status { get; set; }
    }

    public class SaveUserDTO : BaseUserDTO
    {
        public string? HashedPassword { get; set; }
    }
}