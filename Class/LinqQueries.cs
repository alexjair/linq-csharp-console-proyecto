using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

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

        public IEnumerable<IGrouping<string, Animal>> AnimalesGroupColor_Reto()
        {
            return animalesCollection.GroupBy(p => p.Color);
        }

        public IEnumerable<IGrouping<int, Book>> LibrosDespuesdel2000AgrupadosporAno()
        {
            return librosCollection.Where(p => p.PublishedDate.Year >= 2000).GroupBy(p => p.PublishedDate.Year);
        }

        public double funPromedioCaracteresTitulos_Lista()
        {
            var MSAverageSalary = librosCollection.Average(emp => emp.Title.Length);
            return MSAverageSalary;
        }

        public string TitulosDeLibrosDespuesDel2015Concatenados()
        {
            return librosCollection
                    .Where(p => p.PublishedDate.Year > 2015)
                    .Aggregate("", (TitulosLibros, next) =>
                    {
                        if (TitulosLibros != string.Empty)
                            TitulosLibros += " - " + next.Title;
                        else
                            TitulosLibros += next.Title;

                        return TitulosLibros;
                    });
        }

        public int Sum_CantidadDePaginas( int vNumPagMin, int NumPagMax)
        {
            int TotalSalaryMS = 0;
            
            //Using Method Syntax
            TotalSalaryMS = librosCollection
                .Where(
                    emp => 
                    emp.PageCount >= vNumPagMin &&
                    emp.PageCount <= NumPagMax
                )
                .Sum(
                    emp => 
                    emp.PageCount
                );
            return TotalSalaryMS;   
        }

        public Book MaxBy_LibroFechaPublicaionMaxRecinte()
        {
            Book myLibro;

            /*
            myLibro = librosCollection
                .MaxBy(
                    p =>
                    p.PublishedDate
            );
            */

            //solucionar el null
            myLibro = librosCollection.MaxBy(
                    b => b.PublishedDate
                ) is null ? new Book() : librosCollection.MaxBy(b => b.PublishedDate);

            return myLibro;
        }

        public Book MinBy_LibroMenorCantidadPaginas()
        {
            Book myLibro;
            
            myLibro = librosCollection.Where(
                    p => 
                    p.PageCount > 0
                )
                .MinBy(
                    p => 
                    p.PageCount
                );

            return myLibro;
        }

        public long funMaxNumeroPaginasLibro()
        {
            long MaxCantidad;

            MaxCantidad = librosCollection.Max(
                p => p.PageCount
                );

            return MaxCantidad;
        }

        public DateTime funMinDateTime()
        {
            DateTime MinDate;

            MinDate = librosCollection.Min(
                p => p.PublishedDate
                );

            return MinDate;
        }
        public long funCantidad_libros(int vNumMin, int vNumMax)
        {
            long QSCount = 0;

            //forma correcta
            QSCount = librosCollection.LongCount(p => p.PageCount >= 200 && p.PageCount <= 500);

            //Using Method Syntax
            /*
            QSCount = librosCollection.Where(
                p => 
                p.PageCount >= vNumMin &&
                p.PageCount <= vNumMax
                )
                .Count();
            */
            //Using Query Syntax
            /*
            QSCount = (from p in librosCollection
                       where 
                       p.PageCount >= vNumMin &&
                       p.PageCount <= vNumMax
                       select p).LongCount();
            */

            return QSCount;
        }

        public IEnumerable<Book> TresPrimeroLibrosDeLaCollecionBook()
        {
            return librosCollection.Take(3)
            .Select(
                p => new Book() { 
                    Title = p.Title, 
                    PageCount = p.PageCount 
                }
           );
        }

        //Rerturn una clase dinamica
        public void TresPrimeroLibrosDeLaCollecionDinamica()
        {
            librosCollection.Take(3)
            .Select(
                p => new {
                   p.Title,
                   p.PageCount
                }
            );
        }

        public IEnumerable<Book> TerceryCuartoLibroDeMas400Pag()
        {
            return librosCollection
            .Where(
                p => 
                p.PageCount > 200
            )
            .Take(4) //toma los primeros 4 items
            .Skip(2); //no toma los 2 primeros items
        }

        public IEnumerable<Book> Top3_ibrosJavaOrdenadosPorFecha()
        {
            return librosCollection.Where(
                p =>
                p.Categories.Contains("Java") 
            ).OrderByDescending(
                p => 
                p.PublishedDate
            ).Take(3);
            //).Take(3);
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
