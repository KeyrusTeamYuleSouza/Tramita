using System;

namespace Web.ViewModel
{
    public class UserTicketViewModel
    {
        #region Properties

        public int ID { get; set; }                 // User
        public string CPF { get; set; }             // Identiy Card
        public string RE { get; set; }              // Identiy Card
        public string Password { get; set; }        // Identiy Card
        public string FirstName { get; set; }       // User
        public string LastName { get; set; }        // User
        public string Phone { get; set; }           // User
        public string CellPhone { get; set; }       // User
        public string Email { get; set; }           // User
        public string SectionName { get; set; }     // MGT
        public string DivisionName { get; set; }    // MGT
        public string RoleName { get; set; }        // Management
        public string MidiaName { get; set; }       // Management
        public string MidiaPath { get; set; }       // Management
        public string ProfileMidia { get; set; }    // Management
        public DateTime ModifiedDate { get; set; }  // User

        #endregion 
    }
}