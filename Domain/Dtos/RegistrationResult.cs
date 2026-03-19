namespace Bowling_Tournament_Registration_System.Domain.Dtos
{
	public class RegistrationResult
	{
		public bool Success { get; set; }
		public string? ErrorMessage { get; set; }

		public static RegistrationResult Ok()
		{
			return new RegistrationResult { Success = true };
		}

		public static RegistrationResult Fail(string message)
		{
			return new RegistrationResult { Success = false, ErrorMessage = message };
		}
	}
}
