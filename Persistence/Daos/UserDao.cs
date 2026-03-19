using Bowling_Tournament_Registration_System.Domain.Entities;
using Bowling_Tournament_Registration_System.Domain.Daos;
using Bowling_Tournament_Registration_System.Persistence.Ef;

namespace Bowling_Tournament_Registration_System.Persistence.Daos
{
	public class UserDao : IUserDao
	{
		public readonly BowlingDbContext _db;
		public UserDao(BowlingDbContext db)
		{
			_db = db;
		}
		public User? GetUser(string username)
		{
			return _db.Users.Find(username);
		}
		
	}
}
