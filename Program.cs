using linq_csharp_console_proyecto.Class;

LinqQueries linq = new LinqQueries();
//IEnumerable<Animal> dtanimal = new List<Animal>();

//Toda la coleccion
//funImprimirJson(linq.TodaLaColecion());

//Libros despues del 2000
//funImprimirJson(linq.funReto_01_Where(2000));

//Libros que tienen mas de 250 pags y tienen en el titulo la palabra in action
//funImprimirJson(linq.funReto_02_Where_pag_serach(250,"in Action"));

//Filtra todos los animales que sean de "color" verde que su "nombre" inicie con una vocal.
//funImprimirJsonAnimal(linq.funReto_03_Where_filtro_animales("Verde", "I"));

//Todos los libros tienen Status
//Console.WriteLine($" Todos los libros tienen status? - {linq.TodosLosLibrosTienenStatus()}");

//Si algun libro fue publicado en 2005
//Console.WriteLine($" Algun libro fue publicado en 2005? - {linq.SiAlgunLibroFuePublicado2005()}");

//Devuelve Coleccion de Datos
//funImprimirJson(linq.funReto_12_Libros_Python());

//libros de Java ordenados por nombre
//funImprimirJson(linq.LibrosdeJavaPorNombreAscendente());

//libros que tienen mas de 450 paginas ordernados por cantidad de paginas
//funImprimirJson(linq.Librosmasde450pagOrdernadorPorNumPagDescendente()); //ok

//Order by
//funImprimirJsonAnimal(linq.fun_animales_ordenados_nombre());

// Take y Skip
// los 3 primeros
//funImprimirJson(linq.Top3_ibrosJavaOrdenadosPorFecha()); //ok

//tercer y caurto libro con mas de 400 paginas
//funImprimirJson(linq.TerceryCuartoLibroDeMas400Pag());

//Dcaminc
/*
Console.WriteLine("Dinamic");
//tres primeros libros filtrados con Select
linq.TresPrimeroLibrosDeLaCollecionDinamica();
Console.WriteLine("Clase");
//tres primeros libros filtrados con Select
funImprimirJson(linq.TresPrimeroLibrosDeLaCollecionBook());
*/

//count
//Camtidad de Libros entre 200 y 500
//Console.WriteLine($" Cantidad de Libros entre 200 y 500: {linq.funCantidad_libros(200, 500)}");

//Min
//Console.WriteLine($" Minima fecha de publicación: {linq.funMinDateTime()}");
//Max
//Console.WriteLine($" Maxina cantidad de Paginas: {linq.funMaxNumeroPaginasLibro()}");

//Minby
//Console.WriteLine($" Libro hojas > 0 y minimo:");
//var myLibro = linq.MinBy_LibroMenorCantidadPaginas();
//Console.WriteLine($"{myLibro.Title} - {myLibro.PageCount}");

//Maxby
/*
Console.WriteLine($" Libro fecha de Publicaion mas recinte:");
var myLibroMax = linq.MaxBy_LibroFechaPublicaionMaxRecinte();
Console.WriteLine($"{myLibroMax.Title} - {myLibroMax.PublishedDate}");
*/

//Sum
//Console.WriteLine($" Suma de paginas entre 0 y 500: {linq.Sum_CantidadDePaginas(0, 500)}");

//Aggregate
//Libros publicados despues del 2015
//Console.WriteLine(linq.TitulosDeLibrosDespuesDel2015Concatenados());

//Averge
//Console.WriteLine($" Cantidad promedio de caracteres del titulo de lista: {linq.funPromedioCaracteresTitulos_Lista()}");

//Libros publicados a partir del 2000 agrupados por ano
//ImprimirGrupo(linq.LibrosDespuesdel2000AgrupadosporAno());

//Retorna los datos de la collecion Animales agrupada por Color
ImprimirGrupoAnimales(linq.AnimalesGroupColor_Reto());


void ImprimirGrupoAnimales(IEnumerable<IGrouping<string, Animal>> Lista)
{
    foreach (var grupo in Lista)
    {
        Console.WriteLine("");
        Console.WriteLine($"Grupo: {grupo.Key}");
        Console.WriteLine("{0,-60} {1, 15}\n", "Nombre", "Color");
        foreach (var item in grupo)
        {
            Console.WriteLine("{0,-60} {1, 15} ", item.Nombre, item.Color );
        }
    }
}

void ImprimirGrupo(IEnumerable<IGrouping<int, Book>> ListadeLibros)
{
    foreach (var grupo in ListadeLibros)
    {
        Console.WriteLine("");
        Console.WriteLine($"Grupo: {grupo.Key}");
        Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
        foreach (var item in grupo)
        {
            Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.Date.ToShortDateString());
        }
    }
}

void funImprimirJsonAnimal(IEnumerable<Animal> dt)
{
    string formatoTexto = "{0, -60} {1, 15}";
    foreach (var item in dt)
    {
        Console.WriteLine($"{formatoTexto}", item.Nombre, item.Color);
    }
}

void funImprimirJson(IEnumerable<Book> dtJson)
{
    string formatoTexto = "{0, -60} {1, 15} {2, 15}";

    //Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
    Console.WriteLine($"{formatoTexto}\n", "Titulo", "N. Paginas", "Fecha publicacion");
    foreach (var item in dtJson)
    {
        Console.WriteLine($"{formatoTexto}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
        //Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
        //Console.WriteLine(item.Title);
    }
}