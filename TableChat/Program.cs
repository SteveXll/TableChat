// See https://aka.ms/new-console-template for more information
using Azure.AI.OpenAI;

Console.WriteLine("Table Parsing - Html with Javascript Visibilty");

OpenAIClient client1 = new OpenAIClient("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");

OpenAIClient client2 = new OpenAIClient("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");

string question = @"I have a table of data in markdown that I would like to convert to html,
| 1 | Team    |         |             |             |                 |/n
|---|---------|---------|-------------|-------------|-----------------|/n
| 2 | Man Utd |         |             |             |                 |/n
| 3 |         | Man Utd | Liverpool   | 23-Dec-2023 | Anfield         |/n
| 5 |         | Arsenal | Man Utd     | 26-Dec-2023 | Emirates        |/n
| 5 | Chelsea |         |             |             |                 |/n
| 6 |         | Chelsea | Aston Villa | 20-Dec-2023 | Stamford Bridge |/n
| 7 |         | Stoke   | Chelsea     | 24-Dec-2023 | Stoke Park      |/n
| 8 |         | Chelsea | West Ham    | 27-Dec-2023 | Stamford Bridge |/n
";

//string question = @"If I wanted to create a class thet would take 2 types of inputs Dictionary<int, double> or Dictionary<(int, int), double>, and output either Dictionary<int, double> or Dictionary<(int, int), double> how would I do this";
var completions = new ChatCompletionsOptions()
{
    Messages = { new ChatMessage(ChatRole.System, question) }
};

var openAiResponse35 = await client1.GetChatCompletionsAsync("gpt-3.5-turbo", completions);

var openAiResponse4 = await client2.GetChatCompletionsAsync("gpt-4", completions);

List<string> results = new List<string>();


results.Add("");
results.Add("## Chat GPT 3.5");
results.Add("");
foreach (var item in openAiResponse35.Value.Choices)
{
    results.Add(item.Message.Content);    
}


results.Add("");
results.Add("## Chat GPT 4.0");
results.Add("");
foreach (var item in openAiResponse4.Value.Choices)
{
    results.Add(item.Message.Content);
}

question = @"With our HTML Table - can we add Javascript such that when we click on contents of 'Man Utd' on row 2, row 3 and 4 toggle row visibility and when we click Chelsea on row 5 we toggle visibility of row 6,7,8";

//string question = @"If I wanted to create a class thet would take 2 types of inputs Dictionary<int, double> or Dictionary<(int, int), double>, and output either Dictionary<int, double> or Dictionary<(int, int), double> how would I do this";
completions = new ChatCompletionsOptions()
{
    Messages = { new ChatMessage(ChatRole.System, question) }
};

openAiResponse35 = await client1.GetChatCompletionsAsync("gpt-3.5-turbo", completions);

openAiResponse4 = await client2.GetChatCompletionsAsync("gpt-4", completions);


results.Add("");
results.Add("## Chat GPT 3.5");
results.Add("");
foreach (var item in openAiResponse35.Value.Choices)
{
    results.Add(item.Message.Content);
}


results.Add("");
results.Add("## Chat GPT 4.0");
results.Add("");
foreach (var item in openAiResponse4.Value.Choices)
{
    results.Add(item.Message.Content);
}

File.WriteAllLines(@"C:\scratch\TableVisibility.md", results);


int x = 0;