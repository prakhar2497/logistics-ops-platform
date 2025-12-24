using Logistics.Application.DTOs;
using Logistics.Application.Interface;
using Logistics.Infrastructure.Interface;
using Logistics.Infrastructure.Security;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Infrastructure.Service
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly PasswordHasher _passwordHasher;

        public AuthService(IUserRepository userRepository, IJwtTokenService jwtTokenService, PasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _jwtTokenService = jwtTokenService;
            _passwordHasher = passwordHasher;
        }
        public async Task<AuthResponse> LoginAsync(LoginRequest request)
        {
            
            var user = await _userRepository.GetUserByEmailAsync(request.Email);
            
            if (user == null)
                throw new UnauthorizedAccessException("Invalid credentials");

            var isPasswordValid = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password) == PasswordVerificationResult.Success;
            
            if(!isPasswordValid)
                throw new UnauthorizedAccessException("Invalid credentials");

            var token = _jwtTokenService.GenerateToken(user);

            var response = new AuthResponse
            {
                Token = token,
                FullName = user.FullName,
                Email = user.Email,
                Role = user.RoleId.ToString()
            };

            return response;
        }

        public async Task<AuthResponse> RefreshTokenAsync(LoginRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
