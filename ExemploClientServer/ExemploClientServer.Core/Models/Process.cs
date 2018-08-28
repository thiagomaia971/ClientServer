namespace ExemploClientServer.Core.Models
{
    public class Process : Entity
    {
        public int ComputerId { get; set; }
        public int ProcessId { get; set; }
        public string Nome { get; set; }

        public virtual Computer Computer { get; set; }
    }
}