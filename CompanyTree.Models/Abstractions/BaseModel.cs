namespace CompanyTree.Models.Abstractions
{

    public abstract class BaseModel<TKey>
    {
        public TKey Id { get; set; }
    }
}