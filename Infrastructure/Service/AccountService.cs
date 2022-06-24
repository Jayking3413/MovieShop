using ApplicationCore.Contract.Repository;
using ApplicationCore.Contract.Service;
using ApplicationCore.Exceptions;
using ApplicationCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using ApplicationCore.Entity;

namespace Infrastructure.Service
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;

        public AccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> RegisterUser(UserRegisterModel model)
        {
            //check the user existing in data by email - UserRepository
            var user = await _userRepository.GetUserByEmail(model.Email);
            if (user != null)
            {
                throw new ConflictException("Email already exist, please try to login");
            }
            var salt = GetRandomSalt();
            var hashedPassword = GetHashedPassword(model.Password, salt);
            var newUser = new User
            {
                Email = model.Email,
                HashedPassword = hashedPassword,
                Salt = salt,
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth
            };
            await _userRepository.Add(newUser);

            var savedUser = await _userRepository.Add(newUser);
            if (savedUser.Id > 0)
            {
                return true;
            }
            return false;
        }

        public Task<bool> ValidateUser(string eamil, string password)
        {
            throw new NotImplementedException();
        }
        
        private string GetRandomSalt()
        {
            var randomBytes = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }
            return Convert.ToBase64String(randomBytes);
        }
        private string GetHashedPassword(string password, string salt)
        {
            var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password, Convert.FromBase64String(salt),
                KeyDerivationPrf.HMACSHA512, 10000, 256 / 8));
            return hashed;
        }
    }
}
