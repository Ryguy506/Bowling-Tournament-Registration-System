using Bowling_Tournament_Registration_System.Domain.Daos;
namespace Bowling_Tournament_Registration_System.Domain.Services
{
	public class AuthService : IAuthService
	{
		private readonly IUserDao _userDao;

		public AuthService(IUserDao userDao)
		{
			_userDao = userDao;
		}

		public bool Authenticate(string username, string password)
		{
			return _userDao.Authenticate(username, password); 
		}
	}
}
