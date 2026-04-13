using Bowling_Tournament_Registration_System.Ui.ReadModels;
namespace Bowling_Tournament_Registration_System.Ui.Queries
{
	public interface IDivisionReadModelGateway
	{
		List<DivisionOption> GetDivisionOptions();

		List<DivisionCapacityReadModel> GetDivisionCapacities(int tournamentId);
	}
}
