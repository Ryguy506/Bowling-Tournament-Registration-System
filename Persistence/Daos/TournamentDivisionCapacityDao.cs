
using Bowling_Tournament_Registration_System.Domain.Daos;
using Bowling_Tournament_Registration_System.Domain.Entities;
using Bowling_Tournament_Registration_System.Persistence.Ef;
using Microsoft.EntityFrameworkCore;

namespace Bowling_Tournament_Registration_System.Persistence.Daos
{
	public class TournamentDivisionCapacityDao : ITournamentDivisionCapacityDao
	{
		private readonly BowlingDbContext _db;
		public TournamentDivisionCapacityDao(BowlingDbContext db)
		{
			_db = db;
		}
	

		public int GetDivisionCapacity(int tournamentId, int divisionId)
		{
			var capacity = _db.TournamentDivisionCapacities
				.FirstOrDefault(dc => dc.TournamentId == tournamentId && dc.DivisionId == divisionId);
			return capacity?.Capacity ?? 0;
		}

        public TournamentDivisionCapacity GetByTournamentAndDivision(int tournamentId, int divisionId)
        {
            return _db.TournamentDivisionCapacities
                .FirstOrDefault(dc => dc.TournamentId == tournamentId && dc.DivisionId == divisionId);
        }

        public void Update(TournamentDivisionCapacity capacity)
        {
            _db.TournamentDivisionCapacities.Update(capacity);
            _db.SaveChanges();
        }


        public void Add(TournamentDivisionCapacity capacity)
		{
			_db.TournamentDivisionCapacities.Add(capacity);
			_db.SaveChanges();
		}
	}
}
