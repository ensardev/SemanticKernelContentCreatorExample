using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

//Get Info
Console.WriteLine("\nEnter your API Key:");
var apiKey = Console.ReadLine()!;

Console.WriteLine("\nEnter the content topic:");
var topic = Console.ReadLine()!;

Console.WriteLine("\nEnter the content tone (Example: professional, friendly, etc.):");
var tone = Console.ReadLine()!;

Console.WriteLine("\nEnter the content language (Example: Turkish, English, Français):");
var language = Console.ReadLine()!;

int minWords, maxWords;
do
{
    Console.WriteLine("\nMinimum word count:");
} while (!int.TryParse(Console.ReadLine(), out minWords));

do
{
    Console.WriteLine("\nMaximum word count:");
} while (!int.TryParse(Console.ReadLine(), out maxWords) || maxWords < minWords);


try
{
    var model = "deepseek-chat";
    var endpoint = new Uri("https://api.deepseek.com/v1");

    var httpClient = new HttpClient();
    httpClient.BaseAddress = endpoint;
    httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");


    //Kernel Configuration
    var builder = Kernel.CreateBuilder();

    builder.AddOpenAIChatCompletion(
        modelId: model,
        apiKey: apiKey,
        httpClient: httpClient
    );

    var kernel = builder.Build();

    //Prompt Templates
    string titlePrompt = $"""
        <message role="system">You are a professional content creator</message>
        <message role="user">For a blog post in {language}, in {tone}, on the topic '{topic}':
        - Catchy title
        - Maximum 10 words
        - SEO optimized
        - No emoji</message>
        """;

    string contentPrompt = $"""
        <message role="system">You are an experienced blogger</message>
        <message role="user">In {language}, in {tone}, with a word range of {minWords}-{maxWords} on the topic '{topic}':
        - Detailed blog content
        - Markdown format
        - Subheadings
        - Practical examples
        - Explanations of technical terms</message>
        """;

    string seoPrompt = $"""
        <message role="system">You're an SEO expert</message>
        <message role="user">for '{topic}' in {language}:
        - 5-10 keywords
        - High search volume
        - Long-tail keywords
        - Comma-separated list</message>
        """;

    // Generate Results
    var chatService = kernel.GetRequiredService<IChatCompletionService>();

    Console.WriteLine("\nGenerating...");

    var titleResult = await chatService.GetChatMessageContentAsync(new ChatHistory(titlePrompt), kernel: kernel);
    var contentResult = await chatService.GetChatMessageContentAsync(new ChatHistory(contentPrompt), kernel: kernel);
    var seoResult = await chatService.GetChatMessageContentAsync(new ChatHistory(seoPrompt), kernel: kernel);

    // Results
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine($"\nTitle:\n{titleResult.Content.Trim()}\n");

    Console.ResetColor();
    Console.WriteLine($"Content:\n{contentResult.Content}\n");

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"SEO Keywords:\n{seoResult.Content.Trim()}\n");
}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Error: {ex.Message}");
    Console.ResetColor();
}