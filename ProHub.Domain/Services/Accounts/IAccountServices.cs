using Microsoft.AspNetCore.Identity;
using ProHub.Domain.Dtos;
using ProHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProHub.Domain.Dtos.Accounts;
using X.PagedList;

namespace ProHub.Domain.Services.Accounts
{
    public interface IAccountServices : IDisposable
    {
        //Task<ApplicationUser> GetUserByEmailAsync(string email);
        ////Task<(Account account, SignInResult signInResult)> Login(LoginDto loginDto);
        //Task<bool> IsExist(string email);

        //Task<string> GetUserByEmailCodeAsync(string email);
        //Task<IdentityResult> ConfirmEmailAsync(string email, string code);

        //Task<bool> AddEstablishment(Establishment establishment);
        Task<IdentityResult> AddRole(string name);
        Task<IdentityResult> CreateAccount(AccountDto accountDto);
        Task<(bool Succeeded, string[] Errors)> ResetPassword(Account user, string newPassword);
        Task<(bool Succeeded, Account account)> Login(string username, string password);
        Task<Account> GetUser(string username, string password);

        Task<bool> CheckPasswordAsync(Account user, string password);
        Task<(bool Succeeded, string[] Errors)> CreateUserAsync(Account user, IEnumerable<string> roles, string password);
        Task<(bool Succeeded, string[] Errors)> DeleteRoleAsync(AccountRole role);
        Task<(bool Succeeded, string[] Errors)> DeleteRoleAsync(string roleName);
        Task<(bool Succeeded, string[] Errors)> DeleteUserAsync(Account user);
        Task<(bool Succeeded, string[] Errors)> DeleteUserAsync(string userId);
        Task<AccountRole> GetRoleByIdAsync(string roleId);
        Task<AccountRole> GetRoleByNameAsync(string roleName);
        Task<Account> GetUserByEmailAsync(string email);
        Task<Account> GetUserByIdAsync(string userId);
        Task<Account> GetUserByUserNameAsync(string userName);
        Task<IList<string>> GetUserRolesAsync(Account user);
        Task<(bool Succeeded, string[] Errors)> ResetPasswordAsync(Account user, string newPassword);

        Task<(bool Succeeded, string[] Errors)> UpdatePasswordAsync(Account user, string currentPassword, string newPassword);
        Task<(bool Succeeded, string[] Errors)> UpdateUserAsync(Account user);
        Task<(bool Succeeded, string[] Errors)> UpdateUserAsync(Account user, IEnumerable<string> roles);

        //Task<List<AccountDto>> AccountList(int establishmentId);

        Task<IPagedList<AccountDto>> AccountList(int establishmentId, int pageNumber = 1, int pageSize = 15);

    }
}
