using CompanyTree.Models.Abstractions;

namespace CompanyTree.BLL.Abstraction.Services
{
    public interface ILoaderService
    {
        Employee LoadData();
        void SaveData(Employee employee);
    }
}