using DataKaryawan.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DataKaryawan.Repository
{
    public class DataKaryawanProc
    {
        private readonly string _connectionString;

        public DataKaryawanProc(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Connect");
        }

        public Entities GetDataKaryawan(DataEmp dataEmp)
        {
            Entities ent = new Entities();

            try
            {
                using SqlConnection conn = new SqlConnection(_connectionString);
                conn.Open();

                using SqlCommand cmd = new SqlCommand("spDataKaryawanGetPaging", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CurrentPage", SqlDbType.Int).Value = dataEmp.CurrentPage;
                cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = dataEmp.PageSize;

                SqlParameter totalParam = new SqlParameter("@Total", SqlDbType.Int);
                totalParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(totalParam);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                ent.Data = dt;
                ent.Total = Convert.ToInt32(totalParam.Value);

                return ent;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public Entities GetDataKaryawanDetails(DataEmp dataEmp)
        {
            Entities ent = new Entities();
            try
            {
                using SqlConnection conn = new SqlConnection(_connectionString);
                conn.Open();
                using SqlCommand cmd = new SqlCommand("spDataKaryawanBaruGetDetails", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@emp_no", SqlDbType.VarChar, 50).Value = dataEmp.emp_no;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                ent.Data = dt;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error GetDataKaryawanDetails: {ex.Message}");
            }

            return ent;
        }

        public string InsertDataKaryawan(DataEmp dataEmp)
        {
            string statusInsert = "";

            try
            {
                using SqlConnection conn = new SqlConnection(_connectionString);
                using SqlCommand cmd = new SqlCommand("spDataKaryawanBaruInsert", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@emp_no", SqlDbType.VarChar, 50).Value = dataEmp.emp_no;
                cmd.Parameters.Add("@emp_name", SqlDbType.VarChar, 100).Value = dataEmp.emp_name;
                cmd.Parameters.Add("@emp_email", SqlDbType.VarChar, 50).Value = dataEmp.emp_email;
                cmd.Parameters.Add("@worklocation", SqlDbType.VarChar, 50).Value = dataEmp.worklocation;
                cmd.Parameters.Add("@alamat", SqlDbType.VarChar, 8000).Value = dataEmp.alamat;
                cmd.Parameters.Add("@no_hp", SqlDbType.VarChar, 50).Value = dataEmp.no_hp;
                cmd.Parameters.Add("@jabatan", SqlDbType.VarChar, 50).Value = dataEmp.jabatan;
                cmd.Parameters.Add("@join_date", SqlDbType.VarChar, 50).Value = dataEmp.join_date;

                cmd.Parameters.Add("@spv_emp_no", SqlDbType.VarChar, 50).Value = dataEmp.spv_emp_no;
                cmd.Parameters.Add("@spv_name", SqlDbType.VarChar, 100).Value = dataEmp.spv_name;
                cmd.Parameters.Add("@spv_email", SqlDbType.VarChar, 50).Value = dataEmp.spv_email;

                cmd.Parameters.Add("@mgr_emp_no", SqlDbType.VarChar, 50).Value = dataEmp.mgr_emp_no;
                cmd.Parameters.Add("@mgr_name", SqlDbType.VarChar, 100).Value = dataEmp.mgr_name;
                cmd.Parameters.Add("@mgr_email", SqlDbType.VarChar, 50).Value = dataEmp.mgr_email;

                SqlParameter retvalParam = new SqlParameter("@retval", SqlDbType.Int)
                {
                    Direction = ParameterDirection.ReturnValue
                };
                cmd.Parameters.Add(retvalParam);

                conn.Open();
                cmd.ExecuteNonQuery();

                int retval = Convert.ToInt32(retvalParam.Value);

                if (retval == -1)
                    statusInsert = "Duplicate data";
                else if (retval == 1)
                    statusInsert = "Insert success";
                else
                    statusInsert = "Insert failed";
            }
            catch (SqlException ex)
            {
                throw new Exception($"SQL Error InsertDataKaryawan: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error InsertDataKaryawan: {ex.Message}");
            }

            return statusInsert;
        }


        public string UpdateDataKaryawan(DataEmp dataEmp)
        {
            string statusUpdate = "";

            try
            {
                using SqlConnection conn = new SqlConnection(_connectionString);
                using SqlCommand cmd = new SqlCommand("spDataKaryawanBaruUpdate", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id", SqlDbType.VarChar, 50).Value = dataEmp.id;
                cmd.Parameters.Add("@emp_no", SqlDbType.VarChar, 50).Value = dataEmp.emp_no;
                cmd.Parameters.Add("@emp_name", SqlDbType.VarChar, 100).Value = dataEmp.emp_name;
                cmd.Parameters.Add("@emp_email", SqlDbType.VarChar, 50).Value = dataEmp.emp_email;
                cmd.Parameters.Add("@worklocation", SqlDbType.VarChar, 50).Value = dataEmp.worklocation;
                cmd.Parameters.Add("@alamat", SqlDbType.VarChar, 8000).Value = dataEmp.alamat;
                cmd.Parameters.Add("@no_hp", SqlDbType.VarChar, 50).Value = dataEmp.no_hp;
                cmd.Parameters.Add("@jabatan", SqlDbType.VarChar, 50).Value = dataEmp.jabatan;
                cmd.Parameters.Add("@join_date", SqlDbType.VarChar, 50).Value = dataEmp.join_date;
                cmd.Parameters.Add("@spv_emp_no", SqlDbType.VarChar, 50).Value = dataEmp.spv_emp_no;
                cmd.Parameters.Add("@spv_name", SqlDbType.VarChar, 100).Value = dataEmp.spv_name;
                cmd.Parameters.Add("@spv_email", SqlDbType.VarChar, 50).Value = dataEmp.spv_email;
                cmd.Parameters.Add("@mgr_emp_no", SqlDbType.VarChar, 50).Value = dataEmp.mgr_emp_no;
                cmd.Parameters.Add("@mgr_name", SqlDbType.VarChar, 100).Value = dataEmp.mgr_name;
                cmd.Parameters.Add("@mgr_email", SqlDbType.VarChar, 50).Value = dataEmp.mgr_email;

                SqlParameter retvalParam = new SqlParameter("@retval", SqlDbType.Int)
                {
                    Direction = ParameterDirection.ReturnValue
                };
                cmd.Parameters.Add(retvalParam);

                conn.Open();
                cmd.ExecuteNonQuery();

                int retval = Convert.ToInt32(retvalParam.Value);

                if (retval == 1)
                    statusUpdate = "Update success";
                else if (retval == -1)
                    statusUpdate = "Data not found";
                else
                    statusUpdate = "Update failed";
            }
            catch (SqlException ex)
            {
                throw new Exception($"SQL Error UpdateDataKaryawan: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error UpdateDataKaryawan: {ex.Message}");
            }

            return statusUpdate;
        }


    }
}
