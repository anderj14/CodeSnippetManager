
using System.Text;
using Newtonsoft.Json;

namespace CodeSnippetManager.entities
{
    public class SnippetManager
    {
        public List<Snippet> snippets = new List<Snippet>();
        private const string filePath = "snippets.json";

        public SnippetManager()
        {
            LoadSnippets();
        }

        public void AddSnippet(Snippet snippet)
        {
            snippets.Add(snippet);
            SaveSnnipets();
            Console.WriteLine("Fragmento agregado exitosamente.\n");
        }

        public void EditSnippet(int index)
        {
            if (index >= 0 && index < snippets.Count)
            {
                Console.WriteLine($"\nEditando el fragmento: '{snippets[index].Title}'");
                Console.Write($"Nuevo título (deje en blanco para mantener '{snippets[index].Title}'): ");
                string newTitle = Console.ReadLine();
                if (!string.IsNullOrEmpty(newTitle)) snippets[index].Title = newTitle;

                Console.Write($"Nuevo lenguaje (deje en blanco para mantener '{snippets[index].Language}'): ");
                string newLanguaje = Console.ReadLine();
                if (!string.IsNullOrEmpty(newLanguaje)) snippets[index].Language = newLanguaje;

                Console.WriteLine("Nuevo código:");
                string newCode = ReadMultilineInput();
                if (!string.IsNullOrEmpty(newCode)) snippets[index].Code = newCode;

                Console.WriteLine("Fragmento actualizado exitosamente.");
            }
            else
            {
                Console.WriteLine("Índice no válido.");
            }
        }
        public void DeleteSnippet(int index)
        {
            if (index >= 0 && index < snippets.Count)
            {
                Console.WriteLine($"\n¿Estás seguro de que deseas eliminar el fragmento '{snippets[index].Title}'? (s/n)");
                string confirmation = Console.ReadLine().ToLower();
                if (confirmation == "s")
                {
                    snippets.RemoveAt(index);
                    Console.WriteLine("Fragmento eliminado exitosamente.");
                }
                else
                {
                    Console.WriteLine("Operación cancelada.");
                }
            }
            else
            {
                Console.WriteLine("Índice no válido.");
            }
        }


        private string ReadMultilineInput()
        {
            StringBuilder input = new StringBuilder();
            string line;
            while ((line = Console.ReadLine()) != null && line != "")
            {
                input.AppendLine(line);
            }
            return input.ToString().TrimEnd();
        }

        public void DisplaySnippets()
        {
            if (snippets.Count == 0)
            {
                Console.WriteLine("\nNo hay fragmentos almacenados.\n");
                return;
            }

            Console.WriteLine("\nIndice\tTítulo\tLenguaje");
            for (int i = 0; i < snippets.Count; i++)
            {
                Console.WriteLine($"{i + 1}\t{snippets[i].Title}\t{snippets[i].Language} \n");
            }
        }

        public void DisplaySnippetCode(int index)
        {
            if (index >= 0 && index < snippets.Count)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"\nCódigo del fragmento '{snippets[index].Title}': \n");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(snippets[index].Code);
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Índice no válido.");
            }
        }

        private void SaveSnnipets()
        {
            string json = JsonConvert.SerializeObject(snippets, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        private void LoadSnippets()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                snippets = JsonConvert.DeserializeObject<List<Snippet>>(json) ?? new List<Snippet>();
            }
        }
    }
}