using Bowling_Tournament_Registration_System.Domain.Entities;
using Bowling_Tournament_Registration_System.Domain.Dtos;
namespace Bowling_Tournament_Registration_System.Domain.Daos
{
	public interface ITeamDao
	{
		Team? GetById (int teamId);

		void Add (Team team);
		void Update (Team team);



	}
}
