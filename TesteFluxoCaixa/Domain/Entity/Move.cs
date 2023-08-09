using TesteFluxoCaixa.Shared;

namespace TesteFluxoCaixa.Domain.Entity
{
    public class Move
    {

        public Move() { 
            
        }

        public int Id { get; set; }

        public decimal Value { get; set; }

        public MoveType Type { get; set; }

        public DateTime Date { get; internal set; }

        public string TypeDescription { get { return this.Type.GetDisplayName() ?? string.Empty; } }
    }
}
