// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Jwt.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace ReflectionTest.DataDefination.Core
{
    #region

    

    #endregion

    public class Jwt
    {
        // ExpireOn
        #region Public Properties

        public string[] aud { get; set; }

        public DateTime exp { get; set; }

        public string iat { get; set; }

        public string iss { get; set; }

        public DateTime nbf { get; set; }

        public string sub { get; set; }

        #endregion

        // aud check // admin.fruitshop.com , mango-site.com,banana-site.com {subject at a time eder ekta,request host name}
    }
}