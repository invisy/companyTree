using System;
using CompanyTree.BLL.Implementation;
using CompanyTree.Utils;

namespace CompanyTree.UI
{
    internal class Program
    {     
        private static void Main(string[] args)
        {
            IIoCContainer container = new MyIoCContainer();
            container.Register<CliController, CliController>();
            container.Register<CliView, CliView>();
            container.BindBLL();
            CliController controller = container.Resolve<CliController>();
            controller.ShowMenu();
        }
    }
}