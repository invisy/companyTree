namespace CompanyTree.Models.Abstractions
{
    public interface IVisitor
    {
        void Visit(EmployeeComposite employee);
        void Visit(EmployeeLeaf employee);
    }
}