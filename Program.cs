using linq_csharp_console_proyecto.Class;

LinqQueries jsonData =  new LinqQueries();

funImprimirJson(jsonData.TodaLaColecion());

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