using Bowling_Tournament_Registration_System.Ui.ReadModels;
namespace Bowling_Tournament_Registration_System.Ui.Queries
{
	public interface ITeamReadModelGateway
	{
		List<TeamOption> GetAll();

		TeamOption GetById(int id); 

        
	}
}
