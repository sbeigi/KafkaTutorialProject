using OllamaSharp;

var uri = new Uri("http://127.0.0.1:11434");
var ollama = new OllamaApiClient(uri)
{
    // select a model which should be used for further operations
    SelectedModel = "llama3.2"
};
var chat = new Chat(ollama);

while (true)
{
    Console.Write("-> ");
    var message = Console.ReadLine();
    await foreach (var answerToken in chat.SendAsync(message))
    {
        Console.Write(answerToken);
    }
    Console.WriteLine();
}