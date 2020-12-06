using CompanyTree.BLL.Abstraction.Services;

namespace CompanyTree.UI
{
    public class CliController
    {
        private CliView _view;
        private ICompanyTreeService _companyTreeService;

        public CliController(ICompanyTreeService companyTreeService, CliView cliView)
        {
            _companyTreeService = companyTreeService;
            _view = cliView;
        }
        
        public void ShowMenu()
        {
            MainMenu userVariant = (MainMenu)(_view.Main()-1);
            switch (userVariant)
            {
                case MainMenu.SelectFindWithMaxSalary:
                    _companyTreeService.GetEmployeesWithMaxSalary(_companyTreeService.GetRoot());
                    break;
            }
            
        }
    }
}