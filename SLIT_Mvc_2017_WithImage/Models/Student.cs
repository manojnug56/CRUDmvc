//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SLIT_Mvc_2017_WithImage.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Student
    {
        public long StudentID { get; set; }

        [Required]
        public string FistName { get; set; }

        [Required]
        public string LasttName { get; set; }

        [Required]
        public string Nic { get; set; }

        [Required]
        public string Gender { get; set; }
        public string ImageFile { get; set; }
    }
}
