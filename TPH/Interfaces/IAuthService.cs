using TPH.DTOs;
using TPH.Models.Auth;

namespace TPH.Interfaces
{
	public interface IAuthService
	{
		public Task<AuthModel> RegisterStudent(StudentRegisterDto dto);
	}
}
