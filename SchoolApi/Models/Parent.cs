﻿namespace SchoolApi.Models
{
    public class Parent:ApplicationUser
    {
        public List<ParentStudent>? ParentStudents { get; set; }
    }
}
