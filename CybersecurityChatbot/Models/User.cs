using System;

namespace CybersecurityChatbot.Models
{
    /// <summary>
    /// Represents a user interacting with the chatbot
    /// </summary>
    public class User
    {
        // Automatic properties for User class
        public string Name { get; set; }
        public DateTime SessionStart { get; set; }
        public int MessagesExchanged { get; set; }

        public User()
        {
            Name = "Guest";
            SessionStart = DateTime.Now;
            MessagesExchanged = 0;
        }

        public User(string name)
        {
            Name = name;
            SessionStart = DateTime.Now;
            MessagesExchanged = 0;
        }

        public void IncrementMessageCount()
        {
            MessagesExchanged++;
        }
    }
}

