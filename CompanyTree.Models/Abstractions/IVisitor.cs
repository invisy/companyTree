using CompanyTree.Models.Managers;

namespace CompanyTree.Models.Abstractions
{
    public interface IVisitor
    {
        void Visit(Director employee);
        void Visit(Manager employee);
        void Visit(SimpleEmployee employee);
    }
}