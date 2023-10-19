using Microsoft.Extensions.DependencyInjection;
using PresentationLayer;
using System.Text;

public class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        var services = new ServiceCollection();
        services.AddTransient<IExecuter, Executer>();
        services.BuildServiceProvider().GetService<IExecuter>().execute();

    }
}