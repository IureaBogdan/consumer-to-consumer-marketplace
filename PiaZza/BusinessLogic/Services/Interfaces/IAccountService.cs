using DataAccess.Entities;
using System;
using System.Collections.Generic;
using ViewModels.Account;

namespace BusinessLogic.Services.Interfaces
{
    public interface IAccountService
    {
        bool CheckAccountByUsernamePassword(string username, string password);
        Account GetAccountById(Guid id);
        Account GetAccountByUsername(string userName);
        string GetAccountPasswordById(Guid id);
        List<Account> GetAccounts();
        Guid RegisterAccount(AccountCreateViewModel model);
        void SaveChanges();
        bool UpdateAccountCredentials(AccountDetailsViewModel model);
    }
}