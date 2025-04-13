using CompostaAqui.Domain.Repositories;

namespace CompostaAqui.Domain.UnitOfWorks
{
    public interface IUnitOfWorkCompostaqui : IUnitOfWork
    {
        IComposterRepository Composter { get; }

        bool InTransaction();
    }
}
