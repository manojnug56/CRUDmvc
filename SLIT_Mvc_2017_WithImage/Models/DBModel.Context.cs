﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class BasicLayeredDB_DemoEntities : DbContext
    {
        public BasicLayeredDB_DemoEntities()
            : base("name=BasicLayeredDB_DemoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Student> Students { get; set; }
    
        public virtual int DeleteStudent(Nullable<long> studentID)
        {
            var studentIDParameter = studentID.HasValue ?
                new ObjectParameter("StudentID", studentID) :
                new ObjectParameter("StudentID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteStudent", studentIDParameter);
        }
    
        public virtual ObjectResult<GetAllStudents_Result> GetAllStudents()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllStudents_Result>("GetAllStudents");
        }
    
        public virtual ObjectResult<GetStudent_Result> GetStudent()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetStudent_Result>("GetStudent");
        }
    
        public virtual ObjectResult<GetStudentByID_Result> GetStudentByID(Nullable<long> studentID)
        {
            var studentIDParameter = studentID.HasValue ?
                new ObjectParameter("StudentID", studentID) :
                new ObjectParameter("StudentID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetStudentByID_Result>("GetStudentByID", studentIDParameter);
        }
    
        public virtual ObjectResult<GetTable_Result> GetTable()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetTable_Result>("GetTable");
        }
    
        public virtual int InsertStudent(string fistName, string lasttName, string nic, string gender, string imageFile)
        {
            var fistNameParameter = fistName != null ?
                new ObjectParameter("FistName", fistName) :
                new ObjectParameter("FistName", typeof(string));
    
            var lasttNameParameter = lasttName != null ?
                new ObjectParameter("LasttName", lasttName) :
                new ObjectParameter("LasttName", typeof(string));
    
            var nicParameter = nic != null ?
                new ObjectParameter("Nic", nic) :
                new ObjectParameter("Nic", typeof(string));
    
            var genderParameter = gender != null ?
                new ObjectParameter("Gender", gender) :
                new ObjectParameter("Gender", typeof(string));
    
            var imageFileParameter = imageFile != null ?
                new ObjectParameter("ImageFile", imageFile) :
                new ObjectParameter("ImageFile", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertStudent", fistNameParameter, lasttNameParameter, nicParameter, genderParameter, imageFileParameter);
        }
    
        public virtual ObjectResult<StudentReport_Result> StudentReport(string nic)
        {
            var nicParameter = nic != null ?
                new ObjectParameter("Nic", nic) :
                new ObjectParameter("Nic", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<StudentReport_Result>("StudentReport", nicParameter);
        }
    
        public virtual int UpdateStudent(Nullable<long> studentID, string fistName, string lasttName, string nic, string gender, string imageFile)
        {
            var studentIDParameter = studentID.HasValue ?
                new ObjectParameter("StudentID", studentID) :
                new ObjectParameter("StudentID", typeof(long));
    
            var fistNameParameter = fistName != null ?
                new ObjectParameter("FistName", fistName) :
                new ObjectParameter("FistName", typeof(string));
    
            var lasttNameParameter = lasttName != null ?
                new ObjectParameter("LasttName", lasttName) :
                new ObjectParameter("LasttName", typeof(string));
    
            var nicParameter = nic != null ?
                new ObjectParameter("Nic", nic) :
                new ObjectParameter("Nic", typeof(string));
    
            var genderParameter = gender != null ?
                new ObjectParameter("Gender", gender) :
                new ObjectParameter("Gender", typeof(string));
    
            var imageFileParameter = imageFile != null ?
                new ObjectParameter("ImageFile", imageFile) :
                new ObjectParameter("ImageFile", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateStudent", studentIDParameter, fistNameParameter, lasttNameParameter, nicParameter, genderParameter, imageFileParameter);
        }
    }
}