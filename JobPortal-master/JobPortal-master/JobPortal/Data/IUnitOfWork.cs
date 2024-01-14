namespace JobPortal.Data
{
    public interface IUnitOfWork
    {
        Task<int> Save();
    }
}
