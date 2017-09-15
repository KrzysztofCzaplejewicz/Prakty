using System;

namespace PolymorhismExercise3
{
    public abstract class DbConnection
    {
        public string ConnectionString { get; set; }
        public TimeSpan TimeOut { get; set; }

        protected DbConnection(string connectionString)
        {
            ConnectionString = connectionString ?? throw new InvalidOperationException("Cannot open a database without ConnectionString");
        }

        public abstract void Open();
        public abstract void Close();

    }
}