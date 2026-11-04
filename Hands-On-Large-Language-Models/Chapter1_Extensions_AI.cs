#!/usr/bin/env dotnet
#:package Microsoft.Extensions.AI@10.2.0
#:package Microsoft.Extensions.AI.OpenAI@10.11.0

using System.ClientModel;
using Microsoft.Extensions.AI;
using OpenAI;

// Foundry Local default server
const string FoundryUrl = "http://localhost:58338/v1";
const string ModelId = "Phi-4-mini-instruct-cuda-gpu:5";

// 1. Connect to Foundry Local
var client = new OpenAIClient(
    new ApiKeyCredential("not-needed"),
    new OpenAIClientOptions
    {
        Endpoint = new Uri(FoundryUrl),
    });

// 2. Get chat client
var chat = client
    .GetChatClient(ModelId)
    .AsIChatClient();

var response = await chat.GetResponseAsync("Tell a joke about .NET");

Console.WriteLine(response.Text);
