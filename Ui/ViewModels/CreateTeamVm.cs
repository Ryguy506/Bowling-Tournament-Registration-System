using System.ComponentModel.DataAnnotations;
using Bowling_Tournament_Registration_System.Ui.ReadModels;

namespace Bowling_Tournament_Registration_System.Ui.ViewModels
{
    public class CreateTeamVm
    {
        [Required]
        public string TeamName { get; set; }

        [Required]
        public int DivisionId { get; set; }

        
        public List<TeamOption> Divisions { get; set; } = new();
    }
}
