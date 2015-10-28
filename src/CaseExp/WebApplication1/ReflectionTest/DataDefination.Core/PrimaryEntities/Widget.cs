using System;

namespace ReflectionTest.DataDefination.Core.PrimaryEntities
{
    public class Widget : IEntity
    {
        public string CustomerId { get; set; }

        public string HelplineNumber { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }


        public string CreatedBy { get; set; }


        public string Id { get; set; }

        public string Language { get; set; }


        public DateTime LastUpdateDate { get; set; }

        public string ModofiedBy { get; set; }

        public string Name { get; set; }
        public string CustomerName { get; set; }

        public string WidgetUrl { get; set; }

        public Widget()
        {
            
        }
    }
}