#!/usr/bin/env dotnet
#:package Microsoft.ML.OnnxRuntimeGenAI.Cuda@0.17.1

using Microsoft.ML.OnnxRuntimeGenAI;

const string path = @"D:\LLM\FoundryCache\Microsoft\Phi-4-mini-instruct-cuda-gpu-5\v5";
using var model = new Model(path);
using var tokenizer = new Tokenizer(model);

const string prompt = "Write an email apologizing to Sarah for the tragic gardening mishap. Explain how it happened.<|assistant|>";

using var tokens = tokenizer.Encode(prompt);
using var stream = tokenizer.CreateStream();

Console.WriteLine("Tokens:");
for (int i = 0; i < tokens[0].Length; i++)
{
    var token = tokens[0][i];
    var word = stream.Decode(token);
    Console.WriteLine($"{token}:{word}");
}
