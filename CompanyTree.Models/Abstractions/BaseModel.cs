namespace CompanyTree.Models.Abstractions
{

    public abstract class BaseModel<TKey>
    {
        protected static int counter = 0;
        public TKey Id { get; set; }
    }
}