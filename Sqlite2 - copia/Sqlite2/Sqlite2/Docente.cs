using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;
using SQLite.Net.Attributes;

namespace Sqlite2
{
   public class Docente
    {
        [PrimaryKey, AutoIncrement]
        public int IDDocente { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaContrato { get; set; }
        public decimal Salario { get; set; }
        public bool Doctorado { get; set; }

        public string NombreCompleto
        {
            get
            {
                return string.Format("{0}{1}", this.Nombres, this.Apellidos);
            }
        }

        public string FechaContratoEdited
        {
            get
            {
                return string.Format("{0:yy-MM-dd}", FechaContrato);
            }
        }

        public string SalariosEdited
        {
            get
            {
                return string.Format("{0:C2}", Salario);
            }
        }

        public override string ToString()
        {
            return string.Format("{0}{1}{2}{3}{4}", IDDocente, NombreCompleto, FechaContratoEdited, SalariosEdited, Doctorado);
        }


    }
}
