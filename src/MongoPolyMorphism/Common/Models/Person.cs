// /*
//  Copyright (C) Secure Link Services AG. <info@selise.ch>
//  This file is part of SELISE ECAP (Enterprise Cloud Application Platform)
//  Any code from SELISE ECAP can not be copied, distributed, reused, published without explicit written and signed permission of management of Secure Link Services AG.
// */

using System;

namespace Selise.AppSuite.DataDefination.Core.PrimaryEntities
{
    public class Person : IEntity
    {
        public override DateTime CreateDate { get; set; }

        public override string CreatedBy { get; set; }

        public override string Language { get; set; }

        public override DateTime LastUpdateDate { get; set; }

        public override string LastUpdatedBy { get; set; }

        public override string TenantId { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string[] Interests { get; set; }

        public string ShortBio { get; set; }

        public string Sex { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }  


        public static Person Create(string createdBy, string language, string lastUpdatedBy, string tenantId, DateTime dob, string[] interests, string shortBio, string sex, string itemId)
        {
            return new Person()
            {
                CreateDate = DateTime.UtcNow,
                CreatedBy = createdBy,
                DateOfBirth = dob,
                Interests = interests,
                ItemId = itemId,
                Language = language,
                LastUpdateDate = DateTime.UtcNow,
                LastUpdatedBy = lastUpdatedBy,
                Sex = sex,
                ShortBio = shortBio,
                TenantId = tenantId
            };
        }
    }
}