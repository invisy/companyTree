using System;
using CompanyTree.BLL.Implementation;
using CompanyTree.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyTree.UI
{
    internal class Program
    {     
        private static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
            .AddTransient<CliController, CliController>()
            .AddTransient<CliView, CliView>()
            .BindBLL()
            .BuildServiceProvider();

            CliController controller = serviceProvider.GetService<CliController>();
            controller.ShowMenu();
        }
    }
}