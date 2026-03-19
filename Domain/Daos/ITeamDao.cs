using Bowling_Tournament_Registration_System.Domain.Entities;
namespace Bowling_Tournament_Registration_System.Domain.Daos
{
	public interface ITeamDao
	{
		Team? GetById (int teamId);

		void Add (Team team);
		void Update (Team team);



	}
}
