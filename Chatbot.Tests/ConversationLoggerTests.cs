using System.IO;
using FAQChatbot;
using Xunit;

public class ConversationLoggerTests
{
    [Fact]
    public void Log_Writes_To_File()
    {
        var path = Path.GetTempFileName();
        try
        {
            var logger = new ConversationLogger(path);
            logger.Log("Q1", "A1");
            var content = File.ReadAllText(path);
            Assert.Contains("Q: Q1", content);
            Assert.Contains("A: A1", content);
        }
        finally
        {
            File.Delete(path);
        }
    }
}
