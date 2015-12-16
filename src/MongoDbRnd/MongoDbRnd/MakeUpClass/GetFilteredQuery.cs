using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MongoDbRnd.MakeUpClass
{
    public enum FilterType
    {
        InnerFilter,Simple
    }
    public class DataFilter
    {
        public string PropertyName { get; set; }
        public string Value { get; set; } // value can be deserailized to GetFilteredQuery based on filterType

        public FilterType FilterType { get; set; }
    }
    public class GetFilteredQuery 
    {
        #region Constructors and Destructors

        public GetFilteredQuery()
        {
            this.DataFilters = new DataFilter[] { };
            //SortOrder = Selise.AppSuite.Common.SortOrder.Ascending;
            OrderBy = "_id";
            PageLimit = 20;
            PageNumber = 0;
        }

        #endregion

        #region Public Properties

        public DataFilter[] DataFilters { get; set; }

        public string EntityName { get; set; }

        public string OrderBy { get; set; }

        public int? PageLimit { get; set; }

        public int? PageNumber { get; set; }
        public string[] Fields { get; set; } 

        //public SortOrder? SortOrder { get; set; }

        #endregion

    }
}