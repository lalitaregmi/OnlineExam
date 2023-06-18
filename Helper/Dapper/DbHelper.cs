using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper.Dapper
{
    public class DbHelper
    {

        public static SqlConnection GetConnection()
        {
           //String ConnectionStrings = "Server=DESKTOP-IC5S7IR;database=OnlineExamination;Integrated Security=true;Trust Server Certificate= True; ";
            String ConnectionStrings = "Server=WIN-PLO3PGFAQN8\\SQLEXPRESS;Database=OnlineExamination;user id=sa;password=sa@123;MultipleActiveResultSets=true;Encrypt=false;";

            var sqlconnection = new SqlConnection(ConnectionStrings);
            sqlconnection.Open();
            return sqlconnection;
        }

        public static SqlConnection GetConnection(string conn)
        {
            var sqlconnection = new SqlConnection(conn);
            sqlconnection.Open();
            return sqlconnection;
        }

        public async static Task<IEnumerable<T>> RunProc<T>(string sql, object param = null)
        {
            using (var conn = GetConnection())
            {
                var data = await conn.QueryAsync<T>(sql, param, commandType: CommandType.StoredProcedure);
                return data;

            }
        }

        public async static Task<IEnumerable<T>> RunProc<T>(string sql, string conne, object param = null)
        {
            using (var conn = GetConnection(conne))
            {
                var data = await conn.QueryAsync<T>(sql, param, commandType: CommandType.StoredProcedure);
                return data;
            }
        }

        public async static Task<IEnumerable<T>> RunQuery<T>(string sql, object param = null)
        {
            using (var conn = GetConnection())
            {
                var data = await conn.QueryAsync<T>(sql, param);
                return data;
            }
        }
        public async static Task<dynamic> RunQueryWithoutModel(string sql, object param = null)
        {
            using (var conn = GetConnection())
            {
                var data = await conn.QueryAsync(sql, param);
                return data;
            }
        }

    }

}

