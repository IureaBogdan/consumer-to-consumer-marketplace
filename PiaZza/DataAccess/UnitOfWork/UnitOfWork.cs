﻿using DataAccess.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context.PiazzaDbContext _piazzaDbContext;
        public UnitOfWork(Context.PiazzaDbContext piazzaDbContext)
        {
            _piazzaDbContext = piazzaDbContext;
        }
        public void Commit()
        {
            _piazzaDbContext.SaveChanges();
            _piazzaDbContext.Dispose();
        }
    }
}
