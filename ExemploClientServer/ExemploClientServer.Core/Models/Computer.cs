using System.Collections.Generic;

namespace ExemploClientServer.Core.Models
{
    public class Computer : Entity
    {
        public string Nome { get; set; }
        public string Ip { get; set; }

        public virtual ICollection<Process> Process { get; set; }
    }
}
