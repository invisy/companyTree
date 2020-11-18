namespace CompanyTree.Models.Abstractions
{
    public interface IVisitable
    {
        void Accept(IVisitor visitor);
    }
}