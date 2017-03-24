using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MoneyFlow.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Context
        /// </summary>
        DbContext Context { get; set; }

        /// <summary>
        /// Save change
        /// </summary>
        void Save();
    }
}