//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TodoListModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class TodoListTable
    {
        public int Id { get; set; }
        public string Todo { get; set; }
        public Nullable<int> Priority { get; set; }
        public Nullable<System.DateTime> TimeAndDate { get; set; }
        public Nullable<int> Status { get; set; }
    }
}
