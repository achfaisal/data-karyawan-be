using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using DataKaryawan.Models;
using DataKaryawan.Repository;
using NLog;
using System.Data.SqlClient;

namespace DataKaryawan.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataKaryawanController : ControllerBase
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly DataKaryawanProc _proc;

        public DataKaryawanController(IConfiguration configuration)
        {
            _proc = new DataKaryawanProc(configuration);
        }

        [HttpPost("get-all")]
        public IActionResult GetAllKaryawan([FromBody] DataEmp dataEmp)
        {
            RetvalResponse response = new RetvalResponse();

            try
            {
                Entities ent = _proc.GetDataKaryawan(dataEmp);
                if (ent.Data != null && ent.Data.Rows.Count > 0)
                {
                    response.Retval = "Success";
                    response.Data = ent.Data;
                    response.Total = ent.Total.ToString();
                }
                else
                {
                    response.Retval = "No Data Found";
                }

                return Ok(response);
            }
            catch (SqlException ex)
            {
                logger.Error(ex, "[SQL Error] GetAllKaryawan failed");
                response.Retval = "SQL Error: " + ex.Message;
                return StatusCode(500, response);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "[Server Error] GetAllKaryawan failed");
                response.Retval = "Server Error: " + ex.Message;
                return StatusCode(500, response);
            }
        }

        [HttpPost("get-details")]
        public IActionResult GetDataKaryawanDetails([FromBody] DataEmp dataEmp)
        {
            RetvalResponse response = new RetvalResponse();

            try
            {
                Entities ent = _proc.GetDataKaryawanDetails(dataEmp);
                if (ent.Data != null && ent.Data.Rows.Count > 0)
                {
                    response.Retval = "Success";
                    response.Data = ent.Data;
                }
                else
                {
                    response.Retval = "No Data Found";
                }

                return Ok(response);
            }
            catch (SqlException ex)
            {
                logger.Error(ex, "[SQL Error] GetDataKaryawanDetails failed");
                response.Retval = "SQL Error: " + ex.Message;
                return StatusCode(500, response);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "[Server Error] GetDataKaryawanDetails failed");
                response.Retval = "Server Error: " + ex.Message;
                return StatusCode(500, response);
            }
        }

        [HttpPost("insert")]
        public IActionResult InsertDataKaryawan([FromBody] DataEmp dataEmp)
        {
            RetvalResponse response = new RetvalResponse();

            try
            {
                string insertStatus = _proc.InsertDataKaryawan(dataEmp);

                response.Retval = insertStatus;

                return Ok(response);
            }
            catch (SqlException ex)
            {
                logger.Error(ex, "[SQL Error] InsertDataKaryawan failed");
                response.Retval = "SQL Error: " + ex.Message;
                return StatusCode(500, response);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "[Server Error] InsertDataKaryawan failed");
                response.Retval = "Server Error: " + ex.Message;
                return StatusCode(500, response);
            }
        }


        [HttpPost("update")]
        public IActionResult UpdateDataKaryawan([FromBody] DataEmp dataEmp)
        {
            RetvalResponse response = new RetvalResponse();

            try
            {
                string updateStatus = _proc.UpdateDataKaryawan(dataEmp);

                response.Retval = updateStatus;
                return Ok(response);
            }
            catch (SqlException ex)
            {
                logger.Error(ex, "[SQL Error] UpdateDataKaryawan failed");
                response.Retval = "SQL Error: " + ex.Message;
                return StatusCode(500, response);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "[Server Error] UpdateDataKaryawan failed");
                response.Retval = "Server Error: " + ex.Message;
                return StatusCode(500, response);
            }
        }


    }
}
