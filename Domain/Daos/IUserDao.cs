using Bowling_Tournament_Registration_System.Domain.Entities;
namespace Bowling_Tournament_Registration_System.Domain.Daos

{
	public interface IUserDao
	{
		bool Authenticate(string username , string password);
	}
}
