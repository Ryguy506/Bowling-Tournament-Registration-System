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


        

    }
}
