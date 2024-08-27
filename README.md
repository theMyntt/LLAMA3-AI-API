# LLAMA3 API

- Developed with .NET Core
- A API Connected to llama3-8b-8192 AI model of [Groq](https://groq.com)

<div style="display: flex; gap: 5px">
<img src="https://cdn.jsdelivr.net/gh/devicons/devicon@latest/icons/dotnetcore/dotnetcore-original.svg" width="48px"/>          
<img src="https://cdn.jsdelivr.net/gh/devicons/devicon@latest/icons/csharp/csharp-original.svg" width="48px"/>
</div>

## How to use
After clonning repository, installed nuget packages and generate your groq key:
- Configure a `.env` archive at project root like [`.env.example`](./.env.example)
- The Swagger will be available at /swagger route
- By default, the app will listen to 5000 port
- Initialize project with `dotnet run`

## Finalization
- This app use  [jgravelle.GroqApiLibrary](https://github.com/jgravelle/GroqApiLibrary) plugin, all credits is for him.