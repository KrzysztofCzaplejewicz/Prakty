using System;

namespace PolymorhismExercise3
{
    public class OracleConnection : DbConnection
    {

        public override void Open()
        {
            Console.WriteLine("You are openning Oracle " + ConnectionString);
        }

        public override void Close()
        {
            Console.WriteLine("You are closing Oracle " + ConnectionString);
        }

        public OracleConnection(string connectionString) : base(connectionString)
        {
        }
    }
}