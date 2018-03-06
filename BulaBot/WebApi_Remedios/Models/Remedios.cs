using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_Remedios.Models
{
    public class Remedio
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Posologia { get; set; }
        public string Indicacao { get; set; }
        public string Efeitos { get; set; }
        public string Preco { get; set; }
    }
}