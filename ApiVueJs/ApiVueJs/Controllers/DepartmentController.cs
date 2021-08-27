using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// add packeges
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ApiVueJs.Models;

namespace ApiVueJs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public DepartmentController(IConfiguration configuration) 
        {
            _configuration = configuration;
        }
            
        // Get List of Departments 

        [HttpGet]
        public JsonResult Get()
        {
            string query = @" SELECT DepartmentId, DepartmentName FROM dbo.Departments ";

            DataTable table = new DataTable();

            string v = _configuration.GetConnectionString("ApiVueJsConnection");
            string sqlDataSource = v;
            SqlDataReader myReader;
            using(SqlConnection myConn = new SqlConnection(sqlDataSource))
            {
                myConn.Open();
                using(SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myConn.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            string query = @" SELECT DepartmentId, DepartmentName FROM dbo.Departments WHERE DepartmentId = @DepartmentId ";

            DataTable table = new DataTable();

            string v = _configuration.GetConnectionString("ApiVueJsConnection");
            string sqlDataSource = v;
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(sqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@DepartmentId", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myConn.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(Department department)
        {
            string query = @" INSERT INTO dbo.Departments values (@DepartmentName) ";

            DataTable table = new DataTable();

            string v = _configuration.GetConnectionString("ApiVueJsConnection");
            string sqlDataSource = v;
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(sqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@DepartmentName", department.DepartmentName);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myConn.Close();
                }
            }

            return new JsonResult("Insert Department With SuccessFully ! ");
        }


        [HttpPut("{DepartmentId}")]
        public JsonResult Put(Department department)
        {
            string query = @" Update dbo.Departments 
                            SET DepartmentName = @DepartmentName 
                             WHERE DepartmentId = @DepartmentId";

            DataTable table = new DataTable();

            string v = _configuration.GetConnectionString("ApiVueJsConnection");
            string sqlDataSource = v;
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(sqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@DepartmentId", department.DepartmentId);
                    myCommand.Parameters.AddWithValue("@DepartmentName", department.DepartmentName);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myConn.Close();
                }
            }

            return new JsonResult("Update Department With SuccessFully ! ");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @" DELETE FROM dbo.Departments 
                             WHERE DepartmentId = @DepartmentId";

            DataTable table = new DataTable();

            string v = _configuration.GetConnectionString("ApiVueJsConnection");
            string sqlDataSource = v;
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(sqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@DepartmentId", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myConn.Close();
                }
            }

            return new JsonResult("Deleted Department With SuccessFully ! ");
        }

    }
}
