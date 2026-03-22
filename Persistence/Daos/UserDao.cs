using Bowling_Tournament_Registration_System.Persistence.Ef;
namespace Bowling_Tournament_Registration_System.Domain.Daos
{
	public class UserDao : IUserDao
	{

		private readonly BowlingDbContext _db;

		public UserDao(BowlingDbContext db)
		{
			_db = db;
		}

		public bool Authenticate(string username , string password)
		{
			return _db.Users.Any(u => u.Username == username && u.Password == password);
		}
	}
}
