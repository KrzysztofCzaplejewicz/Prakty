using System;

namespace PolymorhismExercise3
{
    public class DbCommand
    {
        public DbConnection DbConnection { get; set; }
        public string Instruction { get; set; }

        public DbCommand(DbConnection dbConnection, string instruction)
        {
            if (dbConnection == null || instruction == null)
                throw new InvalidOperationException("dbConnection or Instruction is null");
            DbConnection = dbConnection;
            Instruction = instruction;
        }

        public void Execute()
        {
            DbConnection.Open();
            Console.WriteLine(Instruction);
            DbConnection.Close();
        }
    }
}