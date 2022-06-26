namespace htmx_spike.Models;

public class SearchViewModel
{
    public string Query { get; set; }

    public IEnumerable<string> Results { get; set; }
        = Enumerable.Empty<string>();
}
