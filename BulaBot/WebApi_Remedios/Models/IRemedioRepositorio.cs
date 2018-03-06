using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi_Remedios.Models
{
    interface IRemedioRepositorio
    {
        IEnumerable<Remedio> GetAll();
        Remedio Get(int id);
        Remedio Add(Remedio item);
        void Remove(int id);
        bool Update(Remedio item);
    }
}
