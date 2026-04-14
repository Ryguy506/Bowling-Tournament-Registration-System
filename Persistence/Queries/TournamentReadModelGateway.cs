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

		public TournamentDetailsOption GetById(int id)
		{

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
			.Where(tr => tr.TournamentId == tournament.Id && tr.Status == RegistrationStatus.Confirmed)
.			Join(_context.Teams,
			tr => tr.TeamId,
			team => team.TeamId,
			(tr, team) => new { tr, team })
			.Join(_context.Divisions,
				x => x.team.DivisionId,
				d => d.DivisionId,
				(x, d) => new TeamOption
				{
					Id = x.team.TeamId,
					TeamName = x.team.TeamName,
					DivisionId = x.team.DivisionId,
					DivisionName = d.DivisionName
				})
			.ToList();

			tournament.WaitlistedTeams = _context.TournamentRegistrations
				.Where(tr => tr.TournamentId == id && tr.Status == RegistrationStatus.Waitlisted)
				.OrderBy(tr => tr.WaitlistPosition)
				.Join(_context.Teams,
					tr => tr.TeamId,
					t => t.TeamId,
					(tr, t) => new { tr, t })
				.Join(_context.Divisions,
					x => x.t.DivisionId,
					d => d.DivisionId,
					(x, d) => new WaitlistEntry
					{
						Position = x.tr.WaitlistPosition ?? 0,
						TeamName = x.t.TeamName,
						DivisionName = d.DivisionName
					})
				.ToList();

			tournament.RegisteredCount = tournament.RegisteredTeams.Count;


			return tournament;





		}


	}
}
