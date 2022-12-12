using System.Threading.Tasks;

namespace AutoGlass.Aplicacao
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
