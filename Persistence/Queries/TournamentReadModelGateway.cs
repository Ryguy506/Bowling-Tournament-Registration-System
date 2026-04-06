using Bowling_Tournament_Registration_System.Domain.Entities;
using Bowling_Tournament_Registration_System.Persistence.Ef;
using Bowling_Tournament_Registration_System.Ui.Queries;
using Bowling_Tournament_Registration_System.Ui.ReadModels;
namespace Bowling_Tournament_Registration_System.Persistence.Queries
{
	public class TournamentReadModelGateway : ITournamentReadModelGateway
	{
		private readonly BowlingDbContext _context;

		public TournamentReadModelGateway(BowlingDbContext context)
		{
			_context = context;
		}


		public List<TournamentOption> GetAll()
		{
			return _context.Tournaments
			.GroupJoin(
				_context.TournamentRegistrations.Where(r => r.Status == RegistrationStatus.Confirmed),
					t => t.TournamentId,
					tr => tr.TournamentId,
					(t, regs) => new TournamentOption
					{
						Id = t.TournamentId,
						Name = t.Name,
						Date = t.TournamentDate,
						Location = t.Location,
						RegisteredCount = regs.Count(),
						Capacity = t.Capacity,
					}).ToList();

		}

		public TournamentDetailsOption GetById(int id) {

			var tournament = _context.Tournaments.Where(t => t.TournamentId == id)
				.Select(t => new TournamentDetailsOption
				{
					Id = t.TournamentId,
					Name = t.Name,
					Date = t.TournamentDate,
					Location = t.Location,
					Capacity = t.Capacity,
					RegistrationOpen = t.RegistrationOpen,
					
					

				}).FirstOrDefault();

			if (tournament == null)
				return null;

			tournament.RegisteredTeams = _context.TournamentRegistrations
				.Where(tr => tr.TournamentId == t.TournamentId && tr.Status == RegistrationStatus.Confirmed)
				.Join(_context.Teams,
					tr => tr.TeamId,
					team => team.TeamId,
					(tr, team) => new TeamOption
					{
						Id = team.TeamId,
						TeamName = team.TeamName
					})
				.ToList();


            tournament.WaitlistedTeams = _context.TournamentRegistrations.Where(tr => tr.TournamentId == id && tr.Status == RegistrationStatus.Waitlisted)
				 .OrderBy(tr => tr.WaitlistPosition)
				.Join(_context.Teams, tr => tr.TeamId, t => t.TeamId, (tr, t) => new WaitlistEntry
				{
					Position = tr.WaitlistPosition ?? 0,
					TeamName = t.TeamName
				})
				.ToList();

			tournament.RegisteredCount = tournament.RegisteredTeams.Count;
			

			return tournament;





        }


	}
}
