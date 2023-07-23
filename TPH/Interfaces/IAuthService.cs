using TPH.DTOs;
using TPH.Models.Auth;

namespace TPH.Interfaces
{
	public interface IAuthService
	{
		public Task<AuthModel> RegisterStudent(StudentRegisterDto dto);

		public Task<AuthModel> LoginAsync(LoginDto dto); 
		
		public Task<AuthModel> RegisterTeacherAsync(TeacherRegisterDto dto);

		
	}
}
