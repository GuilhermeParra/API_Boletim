using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Boletim.Domains
{
    public class Trabalho
    {
        public int IdTrabalho { get; set; }
        public float Nota { get; set; }
        public int IdMateria { get; set; }
        public int IdAluno { get; set; }
        public DateTime DataEntrega { get; set; }
    }
}
