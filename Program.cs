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
Console.WriteLine($" Cantidad de Libros entre 200 y 500: {linq.funCantidad_libros(200, 500)}");



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