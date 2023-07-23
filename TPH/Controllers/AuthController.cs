using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPH.DTOs;
using TPH.Interfaces;
using TPH.Models.Auth;
using TPH.Models.Factories;

namespace TPH.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IAuthService _authService;
		private IResponseFactory _successFactory;
		private IResponseFactory _failureFactory;

		public AuthController(IAuthService authService)
		{
			_authService = authService;
		}

		[HttpPost("student-register")]
		public async Task<IActionResult> StudentRegisterAsync(StudentRegisterDto dto)
		{
			var result = await _authService.RegisterStudent(dto);

			if(!result.IsAuthed)
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
