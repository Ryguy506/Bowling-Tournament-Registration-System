using Bowling_Tournament_Registration_System.Ui.Queries;
using Bowling_Tournament_Registration_System.Persistence.Ef;
using Bowling_Tournament_Registration_System.Ui.ReadModels;
namespace Bowling_Tournament_Registration_System.Persistence.Queries
{
	public class TeamReadModelGateway : ITeamReadModelGateway
	{
		private readonly BowlingDbContext _context;

		public TeamReadModelGateway(BowlingDbContext context)
		{
			_context = context;
		}

		public List<TeamOption> GetAll() { 
			return _context.Teams.Select(t => new TeamOption
			{
				Id = t.TeamId,
				TeamName = t.TeamName,
				DivisionId = t.DivisionId,
				RegistrationPaid = t.RegistrationPaid,
				PaymentDate = t.PaymentDate ?? null



			}).ToList();
		
		}


		public TeamOption GetById(int id) { 
		
			return _context.Teams.Where(t => t.TeamId == id).Select(t => new TeamOption
			{
				Id = t.TeamId,
				TeamName = t.TeamName,
				DivisionId = t.DivisionId,
				RegistrationPaid = t.RegistrationPaid,
				PaymentDate = t.PaymentDate.Value

			}).FirstOrDefault();
		
		}


        public List<TeamRegistrationOption> GetTeamsForTournament(int tournamentId)
        {
            var tournament = _context.Tournaments
                .Where(t => t.TournamentId == tournamentId)
                .Select(t => new
                {
                    t.TournamentId,
                    t.Capacity,
                    Count = _context.TournamentRegistrations.Count(r => r.TournamentId == t.TournamentId)
                })
                .FirstOrDefault();

            if (tournament == null)
                return new List<TeamRegistrationOption>();

            return _context.Teams
                .Select(t => new
                {
                    t.TeamId,
                    t.TeamName,
                    t.RegistrationPaid,

                    AlreadyRegistered = _context.TournamentRegistrations
                        .Any(r => r.TeamId == t.TeamId && r.TournamentId == tournamentId)
                })

                .Select(t => new TeamRegistrationOption
                {
                    TeamId = t.TeamId,
                    TeamName = t.TeamName,

                    IsEligible =
                        t.RegistrationPaid &&
                        !t.AlreadyRegistered &&
                        tournament.Count < tournament.Capacity,

                    ReasonNotEligible =
                        !t.RegistrationPaid ? "Team has not paid fee" :
                        t.AlreadyRegistered ? "Already registered" :
                        (tournament.Count >= tournament.Capacity ? "Tournament full" : null)
                })
                .ToList();
        }

    }
}
