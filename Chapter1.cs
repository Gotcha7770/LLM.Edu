#!/usr/bin/env dotnet
#:package Microsoft.ML.OnnxRuntimeGenAI.Cuda@0.17.1

using Microsoft.ML.OnnxRuntimeGenAI;

const string path = @"D:\LLM\Models\phi3-mini-cuda-int4";
using var model = new Model(path);
using var tokenizer = new Tokenizer(model);

using var genParams = new GeneratorParams(model);
genParams.SetSearchOption("max_length", 512);

// Промпт в формате Phi-3
var prompt = "<|user|>\nРасскажи анекдот про .NET<|end|>\n<|assistant|>";
var tokens = tokenizer.Encode(prompt);

using var generator = new Generator(model, genParams);
generator.AppendTokenSequences(tokens);

using var stream = tokenizer.CreateStream();
while (!generator.IsDone())
{
    generator.GenerateNextToken();
    var seq = generator.GetSequence(0);
    
    // seq[^1] выдает только новые токены
    Console.Write(stream.Decode(seq[^1]));
}