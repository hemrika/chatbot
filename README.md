# C# OpenAI FAQ Chatbot

A C# console chatbot that uses the OpenAI API to answer questions.

## Features
- Connects to OpenAI API (GPT-3/4)
- Asks for API key at runtime (or set in appsettings.json)
- Simple question/answer loop
- Logs each conversation to `conversation.log`

## Setup
1. `cd FAQChatbot`
2. Install dependencies: `dotnet add package OpenAI`
3. Set your OpenAI API key in `appsettings.json`
4. (Optional) Set `Logging:ConversationFile` in `appsettings.json` to change log location
5. `dotnet run`

## Requirements
- .NET 6 SDK

## Note
You need an OpenAI account and API key.
