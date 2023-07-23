using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
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

		public async Task<AuthModel> LoginAsync(LoginDto dto)
		{
			var auth = new AuthModel();

			var user = await _userManager.FindByNameAsync(dto.UserName);

			if (user is null)
			{
				auth.Message = "There is no user matching this User Name";
				return auth;
			}

			if(!await _userManager.CheckPasswordAsync(user, dto.Password))
			{
				auth.Message = "Provided Password is not correct !!";
				return auth;
			}

			var jwt = await CreateJwtToken(user);


			var refreshToken = user.RefreshTokens.FirstOrDefault(t => t.IsActive);

			if (refreshToken is null)
			{
				// generate new one ...
				refreshToken = GenerateRefreshToken();

				// add it to the user refresh tokens table
				user.RefreshTokens.Add(refreshToken);
				await _userManager.UpdateAsync(user);
			}


			auth.UserName = user.UserName;
			auth.Email = user.UserName;
			auth.IsAuthed = true;
			auth.AccessTokenExpiration = jwt.ValidTo;
			auth.RefreshTokenExpiration = refreshToken.ExpiresOn;
			auth.Token = new JwtSecurityTokenHandler().WriteToken(jwt);
			auth.RefreshToken = refreshToken.Token;

			return auth;
		}

		private async Task<JwtSecurityToken> CreateJwtToken(User user)
		{
			var userClaims = await _userManager.GetClaimsAsync(user);
			var roles = await _userManager.GetRolesAsync(user);
			var roleClaims = new List<Claim>();

			foreach (var role in roles)
				roleClaims.Add(new Claim("roles", role));

			var claims = new[]
			{
				new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				new Claim(JwtRegisteredClaimNames.Email, user.Email),
				new Claim("uid", user.Id)
			}
			.Union(userClaims)
			.Union(roleClaims);

			var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
			var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

			var jwtSecurityToken = new JwtSecurityToken(
				issuer: _jwt.Issuer,
				audience: _jwt.Audience,
				claims: claims,
				expires: DateTime.Now.AddMinutes(_jwt.DurationInMinutes),
				signingCredentials: signingCredentials);

			return jwtSecurityToken;
		}

		private static RefreshToken GenerateRefreshToken()
		{
			var randomNumber = new byte[32];

			using var generator = new RNGCryptoServiceProvider();

			generator.GetBytes(randomNumber);

			return new RefreshToken
			{
				Token = Convert.ToBase64String(randomNumber),
				ExpiresOn = DateTime.UtcNow.AddDays(10),
				CreatedOn = DateTime.UtcNow
			};
		}
		public async Task<AuthModel> RegisterStudent(StudentRegisterDto dto)
		{
			var auth = new AuthModel();

			var existedUser = await _userManager.FindByNameAsync(dto.UserName);
			if (existedUser is not null)
			{
				auth.Message = "There is already User with the same user name";
				return auth;
			}

			var user = _mapper.Map<Student>(dto);
			user.Email = dto.UserName;
			var result = await _userManager.CreateAsync(user, dto.Password);

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

		public async Task<AuthModel> RegisterTeacherAsync(TeacherRegisterDto dto)
		{
			var auth = new AuthModel();

			var existedUser = await _userManager.FindByNameAsync(dto.UserName);
			if (existedUser is not null)
			{
				auth.Message = "There is already Teacher with the same user name";
				return auth;
			}

			var user = _mapper.Map<Teacher>(dto);
			user.Email = dto.UserName;
			var result = await _userManager.CreateAsync(user, dto.Password);

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
