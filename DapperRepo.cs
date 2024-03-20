using CRUD_Application.DapperContext;
using CRUD_Application.Interface;
using CRUD_Application.Models;
using Dapper;
using System.Data;

namespace CRUD_Application.Repo
{
    public class DapperRepo : IDapperService
    {
        private readonly DapperDbContext _dapperContext;
        public DapperRepo(DapperDbContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        //Create Task
        /*public async Task<string> CreateTask(ToDo toDo)
        {
            string response = String.Empty;
            var sql = "insert into todos(name, description, status, createdDate) values(@name, @description,@status, @createdDate)";
            var parameters = new DynamicParameters();
            parameters.Add("id", toDo.Id, System.Data.DbType.String);
            parameters.Add("name", toDo.Name, System.Data.DbType.String);
            parameters.Add("description", toDo.Description, System.Data.DbType.String);
            parameters.Add("status", toDo.Status, System.Data.DbType.String);
            parameters.Add("createdDate", toDo.CreatedDate, System.Data.DbType.DateTime);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(sql, parameters);
                response = "pass";
            }
            return response;
        }*/
        public async Task<string> CreateTask(ToDo toDo)
        {
            string response = String.Empty;
            var sql = "CreateTodo"; // Stored procedure name
            var parameters = new DynamicParameters();
            parameters.Add("@Name", toDo.Name, DbType.String);
            parameters.Add("@Description", toDo.Description, DbType.String);
            parameters.Add("@Status", toDo.Status, DbType.Boolean);
            parameters.Add("@CreatedDate", toDo.CreatedDate, DbType.DateTime);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(sql, parameters, commandType: CommandType.StoredProcedure);
                response = "pass";
            }
            return response;
        }



        //Delete ToDos
        /*public async Task<string> DeleteTask(int id)
        {
            string response = String.Empty;
            var sql = "delete from todos where id = @id";
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(sql, new { id });
                response = "pass";
            }
            return response;
        }*/
        public async Task<string> DeleteTask(int id)
        {
            string response = String.Empty;
            var sql = "DeleteTodo"; // Stored procedure name
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(sql, new { id }, commandType: CommandType.StoredProcedure);
                response = "pass";
            }
            return response;
        }


        //Listing all the ToDos
        /*public async Task<List<ToDo>> GetAll()
        {
            var sql = "select * from todos";
            using (var connection = _dapperContext.CreateConnection())
            {
                var tasks = await connection.QueryAsync<ToDo>(sql);
                return tasks.ToList();
            }
        }*/
        public async Task<List<ToDo>> GetAll()
        {
            var sql = "GetAllTodos"; // Stored procedure name
            using (var connection = _dapperContext.CreateConnection())
            {
                var tasks = await connection.QueryAsync<ToDo>(sql, commandType: CommandType.StoredProcedure);
                return tasks.ToList();
            }
        }



        //Fetch Todos By ID
        /* public async Task<ToDo> GetTaskById(int id)
         {
             var sql = "select * from todos where id = @id";
             using (var connection = _dapperContext.CreateConnection())
             {
                 var task = await connection.QueryFirstOrDefaultAsync<ToDo>(sql, new { id });
                 return task;
             }
         }*/
        public async Task<ToDo> GetTaskById(int id)
        {
            var sql = "GetTodoById"; // Stored procedure name
            using (var connection = _dapperContext.CreateConnection())
            {
                var task = await connection.QueryFirstOrDefaultAsync<ToDo>(sql, new { id }, commandType: CommandType.StoredProcedure);
                return task;
            }
        }



        //Update ToDos
        /*public async Task<string> UpdateTask(ToDo toDo)
        {
            string response = String.Empty;
            var sql = "update todos set  name= @name, description = @description, status = @status";
            var parameters = new DynamicParameters();
            parameters.Add("id", toDo.Id, System.Data.DbType.String);
            parameters.Add("name", toDo.Name, System.Data.DbType.String);
            parameters.Add("description", toDo.Description, System.Data.DbType.String);
            parameters.Add("status", toDo.Status, System.Data.DbType.String);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(sql, parameters);
                response = "pass";
            }
            return response;
        }*/
        public async Task<string> UpdateTask(ToDo toDo)
        {
            string response = String.Empty;
            var sql = "UpdateTodo"; // Stored procedure name
            var parameters = new DynamicParameters();
            parameters.Add("@Id", toDo.Id,DbType.Int32);
            parameters.Add("@Name", toDo.Name,DbType.String);
            parameters.Add("@Description", toDo.Description, DbType.String);
            parameters.Add("@Status", toDo.Status, DbType.Boolean);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(sql, parameters, commandType: CommandType.StoredProcedure);
                response = "pass";
            }
            return response;
        }

    }
}
