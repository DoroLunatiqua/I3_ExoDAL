﻿using Common.Repositories;
using DAL.Entities;
using DAL.Mappers;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class CocktailService : ICocktailRepositories<Cocktail>
    {
        private const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WAD24-DemoASP-DB;Integrated Security=True;";

        public IEnumerable<Cocktail> Get()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Cocktail_GetAll";
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToCocktail();
                        }
                    }

                }
            }
        }

        public Cocktail Get(Guid cocktail_id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Cocktail.GetById";
                    command.CommandType= CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(cocktail_id), cocktail_id);
                    connection.Open();
                     
                   using (SqlDataReader reader = command.ExecuteReader()) 
                    {
                        if (reader.Read())
                        {
                            return reader.ToCocktail();
                        }
                        else throw new ArgumentOutOfRangeException(nameof(cocktail_id));
                    }

                }
            }
        }

        public IEnumerable<Cocktail> GetByUser(Guid user_id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Cocktail.GetByUserId";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(user_id), user_id);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToCocktail();
                        }
                    }
                }
            }
        }

        public Guid Insert(Cocktail cocktail)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Cocktail_Insert";
                    command.CommandType=CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(Cocktail.Name),cocktail.Name);
                    command.Parameters.AddWithValue(nameof(Cocktail.Instruction),cocktail.Instruction);
                    command.Parameters.AddWithValue(nameof(Cocktail.Description),cocktail.Description);
                    command.Parameters.AddWithValue(nameof(Cocktail.CreateBy), cocktail.CreateBy);
                    connection.Open();

                    return (Guid)command.ExecuteScalar();

                }
            }
        }

        public void Update(Guid cocktail_id, Cocktail cocktail)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Cocktail_Update";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(Cocktail.Name), cocktail.Name);
                    command.Parameters.AddWithValue(nameof(Cocktail.Instruction), cocktail.Instruction);
                    command.Parameters.AddWithValue(nameof(Cocktail.Description), cocktail.Description);
                    command.Parameters.AddWithValue(nameof(cocktail_id), cocktail_id);
                    connection.Open();
                    command.ExecuteNonQuery();

                }
            }
        }
        public void Delete(Guid cocktail_id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Cocktail_Delete";
                    command.CommandType= CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(cocktail_id), cocktail_id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
