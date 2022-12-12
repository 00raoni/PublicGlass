using System.Collections.Generic;

namespace AutoGlass.Application
{
    public interface IRepository<TEntidade>
    {
        List<TEntidade> Find();
        TEntidade FindById(int id);
        void Add(TEntidade entity);
    }
}
