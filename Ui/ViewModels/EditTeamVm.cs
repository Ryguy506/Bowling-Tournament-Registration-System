using Bowling_Tournament_Registration_System.Ui.ReadModels;
namespace Bowling_Tournament_Registration_System.Ui.ViewModels
{
	public class EditTeamVm
	{
		public TeamOption Team { get; set; }

		public List<PlayerOption> PlayersOnTeam { get; set; }

		public List<PlayerOption> AvailablePlayers { get; set; }
	}
}
