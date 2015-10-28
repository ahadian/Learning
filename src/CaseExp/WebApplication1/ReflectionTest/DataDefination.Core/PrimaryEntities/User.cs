// --------------------------------------------------------------------------------------------------------------------
// <copyright file="User.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace ReflectionTest.DataDefination.Core.PrimaryEntities
{
    #region

    

    #endregion

    public class User : IEntity
    {

        #region Public Properties

        public string Id { get; set; }

        public bool Active { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }
        public string Sex { get; set; }

        public string UserName { get; set; }


        public DateTime CreateDate { get; set; }

        public string CreatedBy { get; set; }

        public string ModofiedBy { get; set; }

        public string Language { get; set; }


        public DateTime LastUpdateDate { get; set; }


        #endregion

        #region Public Methods and Operators

        public static User Create(
            string userName,
            string password,
            string lastName,
            string firstName,
            string sex,
            DateTime? dateOfBirth,
            string id = "")
        {
            return new User
                       {
                           CreateDate = DateTime.UtcNow,
                           CreatedBy = "System",
                           Id = Guid.NewGuid().ToString(),
                           Language = "EN",
                           LastUpdateDate = DateTime.UtcNow,
                           ModofiedBy = "Syatem",
                           Password = password,
                           UserName = userName,
                           DateOfBirth = dateOfBirth,
                           FirstName = firstName,
                           LastName = lastName,
                           Sex = sex,
                           Active = true
                       };
        }

        public static User CreatePassword(string password, string id)
        {
            return new User { Password = password, Id = id };
        }

        public void ChangePassword(string newPassword)
        {
            this.Password = newPassword;
        }

        #endregion
    }
}