using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ProHub.Core.Dtos;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProHub.Core.Dtos.Accounts;
using ProHub.Core.Extensions;
using ProHub.Data.Entities;
using ProHub.Data.UnitofWork;
using X.PagedList;

namespace ProHub.Core.Services.Accounts
{
    public class AccountServices : IAccountServices
    {
        private readonly UserManager<Account> _userManager;
        private readonly SignInManager<Account> _signInManager;
        private readonly RoleManager<AccountRole> _roleManager;
        private readonly IMapper _mapperHelper;
        private readonly IUnitOfWork _unitOfWork;

        public AccountServices(
            UserManager<Account> userManager,
            SignInManager<Account> signInManager,
            RoleManager<AccountRole> roleManager,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._roleManager = roleManager;
            this._mapperHelper = mapper;
            this._unitOfWork = unitOfWork;
        }

        //public async Task<bool> AddEstablishment(Establishment establishment)
        //{
        //    _unitOfWork.EstablishmentRepository.Insert(establishment);

        //    return await _unitOfWork.SaveAsync();
        //}


        //public async Task<List<AccountDto>> AccountList(int establishmentId)
        //{
        //    var accounts = await _unitOfWork.RepositoryOf<Account>()
        //        .FindAsync(x => x.EstablishmentId == establishmentId, disableTracking: true);
        //    return _mapperHelper.Map<List<AccountDto>>(accounts);
        //}



        public async Task<IPagedList<AccountDto>> AccountList(int establishmentId, int pageNumber = 1, int pageSize = 15)
        {
            var accounts = await _unitOfWork.RepositoryOf<Account>()
                .FindPagedAsync(x => x.EstablishmentId == establishmentId,
                    orderBy: o => o.OrderByDescending(a => a.InsertDate),
                    disableTracking: true);
            var pagedResult = await accounts.ToPagedListAsync(pageNumber, pageSize);
            return pagedResult.ToMapPagedList<Account, AccountDto>(_mapperHelper);
        }





        public async Task<IdentityResult> AddRole(string name)
        {
            if (await _roleManager.RoleExistsAsync(name))
                return new IdentityResult();
            return await this._roleManager.CreateAsync(new AccountRole { Name = name, Id = "1", RoleDescription = "System Admin" });

        }

        public async Task<IdentityResult> CreateAccount(AccountDto accountDto)
        {
            var account = _mapperHelper.Map<Account>(accountDto);
            var result = await _userManager.CreateAsync(account, accountDto.Password);
            return result;

        }



        public async Task<(bool Succeeded, string[] Errors)> ResetPassword(Account user, string newPassword)
        {
            string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

            var result = await _userManager.ResetPasswordAsync(user, resetToken, newPassword);
            if (!result.Succeeded)
                return (false, result.Errors.Select(e => e.Description).ToArray());

            return (true, new string[] { });
        }

        public async Task<(bool Succeeded, Account account)> Login(string username, string password)
        {

            var signResult = await _signInManager.PasswordSignInAsync(username, password, true, true);
            if (signResult.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(username);
                //  await _signInManager.SignInAsync(user, false);

                return (true, user);
            }

            return (false, null);
        }


        public async Task<Account> GetUser(string username, string password)
        {
            var account = await _userManager.FindByEmailAsync(username);
            if (account != null)
            {
                var check = await _userManager.CheckPasswordAsync(account, password);
                if (check)
                    return account;
            }
            return null;
        }




        public async Task<Account> GetUserByIdAsync(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public async Task<Account> GetUserByUserNameAsync(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

        public async Task<Account> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<IList<string>> GetUserRolesAsync(Account user)
        {
            return await _userManager.GetRolesAsync(user);
        }







        public async Task<(bool Succeeded, string[] Errors)> CreateUserAsync(Account user, IEnumerable<string> roles, string password)
        {
            user.InsertDate = DateTime.Now;
            user.Id = Guid.NewGuid().ToString();
            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
                return (false, result.Errors.Select(e => e.Description).ToArray());


            user = await _userManager.FindByNameAsync(user.UserName);

            try
            {
                result = await this._userManager.AddToRolesAsync(user, roles.Distinct());
            }
            catch
            {
                await DeleteUserAsync(user);
                throw;
            }

            if (!result.Succeeded)
            {
                await DeleteUserAsync(user);
                return (false, result.Errors.Select(e => e.Description).ToArray());
            }

            return (true, new string[] { });
        }


        public async Task<(bool Succeeded, string[] Errors)> UpdateUserAsync(Account user)
        {
            return await UpdateUserAsync(user, null);
        }


        public async Task<(bool Succeeded, string[] Errors)> UpdateUserAsync(Account user, IEnumerable<string> roles)
        {
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
                return (false, result.Errors.Select(e => e.Description).ToArray());


            if (roles != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var rolesToRemove = userRoles.Except(roles).ToArray();
                var rolesToAdd = roles.Except(userRoles).Distinct().ToArray();

                if (rolesToRemove.Any())
                {
                    result = await _userManager.RemoveFromRolesAsync(user, rolesToRemove);
                    if (!result.Succeeded)
                        return (false, result.Errors.Select(e => e.Description).ToArray());
                }

                if (rolesToAdd.Any())
                {
                    result = await _userManager.AddToRolesAsync(user, rolesToAdd);
                    if (!result.Succeeded)
                        return (false, result.Errors.Select(e => e.Description).ToArray());
                }
            }

            return (true, new string[] { });
        }


        public async Task<(bool Succeeded, string[] Errors)> ResetPasswordAsync(Account user, string newPassword)
        {
            string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

            var result = await _userManager.ResetPasswordAsync(user, resetToken, newPassword);
            if (!result.Succeeded)
                return (false, result.Errors.Select(e => e.Description).ToArray());

            return (true, new string[] { });
        }

        public async Task<(bool Succeeded, string[] Errors)> UpdatePasswordAsync(Account user, string currentPassword, string newPassword)
        {
            var result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
            if (!result.Succeeded)
                return (false, result.Errors.Select(e => e.Description).ToArray());

            return (true, new string[] { });
        }

        public async Task<bool> CheckPasswordAsync(Account user, string password)
        {
            if (!await _userManager.CheckPasswordAsync(user, password))
            {
                if (!_userManager.SupportsUserLockout)
                    await _userManager.AccessFailedAsync(user);

                return false;
            }

            return true;
        }





        public async Task<(bool Succeeded, string[] Errors)> DeleteUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user != null)
                return await DeleteUserAsync(user);

            return (true, new string[] { });
        }


        public async Task<(bool Succeeded, string[] Errors)> DeleteUserAsync(Account user)
        {
            var result = await _userManager.DeleteAsync(user);
            return (result.Succeeded, result.Errors.Select(e => e.Description).ToArray());
        }


        public async Task<AccountRole> GetRoleByIdAsync(string roleId)
        {
            return await _roleManager.FindByIdAsync(roleId);
        }


        public async Task<AccountRole> GetRoleByNameAsync(string roleName)
        {
            return await _roleManager.FindByNameAsync(roleName);
        }








        public async Task<(bool Succeeded, string[] Errors)> DeleteRoleAsync(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);

            if (role != null)
                return await DeleteRoleAsync(role);

            return (true, new string[] { });
        }


        public async Task<(bool Succeeded, string[] Errors)> DeleteRoleAsync(AccountRole role)
        {
            var result = await _roleManager.DeleteAsync(role);
            return (result.Succeeded, result.Errors.Select(e => e.Description).ToArray());
        }



        public void Dispose()
        {
        }
    }
}
