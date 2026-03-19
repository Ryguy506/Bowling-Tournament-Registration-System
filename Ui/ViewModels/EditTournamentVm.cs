using System.ComponentModel.DataAnnotations;

namespace Bowling_Tournament_Registration_System.Ui.ViewModels
{
    public class EditTournamentVm
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Location { get; set; }

        [Range(1, 1000)]
        public int Capacity { get; set; }
    }
}
