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
    public class EmployeeController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Get List of Employees 

        [HttpGet]
        public JsonResult Get()
        {
            string query = @" SELECT EmployeeId, EmployeeName, Department, 
                                     CONVERT(varchar(10),DateOfJoining,120) AS 'DateOfJoining',
                                     PhotoFileName
                               FROM dbo.Employees ";

            DataTable table = new DataTable();

            string v = _configuration.GetConnectionString("ApiVueJsConnection");
            string sqlDataSource = v;
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(sqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
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
            string query = @" SELECT EmployeeId, EmployeeName, Department, 
                                     CONVERT(varchar(10),DateOfJoining,120) AS 'DateOfJoining',
                                     PhotoFileName
                               FROM dbo.Employees
                               WHERE EmployeeId = @EmployeeId ";

            DataTable table = new DataTable();

            string v = _configuration.GetConnectionString("ApiVueJsConnection");
            string sqlDataSource = v;
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(sqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@EmployeeId", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myConn.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(Employee employee)
        {
            string query = @" INSERT INTO dbo.Employees 
                            (EmployeeName, Department, DateOfJoining, PhotoFileName) 
                             values 
                            (@EmployeeName, @Department, @DateOfJoining, @PhotoFileName)";

            DataTable table = new DataTable();

            string v = _configuration.GetConnectionString("ApiVueJsConnection");
            string sqlDataSource = v;
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(sqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName );
                    myCommand.Parameters.AddWithValue("@Department", employee.Department);
                    myCommand.Parameters.AddWithValue("@DateOfJoining", employee.DateOfJoining);
                    myCommand.Parameters.AddWithValue("@PhotoFileName", employee.PhotoFileName);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myConn.Close();
                }
            }

            return new JsonResult("Insert Employee With SuccessFully ! ");
        }


        [HttpPut("{EmployeeId}")]
        public JsonResult Put(Employee employee)
        {
            string query = @" Update dbo.Employees 
                                 SET EmployeeName = @EmployeeName 
                              WHERE EmployeeID = @EmployeeID
                            ";

            DataTable table = new DataTable();

            string v = _configuration.GetConnectionString("ApiVueJsConnection");
            string sqlDataSource = v;
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(sqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);
                    myCommand.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
                    myCommand.Parameters.AddWithValue("@Department", employee.Department);
                    myCommand.Parameters.AddWithValue("@DateOfJoining", employee.DateOfJoining);
                    myCommand.Parameters.AddWithValue("@PhotoFileName", employee.PhotoFileName);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myConn.Close();
                }
            }

            return new JsonResult("Update Employee With SuccessFully ! ");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @" DELETE FROM dbo.Employees 
                             WHERE EmployeeID = @EmployeeID";

            DataTable table = new DataTable();

            string v = _configuration.GetConnectionString("ApiVueJsConnection");
            string sqlDataSource = v;
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(sqlDataSource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@EmployeeID", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myConn.Close();
                }
            }

            return new JsonResult("Deleted Employee With SuccessFully ! ");
        }

    }
}
