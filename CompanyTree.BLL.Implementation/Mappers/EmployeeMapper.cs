using CompanyTree.Entities;
using CompanyTree.Models;
using CompanyTree.Models.Abstractions;

namespace CompanyTree.BLL.Implementation.Mappers
{
    class EmployeeMapper : GenericMapper<EmployeeEntity, Employee>
    {
        public override Employee Map(EmployeeEntity entity)
        {
            //Employee employee = new EmployeeComposite(entity.Name, entity.Salary, entity.positionId, entity.supervisorId);
            return null;
        }

        public override EmployeeEntity Map(Employee model)
        {
            EmployeeEntity entity = new EmployeeEntity();
            entity.Name = model.Name;
            entity.Salary = model.Salary;
            //entity.positionId = model.Position;
            return entity;
        }
    }
}