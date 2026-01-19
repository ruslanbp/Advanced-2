namespace Advanced.Tasks.LanguagePatterns;

public class DemonstrateDeconstruction
{
    public void Example()
    {
        var name = new FullName("Евгений", "Березин");
        var (first, last) = name;
    }
}