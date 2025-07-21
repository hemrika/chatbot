using System;
using System.IO;

namespace FAQChatbot
{
    public class ConversationLogger
    {
        private readonly string _filePath;

        public ConversationLogger(string filePath)
        {
            _filePath = string.IsNullOrWhiteSpace(filePath) ? "conversation.log" : filePath;
        }

        public void Log(string question, string answer)
        {
            var entry = $"[{DateTime.UtcNow:O}] Q: {question}\nA: {answer}\n";
            File.AppendAllText(_filePath, entry);
        }
    }
}
