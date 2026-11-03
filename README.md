# LLM Practice

## Environment Setup

1) In the terminal, run `nvidia-smi` and check the "CUDA Version" in the top-right corner.
2) Install CUDA Toolkit 13.x from the [NVIDIA][2] website.
3) Download model [microsoft/Phi-3-mini-4k-instruct-onnx][3]
4) You can use [Microsoft.Foundry][4] to download and run models.
   - `winget install Microsoft.FoundryDevPack` to install foundry on Windows
   - `foundry server start`
   - `foundry model list` to list available models
   - `foundry model download Phi-4-mini-instruct-cuda-gpu:5` for Nvidia GPU
   - `foundry cache list -v` to list downloaded models
   - `foundry model load Phi-4-mini-instruct-cuda-gpu:5` to load a model in memory
   - `foundry status` look for TCP port
   - `foundry model unload` shutdown model after use

[1]: https://github.com/HandsOnLLM/Hands-On-Large-Language-Models
[2]: https://developer.nvidia.com/cuda-downloads
[3]: https://huggingface.co/microsoft/Phi-3-mini-4k-instruct-onnx
[4]: https://azure.microsoft.com/en-us/products/ai-foundry
[5]: https://onnxruntime.ai/docs/
[6]: https://github.com/microsoft/PhiCookBook
[7]: https://learn.microsoft.com/en-us/windows/ai/models/get-started-models-genai