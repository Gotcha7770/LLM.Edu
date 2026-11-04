#!/usr/bin/env dotnet
#:package Microsoft.ML.OnnxRuntimeGenAI.Cuda@0.18.0

using Microsoft.ML.OnnxRuntimeGenAI;

const string path = @"D:\LLM\FoundryCache\Microsoft\Phi-4-mini-instruct-cuda-gpu-5\v5";
using var model = new Model(path);
using var tokenizer = new Tokenizer(model);

using var genParams = new GeneratorParams(model);
genParams.SetSearchOption("max_length", 512);

// Phi-3 format prompt
const string prompt = "<|user|>\nTell a joke about .NET<|end|>\n<|assistant|>";
var tokens = tokenizer.Encode(prompt);

using var generator = new Generator(model, genParams);
generator.AppendTokenSequences(tokens);

using var stream = tokenizer.CreateStream();
while (!generator.IsDone())
{
    generator.GenerateNextToken();
    var seq = generator.GetSequence(0);

    // seq[^1] select only new tokens
    Console.Write(stream.Decode(seq[^1]));
}