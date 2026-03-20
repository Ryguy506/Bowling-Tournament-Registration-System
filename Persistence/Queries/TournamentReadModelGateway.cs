using Bowling_Tournament_Registration_System.Ui.Queries;
using Bowling_Tournament_Registration_System.Persistence.Ef;
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
				_context.TournamentRegistrations,
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
			return  new TournamentDetailsOption { Id = id }; // add


		}


	}
}
