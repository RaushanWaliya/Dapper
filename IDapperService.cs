﻿using CRUD_Application.Models;

namespace CRUD_Application.Interface
{
    public interface IDapperService
    {
        Task<List<ToDo>> GetAll();
        Task<ToDo> GetTaskById(int id);
        Task<string> CreateTask(ToDo toDo);
        Task<string> UpdateTask(ToDo toDo);
        Task<string> DeleteTask(int id);
    }
}
