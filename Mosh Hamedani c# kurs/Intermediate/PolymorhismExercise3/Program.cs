using System;

namespace PolymorhismExercise3
{
    class Program
    {

        static void Main(string[] args)
        {
            var sql = new SqlConnection("sqlConnectionString");
            var oracle = new OracleConnection("OracleConnectionString");

            var dbsql = new DbCommand(sql, "I SHALL PASS");
            dbsql.Execute();

            Console.WriteLine("-----------------------------");

            var dboracle = new DbCommand(oracle, "I SHALL PASS");
            dboracle.Execute();
        }
    }
}

