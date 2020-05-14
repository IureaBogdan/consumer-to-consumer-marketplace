using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using ViewModels.Account;

namespace DataAccess.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        void Add(Account account);
        void Edit(AccountDetailsViewModel model);
        Account GetAccountByEmail(string email);
        Account GetAccountById(Guid id);
        Account GetAccountByUsername(string username);
        List<Account> GetAccounts();
        IQueryable<Account> Query();
        void Remove(Account account);
    }
}