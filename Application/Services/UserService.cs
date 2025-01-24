using Application.DTOs;
using CatalogManagement.Models.Entities;
using CatalogManagement.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService
    {
        public readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
            var users = new List<UserDTO>();
            foreach (var user in await _userRepository.GetAllAsync())
            {
                users.Add(new UserDTO(user));
            }
            return users;
        }

        public async Task<UserDTO> GetUserById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return new UserDTO(user);
        }

        public async Task AddUser(User user)
        {
            if (await _userRepository.UserExistsByEmail(user.Email))
            {
                throw new InvalidOperationException("This EMAIL is ALREADY in USE.");
            }
            if (await _userRepository.UserExistsByUsername(user.Username))
            {
                throw new InvalidOperationException("This USERNAME is ALREADY TAKEN.");
            }
            await _userRepository.AddAsync(user);
            await _userRepository.SaveAsync();
        }

        public async Task DeleteUser(int id)
        {
            await _userRepository.DeleteAsync(id);
            await _userRepository.SaveAsync();
        }

        public async Task UpdateUser(int id, User user)
        {
            var userToUpdate = await _userRepository.GetByIdAsync(id);

            if(userToUpdate == null)
            {
                throw new InvalidOperationException("USER NOT FOUND.");
            }

            if (userToUpdate.Username != user.Username)
            {
                var existingUser = await _userRepository.GetUserByUsername(user.Username);
                if(existingUser != null)
                {
                    throw new InvalidOperationException("This USERNAME is ALREADY TAKEN.");
                }
            }

            if(userToUpdate.Email != user.Email)
            {
                var existingUser = await _userRepository.GetUserByEmail(user.Email);
                if (existingUser != null)
                {
                    throw new InvalidOperationException("This EMAIL is ALREADY in USE.");
                }

            }

            userToUpdate.Username = user.Username;
            userToUpdate.Email = user.Email;
            userToUpdate.Password = user.Password;

            await _userRepository.UpdateAsync(userToUpdate);
            await _userRepository.SaveAsync();
        }
    }
}
