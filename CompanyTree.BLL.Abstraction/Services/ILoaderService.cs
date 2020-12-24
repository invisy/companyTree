using CompanyTree.Models.Abstractions;

namespace CompanyTree.BLL.Abstraction.Services
{
    public interface ILoaderService
    {
        void setRoot(Employee employee);
        Employee getRoot();
        void LoadData();
        void SaveData();
    }
}