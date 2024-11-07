using HotelSearch.API.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace HotelSearch.API.DAL
{
    public class DataLayer
    {
        private readonly string _connectionString;

        public DataLayer(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<T>> GetData<T>(string storedProcedure, List<SqlParameter> parameters)
        {
            var result = new List<T>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand(storedProcedure, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters.ToArray());
                    }

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var item = MapData<T>(reader);
                            result.Add(item);
                        }
                    }
                }
            }

            return result;
        }

        public async Task<int> ExecuteNonQuery(string storedProcedure, List<SqlParameter> parameters)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand(storedProcedure, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters.ToArray());
                    }

                    return await command.ExecuteNonQueryAsync();
                }
            }
        }

        private T MapData<T>(SqlDataReader reader)
        {
            var item = Activator.CreateInstance<T>();

            if (item is HotelModel hotel)
            {
                hotel.Id = reader["Id"] != DBNull.Value ? (int)reader["Id"] : 0;
                hotel.Name = reader["Name"] != DBNull.Value ? reader["Name"].ToString() : String.Empty;
                hotel.Price = reader["Price"] != DBNull.Value ? (double)reader["Price"] : 0;
                hotel.Latitude = reader["Latitude"] != DBNull.Value ? (double)reader["Latitude"] : 0;
                hotel.Longitude = reader["Longitude"] != DBNull.Value ? (double)reader["Longitude"] : 0;
            }

            return item;
        }
    }
}

