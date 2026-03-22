namespace Bowling_Tournament_Registration_System.Domain.Services
{
	public interface IAuthService
	{
		bool Authenticate(string username, string password);
	}
}
