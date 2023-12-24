


List<Article> articles = new List<Article>();

int numberOfArticles = int.Parse(Console.ReadLine());
for (int i = 0; i < numberOfArticles; i++)
{
	string[] articleInfo = Console.ReadLine()
		.Split(", ");
	string title = articleInfo[0];
	string content = articleInfo[1];
	string author = articleInfo[2];

	Article article = new Article(title, content, author);
	articles.Add(article);
}



foreach (var article in articles)
{
	Console.WriteLine(article.ToString());
}
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

	public override string ToString()
		=> $"{Title} - {Content}: {Author}";
}