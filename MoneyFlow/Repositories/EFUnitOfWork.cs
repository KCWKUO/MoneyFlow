using MoneyFlow.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MoneyFlow.Repositories
{
    public class EFUnitOfWork
    {
        public DbContext Context { get; set; }

        /// <summary>
        /// 定義要使用的資料庫物件
        /// </summary>
        public EFUnitOfWork()
        {
            Context = new SkillTreeHomeworkEntities();
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}