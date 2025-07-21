using System;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace FAQChatbot
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
            var apiKey = config["OpenAI:ApiKey"];

            if (string.IsNullOrEmpty(apiKey))
            {
                Console.WriteLine("Please enter your OpenAI API key:");
                apiKey = Console.ReadLine();
            }

            var openAI = new OpenAIService(apiKey);
            var logPath = config["Logging:ConversationFile"];
            var logger = new ConversationLogger(logPath);

            Console.WriteLine("OpenAI FAQ Chatbot. Type your question (type 'exit' to quit):");
            while (true)
            {
                var question = Console.ReadLine();
                if (question?.ToLower() == "exit") break;
                var answer = openAI.Ask(question ?? "").GetAwaiter().GetResult();
                Console.WriteLine("Bot: " + answer);
                logger.Log(question ?? string.Empty, answer);
            }
        }
    }
}
