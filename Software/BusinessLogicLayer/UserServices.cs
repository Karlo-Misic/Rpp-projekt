using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace BusinessLogicLayer
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public bool RegisterUser(string username, string email, string password)
        {
            string hashedPassword = HashPassword(password);

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            if (_userRepository.UserExists(email))
            {
                return false; 
            }

            if(_userRepository.UsernameExists(username))
            {
                return false;
            }

            var newUser = new USER
            {
                username = username,
                email = email,
                password = hashedPassword,
                totalPoints = 0,
                userTypeID = 1
            };

            _userRepository.Add(newUser);
            return true;
        }

        public static string HashPassword(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            return Convert.ToBase64String(hashBytes);
        }

        public bool LoginUser(string username, string password)
        {
            var user = _userRepository.GetUserByUsername(username);
            if (user == null)
            {
                return false;
            }

            return VerifyPassword(password, user.password);
        }

        private bool VerifyPassword(string enteredPassword, string storedHash)
        {
            try
            {
                byte[] hashBytes = Convert.FromBase64String(storedHash);
                byte[] salt = new byte[16];
                Array.Copy(hashBytes, 0, salt, 0, 16);

                var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, salt, 10000);
                byte[] hash = pbkdf2.GetBytes(20);

                for (int i = 0; i < 20; i++)
                {
                    if (hashBytes[i + 16] != hash[i]) return false;
                }

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        public void SaveUserScore(string username, int score)
        {
            _userRepository.UpdateUserScore(username, score);
        }

        public List<USER> GetTopPlayers(int topN)
        {
            return _userRepository.GetTopPlayers(topN);
        }

    }

}
