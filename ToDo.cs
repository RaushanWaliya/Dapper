﻿namespace CRUD_Application.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Boolean Status {  get; set; }
        public DateTime CreatedDate { get; set;}
    }
}
