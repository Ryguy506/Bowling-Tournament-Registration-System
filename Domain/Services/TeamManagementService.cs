using Bowling_Tournament_Registration_System.Domain.Daos;
using Bowling_Tournament_Registration_System.Domain.Entities;
using Bowling_Tournament_Registration_System.Domain.Dtos;

namespace Bowling_Tournament_Registration_System.Domain.Services
{
	public class TeamManagementService : ITeamManagementService
	{
		private readonly ITeamDao _teamDao;
		private readonly IPlayerDao _playerDao;
		public TeamManagementService(ITeamDao teamDao, IPlayerDao playerDao)
		{
			_teamDao = teamDao;
			_playerDao = playerDao;
		}

		public int CreateTeam(TeamRequest team)
		{
			var newTeam = new Team
			{
				TeamName = team.TeamName,
				DivisionId = team.DivisionId
			};
			_teamDao.Add(newTeam);
			return newTeam.TeamId;
		}



		public bool UpdateTeam(int teamId, TeamRequest team)
		{
			var existingTeam = _teamDao.GetById(teamId);
			if (existingTeam == null)
			{
				return false;
			}
			existingTeam.TeamName = team.TeamName;
			existingTeam.DivisionId = team.DivisionId;
			_teamDao.Update(existingTeam);
			return true;
		}

		public bool MarkAsPaid(int teamId)
		{
			var existingTeam = _teamDao.GetById(teamId);
			if (existingTeam == null)
			{
				return false;
			}
			existingTeam.RegistrationPaid = true;
			existingTeam.PaymentDate = DateTime.UtcNow;
			_teamDao.Update(existingTeam);
			return true;
		}


		public bool AssignPlayerToTeam(int playerId, int teamId)
		{
			var player = _playerDao.GetById(playerId);
			var team = _teamDao.GetById(teamId);
			if (player == null || team == null || player.TeamId != null)
			{
				return false;
			}
			player.TeamId = teamId;
			_playerDao.Update(player);
			return true;
		}

		public bool RemovePlayerFromTeam(int playerId)
		{
			var player = _playerDao.GetById(playerId);
			if (player == null || player.TeamId == null)
			{
				return false;
			}
			player.TeamId = null;
			_playerDao.Update(player);
			return true;
		}
	}
}
