using System;
using PostStore.PostDomain.PostsAggregate;

namespace PostDomain
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository Repo { get; }       
        int Complete();
    }
}
