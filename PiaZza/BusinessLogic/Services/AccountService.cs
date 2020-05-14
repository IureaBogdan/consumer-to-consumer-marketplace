#region Project imports
using DataAccess.Context;
using DataAccess.Entities;
using DataAccess.Repositories;
using ViewModels;
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using ViewModels.Account;
using DataAccess.UnitOfWork;
using BusinessLogic.Services.Interfaces;
using DataAccess.Repositories.Interfaces;
using DataAccess.UnitOfWork.Interfaces;

namespace BusinessLogic.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unitOfWork;
        public AccountService(IAccountRepository accountRepository,IUnitOfWork unitOfWork)
        {
            _accountRepository = accountRepository;
            _unitOfWork = unitOfWork;
        }

        public Guid RegisterAccount(AccountCreateViewModel model)
        {
            Account accountEntry = new Account
            {
                AccountId = Guid.NewGuid(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                Adress = model.Adress,
                Email = model.Email,
                Password = model.Password,
                PhoneNumber = model.PhoneNumber,
                ImageLink = model.ImageLink
            };
            _accountRepository.Add(accountEntry);
            _unitOfWork.Commit();
            return accountEntry.AccountId;
        }

        public Account GetAccountByUsername(string userName)
        {
            return _accountRepository.GetAccountByUsername(userName);
        }


        public bool CheckAccountByUsernamePassword(string username, string password)
        {

            if (_accountRepository.Query().Any(acc => acc.UserName.Equals(username.ToLower())
                                                    && acc.Password.Equals(password.ToLower()))) return true;
            else return false;
        }

        public List<Account> GetAccounts()
        {
            return _accountRepository.GetAccounts();
        }
        public bool UpdateAccountCredentials(AccountDetailsViewModel model)
        {
            if (model.Id != null)
            {
                _accountRepository.Edit(model);
                _unitOfWork.Commit();
                return true;
            }
            else
            {
                return false;
            }
        }
        public string GetAccountPasswordById(Guid id)
        {
            var account = _accountRepository.GetAccountById(id);
            return account.Password;
        }
        public Account GetAccountById(Guid id)
        {
            return _accountRepository.GetAccountById(id);
        }
        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }


    }
}
