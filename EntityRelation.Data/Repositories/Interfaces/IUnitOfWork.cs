using System;
using System.Collections.Generic;
using System.Text;

namespace EntityRelation.Data.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        void Save();
        void Rollback();
        void Dispose();
    }
}
