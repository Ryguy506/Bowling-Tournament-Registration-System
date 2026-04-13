using Bowling_Tournament_Registration_System.Domain.Entities;
using Bowling_Tournament_Registration_System.Persistence.Ef;
using Bowling_Tournament_Registration_System.Ui.Queries;
using Bowling_Tournament_Registration_System.Ui.ReadModels;
namespace Bowling_Tournament_Registration_System.Persistence.Queries
{
	public class DivisionReadModelGateway : IDivisionReadModelGateway
	{
		private readonly BowlingDbContext _context;

		public DivisionReadModelGateway(BowlingDbContext context)
		{
			_context = context;
		}

		public List<DivisionOption> GetDivisionOptions()
		{
			return  _context.Divisions
				.Select(d => new DivisionOption
				{
					Id = d.DivisionId,
					Name = d.DivisionName
				})
				.ToList();
		}

		public List<DivisionCapacityReadModel> GetDivisionCapacities(int tournamentId)
		{
			return _context.TournamentDivisionCapacities
			.Where(tdc => tdc.TournamentId == tournamentId)
			.Join(_context.Divisions,
			tdc => tdc.DivisionId,
			d => d.DivisionId,
			(tdc, d) => new DivisionCapacityReadModel
			{
		
			DivisionName = d.DivisionName,
			Capacity = tdc.Capacity
			})
			.ToList();
		}
	}
}
