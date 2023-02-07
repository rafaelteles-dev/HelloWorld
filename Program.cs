using System;
using Serilog;

namespace HelloWorld
{
    class Program
    {
        static string Pessoas()
        {
            string nome = "rafael";
            int idade = 31;
            return nome;
        }
        static void Main()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs/myapp.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        
            Log.Information("Hello, World!");

            int a = 10, b = 0;
            try
            {
                Log.Debug("Dividing {A} by {B}", a, b);
                Console.WriteLine(a / b);
            }

            catch (Exception ex)
            {
                Log.Error(ex, "Something went wrong");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
