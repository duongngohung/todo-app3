using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySqlConnector;
using Dapper;
using System.Data;
namespace todoApp.Repository
{
    public class DBConnect
    {
        
        private static string connString = "User Id = root; Host=localhost; Port=3306; Character Set = utf8; password=hung1118;Database=todoappdata";
        private IDbConnection dbConnect;
        public DBConnect()
        {
            dbConnect = new MySqlConnection(connString);
        }
        public List<Models.Task> getTasks(string order)
        {
            string procName = "procGetTasks";
            if (order.Equals("asc"))
            {
                procName = "proceGetTasksByOldDate";
            }
            //string sql = "select * from task;";
            List<Models.Task> taskList = dbConnect.Query<Models.Task>(procName,commandType:CommandType.StoredProcedure).ToList();
            return taskList;
        } 
        public int insertTask(Models.Task task)
        {
            string procName = "procAddTask";
            int result = dbConnect.Execute(procName,param:task ,commandType: CommandType.StoredProcedure);
            return result;
        }
        public int updateTask(Models.Task task)
        {
            string procName = "procUpdateTask";
            int result = dbConnect.Execute(procName, param: task, commandType: CommandType.StoredProcedure);
            return result;
        }
        public int deleteTask(Guid taskId)
        {
            DynamicParameters dynamic = new DynamicParameters();
            dynamic.Add("taskId", taskId);
            string procName = "procDeleteTask";
            int result = dbConnect.Execute(procName,dynamic, commandType: CommandType.StoredProcedure);
            return result;
        }
        
    }
    

}
