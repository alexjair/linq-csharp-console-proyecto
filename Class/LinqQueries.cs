using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq_csharp_console_proyecto.Class
{
    public class LinqQueries
    {

        
        private List<Animal> animalesCollection = new List<Animal>();
        
        private List<Book> librosCollection = new List<Book>(); //Lista Vacia

        public LinqQueries() {

            //Cargar el JSON
            using (StreamReader reader = new StreamReader("Json/books.json"))
            {
                string json = reader.ReadToEnd();
                //El uso de "PropertyNameCaseInsensitive" es para evitar el conflicto de las Mayusculas.
                this.librosCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }

            //Cargar lista Animal
            this.animalesCollection.Add(new Animal() { Nombre = "Hormiga", Color = "Rojo" });
            this.animalesCollection.Add(new Animal() { Nombre = "Lobo", Color = "Gris" });
            this.animalesCollection.Add(new Animal() { Nombre = "Elefante", Color = "Verde" });
            this.animalesCollection.Add(new Animal() { Nombre = "Pantegra", Color = "Verde" });
            this.animalesCollection.Add(new Animal() { Nombre = "Gato", Color = "Negro" });
            this.animalesCollection.Add(new Animal() { Nombre = "Iguana", Color = "Verde" });
            this.animalesCollection.Add(new Animal() { Nombre = "Sapo", Color = "Verde" });
            this.animalesCollection.Add(new Animal() { Nombre = "Camaleon", Color = "Verde" });
            this.animalesCollection.Add(new Animal() { Nombre = "Gallina", Color = "Blanco" });
        }

        public IEnumerable<Animal> fun_animales_ordenados_nombre()
        {
            // Escribe tu código aquí
            // Retorna los elementos de la colleción animal ordenados por nombre

            return animalesCollection.OrderBy(
                p =>
                p.Nombre
            );
        }

        public IEnumerable<Book> TodaLaColecion()
        {
            return librosCollection;
        }

        public IEnumerable<Book> LibrosdeJavaPorNombreAscendente()
        {
            return librosCollection.Where(
                p => 
                p.Categories.Contains("Java")
            ).OrderBy(
                p => 
                p.Title
            );
        }

        public IEnumerable<Book> Librosmasde450pagOrdernadorPorNumPagDescendente()
        {
            return librosCollection.Where(
                p => 
                p.PageCount > 450
            ).OrderByDescending(
                p => p.PageCount
            );
        }

        public IEnumerable<Book> funReto_12_Libros_Python()
        {
            //Extension
            return librosCollection.Where(
                    p => 
                    p.Categories.Contains("Python")
                );
        }
        public bool TodosLosLibrosTienenStatus()
        {
            // Empty: saber si existe valor o si existe.
            return librosCollection.All(p => p.Status != string.Empty);
        }

        public bool SiAlgunLibroFuePublicado2005()
        {
            return librosCollection.Any(p => p.PublishedDate.Year == 2005);
        }

        public IEnumerable<Animal> funReto_03_Where_filtro_animales(string vColorTipo, string vVovalSearch)
        {
            //Nota: Filtra todos los animales que sean de "color" verde que su "nombre" inicie con una vocal.

            return animalesCollection.Where(
                p =>
                p.Color.ToLower().Contains(vColorTipo.ToLower()) && (
                    p.Nombre.ToLower().StartsWith("a") ||
                    p.Nombre.ToLower().StartsWith("e") ||
                    p.Nombre.ToLower().StartsWith("i") ||
                    p.Nombre.ToLower().StartsWith("o") ||
                    p.Nombre.ToLower().StartsWith("u") 
                )
            );

            /*
            return animalesCollection.Where(
                    p =>
                    p.Nombre.ToLower().Contains(vVovalSearch.ToLower()) &&
                    p.Color.ToLower().StartsWith(vColorTipo.ToLower()) 
                //EndsWith
                );
            */
        }

        public IEnumerable<Book> funReto_02_Where_pag_serach(int vPageCount, string vSearch)
        {
            //Nota: Mostrar libros de 250 paginas y en el titulo que contenga las palabras "in Action"

            //Extension
            /*
            return librosCollection.Where(
                    p =>
                    p.PageCount > vPageCount &&
                    p.Title.Contains(vSearch)
            );
            */

            //Expresion
            return from l in librosCollection 
                   where 
                   l.PageCount > vPageCount &&
                   l.Title.Contains(vSearch)
                   select l;
        }

        public IEnumerable<Book> funReto_01_Where( int anio )
        {
            //Expresion
            return from l in librosCollection where l.PublishedDate.Year > 2000 select l;

            //Extension
            /*
            return librosCollection.Where(
                    p => 
                    p.PublishedDate.Year >= anio &&
                    p.PublishedDate.Year < anio+5
                );
            */
        }
        
    }
}
