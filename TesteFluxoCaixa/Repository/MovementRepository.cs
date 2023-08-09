using TesteFluxoCaixa.Domain.Entity;

namespace TesteFluxoCaixa.Repository
{
    public class MovementRepository : IRepository<Move>
    {
        //Possible to initialize with values for testing. 
        private static Dictionary<int, Move> movements = new Dictionary<int, Move>()
        {
            //[1] = new Move { Id = 1, Date = DateTime.Now, Type = Shared.MoveType.Credit, Value = 10 },
            //[2] = new Move { Id = 2, Date = DateTime.Now, Type = Shared.MoveType.Credit, Value = 20 },
            //[3] = new Move { Id = 3, Date = DateTime.Now, Type = Shared.MoveType.Credit, Value = (decimal)50.3 },
            //[4] = new Move { Id = 4, Date = DateTime.Now, Type = Shared.MoveType.Credit, Value = (decimal)20.5 },
            //[5] = new Move { Id = 5, Date = DateTime.Now, Type = Shared.MoveType.Debit, Value = 30 },
            //[6] = new Move { Id = 6, Date = DateTime.Now, Type = Shared.MoveType.Debit, Value = (decimal)40.1 },
        };

        public async Task<int> Add(Move item)
        {
            return await Task.Run(() =>
            {
                int id = movements.Any() ? (movements.Max(_movement => _movement.Key) + 1) : 1;
                item.Id = id;
                item.Date = DateTime.Now;
                movements.Add(id, item);
                return id;
            });
        }

        public async Task<List<Move>> GetAll()
        {
            return await Task.Run(() => { return movements.Values.ToList(); });
        }

        public async Task<List<Move>> GetSummary(DateTime Date)
        {
            return await Task.Run(() => {
                DateTime minDate = new DateTime(Date.Year, Date.Month, Date.Day, 0, 0, 0);
                DateTime maxDate = minDate.AddDays(1);
                return movements.Values.Where(_movement => _movement.Date >= minDate && _movement.Date < maxDate).ToList(); 
            });
        }
    }
}
