using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPT.DTOs;
using TPT.Interfaces;
using TPT.Models.Auth;
using TPT.Models.Factories;

namespace TPT.Controllers
{
	[Route("api/TPT/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IAuthService _authService;
		private IResponseFactory _successFactory;
		private IResponseFactory _failureFactory;
		private IResponseFactory _unAuthorizedFactory;

		public AuthController(IAuthService authService)
		{
			_authService = authService;
			_unAuthorizedFactory = new UnAuthorizedFailureResponseFactory();
		}

		[HttpPost("student-register")]
		public async Task<IActionResult> RegisterStudentAsync(StudentRegisterDto dto)
		{
			var result = await _authService.RegisterStudent(dto);

			if (!result.IsAuthed)
			{
				_failureFactory = new FailureResponseFactory(400, result.Message);
				return BadRequest(_failureFactory.CreateResponse());
			}

			_successFactory = new SuccessResponseFactory<AuthModel>(200, result);
			return Ok(_successFactory.CreateResponse());
		}

		[HttpPost("login")]
		public async Task<IActionResult> StudentLoginAsync(LoginDto dto)
		{
			var result = await _authService.LoginAsync(dto);

			if (!result.IsAuthed)
			{
				var unAuthorizedFactory = new UnAuthorizedFailureResponseFactory();
				var response = unAuthorizedFactory.CreateResponse();
				response.Message = result.Message;
				return Unauthorized(response);
			}


			_successFactory = new SuccessResponseFactory<AuthModel>(200, result);
			return Ok(_successFactory.CreateResponse());
		}


		[HttpPost("teacher-register")]
		public async Task<IActionResult> TeacherRegisterAsync(TeacherRegisterDto dto)
		{
			var result = await _authService.RegisterTeacherAsync(dto);

			if (!result.IsAuthed)
			{
				_failureFactory = new FailureResponseFactory(400, result.Message);
				return BadRequest(_failureFactory.CreateResponse());
			}

			_successFactory = new SuccessResponseFactory<AuthModel>(200, result);
			return Ok(_successFactory.CreateResponse());
		}

	}
}
