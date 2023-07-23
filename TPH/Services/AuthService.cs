using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TPH.Data;
using TPH.DTOs;
using TPH.Interfaces;
using TPH.Models;
using TPH.Models.Auth;

namespace TPH.Services
{
	public class AuthService : IAuthService
	{
		private readonly UserManager<User> _userManager;
		private readonly IMapper _mapper;
		private readonly JWT _jwt;
		private readonly RoleManager<IdentityRole> _roleManager;

		public AuthService(
			UserManager<User> userManager,
			IMapper mapper,
			IOptions<JWT> jwt,
			RoleManager<IdentityRole> roleManager)
		{
			_userManager = userManager;
			_mapper = mapper;
			_jwt = jwt.Value;
			_roleManager = roleManager;
		}
		public async Task<AuthModel> RegisterStudent(StudentRegisterDto dto)
		{
			var auth = new AuthModel();

			var existedUser = await _userManager.FindByNameAsync(dto.UserName);
			if(existedUser is not null)
			{
				auth.Message = "There is already User with the same user name";
				return auth;
			}

			var user = _mapper.Map<Student>(dto);
			user.Email = dto.UserName;
			var result = await _userManager.CreateAsync(user ,dto.Password);

			if (!result.Succeeded)
			{
				auth.Message = "Error occured while register !!";
				return auth;
			}

			auth.IsAuthed = true;
			auth.Email = user.Email;
			auth.UserName = user.UserName;

			return auth;
		}
	}
}
