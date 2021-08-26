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
    }
}
