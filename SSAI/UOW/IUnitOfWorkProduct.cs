using SSAI.Entity.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSAI.UOW
{
    public interface IUnitOfWorkProduct : IDisposable
    {
        IProductRepository Products { get; }
        int Save();
    }
}
