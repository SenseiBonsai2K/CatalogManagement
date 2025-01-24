using Application.DTOs;
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
    }
}
