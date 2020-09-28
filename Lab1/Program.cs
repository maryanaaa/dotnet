using System;
using Npgsql;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    class Program
    {
        private static List<object[]> GetQueryResult(NpgsqlConnection connection, string select, string from)
        {
            var sql = $"SELECT {select} FROM {from}";

            try
            {
                var queryResult = new List<object[]>();

                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int n_fields = reader.FieldCount;
                            var fields = new object[n_fields];

                            for (int i = 0; i < n_fields; ++i)
                            {
                                fields[i] = reader.GetValue(i);
                            }

                            queryResult.Add(fields);
                        }
                    }

                    return queryResult;
                }
            }
            catch (NpgsqlException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        private static void PrintData(List<object[]> data)
        {
            foreach (var record in data)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var field in record)
                {
                    sb.Append($"{field}; ");
                }

                Console.WriteLine(sb);
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            try
            {
                NpgsqlConnectionStringBuilder builder = new NpgsqlConnectionStringBuilder
                {
                    ConnectionString = "Server=127.0.0.1;Port=5432;Database=TravelAgency;User Id=postgres;Password=admin;"
                };

                using (NpgsqlConnection connection = new NpgsqlConnection(builder.ConnectionString))
                {
                    connection.Open();


                    Console.WriteLine("Клієнти (ID; Прізвище; Ім'я; По-батькові; Номер телефону; Адреса; К-сть замовлених турів)\n");
                    PrintData(GetQueryResult(connection, "*, (SELECT COUNT(*) FROM trips T WHERE T.customer_id = C.customer_id)", "customers C"));
                    Console.WriteLine("\n-------------------------------------------------------------------------------------------------------------------------------------\n");


                    Console.WriteLine("Тури (ID; Назва; Тривалість, дні; Ціна, грн.; Опис)\n");
                    PrintData(GetQueryResult(connection, "*", "tours"));
                    Console.WriteLine("\n-------------------------------------------------------------------------------------------------------------------------------------\n");


                    Console.WriteLine("Поїздки (ID; Прізвище; Ім'я; По-батькові; Назва туру; Дата; Тривалість, дні; Знижка, %)\n");
                    PrintData(GetQueryResult(connection,
                        "CONCAT_WS(' ', C.last_name, C.first_name, C.surname), T.name, TR.trip_date, T.duration, TR.discount",
                        "customers C INNER JOIN trips TR ON C.customer_id = TR.customer_id INNER JOIN tours T ON TR.tour_id = T.tour_id"));

                }
            }
            catch (NpgsqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
