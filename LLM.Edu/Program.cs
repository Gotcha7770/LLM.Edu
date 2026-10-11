using Microsoft.Extensions.AI;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Embeddings;
using Microsoft.SemanticKernel.Memory;

#pragma warning disable SKEXP0050
#pragma warning disable SKEXP0001

const string path = "";
var builder = Kernel.CreateBuilder();

// LLM через Ollama
builder.AddOllamaChatCompletion(
    modelId: "llama3",
    endpoint: new Uri("http://localhost:11434"));

// Embeddings через Ollama
builder.AddOllamaEmbeddingGenerator(
    modelId: "nomic-embed-text",
    endpoint: new Uri("http://localhost:11434"));
    
var kernel = builder.Build();

// In-memory vector store
var memoryStore = new VolatileMemoryStore();
var embeddingService = kernel.GetRequiredService<IEmbeddingGenerator<string, Embedding<float>>>();
var semanticMemory = new SemanticTextMemory(memoryStore, embeddingService);

foreach (var file in Directory.EnumerateFiles(path))
{
    var content = await File.ReadAllTextAsync(file);
    await semanticMemory.SaveInformationAsync(
        collection: "notes",
        text: content,
        id: Path.GetFileName(file)
    );
}