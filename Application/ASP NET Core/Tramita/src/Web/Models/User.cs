
namespace Tramita.Models
{
    public class User
    {
        #region Core
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
        #endregion

        #region  Identity
        public string CPF { get; set; }
        public string RE { get; set; }
        public string PasswordHash { get; set; }
        #endregion

        #region Role
        public string RoleID { get; set; }
        public string RoleName { get; set; }
        #endregion

        #region Management
        public string DivisionName { get; set; }
        #endregion

        #region Profile
        public string Midia { get; set; }
        public string About { get; set; }
        public bool Active { get; set; }
        #endregion
    }
}
