using CodeSnippetManager.entities;

SnippetManager manager = new SnippetManager();
bool exit = false;

while (!exit)
{
    Console.WriteLine("Seleccione una opción:");
    Console.WriteLine("1. Agregar nuevo fragmento");
    Console.WriteLine("2. Mostrar fragmentos");
    Console.WriteLine("3. Ver código de un fragmento");
    Console.WriteLine("4. Editar fragmento");
    Console.WriteLine("5. Eliminar fragmento");
    Console.WriteLine("6. Salir");
    Console.Write("Opción: ");
    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.Write("Ingrese el título del fragmento: ");
            string? title = Console.ReadLine();
            Console.Write("Ingrese el lenguaje del fragmento: ");
            string? language = Console.ReadLine();
            Console.WriteLine("Ingrese el código del fragmento (finalice con una línea vacía):");
            string code = "";
            string? line;
            while ((line = Console.ReadLine()) != "")
            {
                code += line + "\n";
            }
            Snippet snippet = new Snippet(title!, language!, code);
            manager.AddSnippet(snippet);
            break;

        case "2":
            manager.DisplaySnippets();
            break;

        case "3":
            Console.WriteLine("Ingrese el indice del gragmento que desae ver: ");
            if (int.TryParse(Console.ReadLine(), out int index))
            {
                int baseIndex = index - 1;
                if (baseIndex >= 0 && baseIndex < manager.snippets.Count)
                {
                    manager.DisplaySnippetCode(baseIndex);
                }
                else
                {
                    Console.WriteLine("Índice fuera de rango. Intente nuevamente.");
                }
            }
            else
            {
                Console.WriteLine("Indice no valido");
            }
            break;
        case "4":
            Console.Write("Ingrese el índice del fragmento que desea editar: ");
            if (int.TryParse(Console.ReadLine(), out int editIndex))
            {
                int zeroBasedEditIndex = editIndex - 1;
                manager.EditSnippet(zeroBasedEditIndex);
            }
            else
            {
                Console.WriteLine("Entrada no válida. Por favor, ingrese un número entero.");
            }
            break;
        case "5":
            Console.Write("Ingrese el índice del fragmento que desea eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int deleteIndex))
            {
                int zeroBasedDeleteIndex = deleteIndex - 1;
                manager.DeleteSnippet(zeroBasedDeleteIndex);
            }
            else
            {
                Console.WriteLine("Entrada no válida. Por favor, ingrese un número entero.");
            }
            break;

        case "6":
            exit = true;
            break;

        default:
            Console.WriteLine("Opción no válida. Intente nuevamente.\n");
            break;
    }
}