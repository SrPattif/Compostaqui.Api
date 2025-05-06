namespace CompostaAqui.Domain.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
