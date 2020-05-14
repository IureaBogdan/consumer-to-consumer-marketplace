using DataAccess.Context;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using ViewModels.Account;

namespace DataAccess.Repositories
{
    public class AccountRepository
    {
        private readonly PiazzaDbContext _dbContext;
        public AccountRepository(PiazzaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IQueryable<Account> Query()
        {
            return _dbContext.Accounts.AsQueryable();
        }
        public Account GetAccountById(Guid id)
        {
            Account account = _dbContext.Accounts
                .Include(off => off.Offers)
                .Where(acc => acc.AccountId == id)
                .FirstOrDefault();
            return account;
        }
        public List<Account> GetAccounts()
        {
            return _dbContext.Accounts.ToList();
        }
        public Account GetAccountByEmail(string email)
        {
            Account account = _dbContext.Accounts
                .Include(off => off.Offers)
                .Where(acc => acc.Email == email)
                .FirstOrDefault();
            return account;
        }
        public Account GetAccountByUsername(string username)
        {
            Account account = _dbContext.Accounts
                .Include(off => off.Offers)
                .Where(acc => acc.UserName == username)
                .FirstOrDefault();
            return account;
        }
        public void Add(Account account)
        {
            _dbContext.Accounts.Add(account);
        }
        public void Remove(Account account)
        {
            _dbContext.Accounts.Remove(account);
        }
        public void Edit(AccountDetailsViewModel model)
        {
            Account account = GetAccountById(model.Id);
            account.FirstName = model.FirstName;
            account.Email = model.Email;
            account.LastName = model.LastName;
            account.Adress = model.Adress;
            account.ImageLink = model.ImageLink;
            account.Password = model.Password;
            account.PhoneNumber = model.PhoneNumber;
        }
    }
}
