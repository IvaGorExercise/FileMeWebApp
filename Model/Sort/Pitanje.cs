//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model.Sort
{
    using System;
    using System.Collections.Generic;
    using Model;
    
    public class Pitanje
    {
        public Pitanje() {}
        public Pitanje(Model.Field.Pitanje field, bool descending = false) 
    	{
            this.Field = field;
            this.Descending = descending;
    	}
    	public Model.Field.Pitanje Field { get; set; }
        public bool Descending { get; set; }
    }
}