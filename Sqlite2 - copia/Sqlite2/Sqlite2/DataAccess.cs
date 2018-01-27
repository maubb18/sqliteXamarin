using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Sqlite2
{
    public class DataAccess : IDisposable
    {
        private SQLiteConnection connection;

        public DataAccess()
        {
            var config = DependencyService.Get<IConfig>();
            connection = new SQLiteConnection(config.Plataforma, System.IO.Path.Combine(config.DirectorioDB, "Docentes.db3"));
            connection.CreateTable<Docente>();
        }
        public void InsertDocente(Docente docente)
        {
            connection.Insert(docente);
        }

        public void UpdateDocente(Docente docente)
        {
            connection.Update(docente);
        }
        public void DeleteDocente(Docente docente)
        {
            connection.Delete(docente);
        }
        public Docente GetDocente(int IDDocente)
        {
            return connection.Table<Docente>().FirstOrDefault(c => c.IDDocente == IDDocente);
        }

        public List<Docente> GetDocente()
        {
            return connection.Table<Docente>().OrderBy(c => c.Apellidos).ToList();
        }
        public void Dispose()
        {
            connection.Dispose();
        }
    }
}
