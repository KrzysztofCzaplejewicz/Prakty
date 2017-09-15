using System;

namespace PolymorhismExercise3
{
    public class SqlConnection : DbConnection
    {

        public override void Open()
        {
            Console.WriteLine("You are openning Sql " + ConnectionString);
        }

        public override void Close()
        {
            Console.WriteLine("You are closing Sql " + ConnectionString);
        }

        public SqlConnection(string connectionString) : base(connectionString)
        {
        }
    }
}