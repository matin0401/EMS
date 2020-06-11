﻿using EMS.Core.Models;
using System.Linq;


namespace EMS.Core.Contracts
{
    public interface IRepository<T> where T : BaseClass
    {
        IQueryable<T> Collection();
        void Commit();
        void Delete(string Id);
        T Find(string Id);
        void Insert(T t);
        void Update(T t);
    }
}