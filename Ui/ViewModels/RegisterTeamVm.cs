using Bowling_Tournament_Registration_System.Ui.ReadModels;
using System.ComponentModel.DataAnnotations;

namespace Bowling_Tournament_Registration_System.Ui.ViewModels
{
    public class RegisterTeamVm
    {
        public int TournamentId { get; set; }

        public List<TeamOption> Teams { get; set; } = new();

        public int SelectedTeamId { get; set; }
    }
}
