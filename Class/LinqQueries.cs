using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq_csharp_console_proyecto.Class
{
    public class LinqQueries
    {
        private List<Book> librosCollection = new List<Book>(); //Lista Vacia

        public LinqQueries() {

            //Cargar el JSON
            using (StreamReader reader = new StreamReader("Json/books.json"))
            {
                string json = reader.ReadToEnd();
                //El uso de "PropertyNameCaseInsensitive" es para evitar el conflicto de las Mayusculas.
                this.librosCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }

        public IEnumerable<Book> TodaLaColecion()
        {
            return librosCollection;
        }
    }
}
