
namespace CodeSnippetManager.entities
{
    public class Snippet
    {
        public Snippet(string title, string language, string code)
        {
            Title = title;
            Language = language;
            Code = code;
        }
        
        public string Title { get; set; }
        public string Language { get; set; }
        public string Code { get; set; }
    }
}