using System.Threading;

namespace Composition
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = new Logger();

            var dbMigratior = new DbMigrator(logger);
            var installer = new Installer(logger);

            dbMigratior.Migrate();
            installer.Install();
            Thread.Sleep(2000);
        }
    }
}
