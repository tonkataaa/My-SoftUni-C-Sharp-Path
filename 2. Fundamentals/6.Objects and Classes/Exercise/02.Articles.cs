

string[] articleInfo = Console.ReadLine()
    .Split(", ");

int numberOfCommands = int.Parse(Console.ReadLine());

string title = articleInfo[0];
string content = articleInfo[1];
string author = articleInfo[2];

Article article = new Article(title, content, author);
for (int i = 0; i < numberOfCommands; i++)
{
    string[] commands = Console.ReadLine()
        .Split(": ");

    string command = commands[0];
    string value = commands[1];

    if (command == "Edit")
    {
        article.Edit(value);
    }
    else if (command == "ChangeAuthor")
    {
        article.ChangeAuthor(value);
    }
    else if (command == "Rename")
    {
        article.Rename(value);
    }
} 

Console.Write(article.ToString());


public class Article
{

    public Article(string title, string content, string author)
    {
        Title = title;
        Content = content;
        Author = author;
    }

    public string Title { get; private set; }
    public string Content { get; private set; }
    public string Author { get; private set; }


    public string Edit(string newContent)
           => Content = newContent;

    public string ChangeAuthor(string newAuthor)
        => Author = newAuthor;

    public string Rename(string newTitle)
        => Title = newTitle;

	public override string ToString()
	    => $"{Title} - {Content}: {Author}";
}