using Bowling_Tournament_Registration_System.Ui.ReadModels;
using System.ComponentModel.DataAnnotations;

namespace Bowling_Tournament_Registration_System.Ui.ViewModels
{
    public class RegisterTeamVm
    {
        public int TournamentId { get; set; }

        public List<TeamRegistrationOption> Teams { get; set; } = new();

        [Required(ErrorMessage = "Please select a team.")]
        public int SelectedTeamId { get; set; }
    }
}
