using System;
using System.IO;
using CybersecurityChatbot.Models;
using CybersecurityChatbot.Services;

namespace CybersecurityChatbot
{
    /// <summary>
    /// Main program class for the Cybersecurity Awareness Chatbot
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Enable UTF-8 encoding for proper emoji display in console
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            // Initialize services
            UIService uiService = new UIService();
            ChatbotService chatbotService = new ChatbotService();
            
            // Set up audio file path - look in multiple locations
            string[] possiblePaths = new string[]
            {
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "greeting.wav"),
                Path.Combine(Directory.GetCurrentDirectory(), "Resources", "greeting.wav"),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Resources", "greeting.wav"),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin", "Debug", "net10.0", "Resources", "greeting.wav")
            };
            
            string audioPath = "";
            foreach (var path in possiblePaths)
            {
                string fullPath = Path.GetFullPath(path);
                if (File.Exists(fullPath))
                {
                    audioPath = fullPath;
                    break;
                }
            }
            
            AudioService audioService = new AudioService(audioPath);

            // Display ASCII art logo
            uiService.DisplayAsciiArt();

            // Play voice greeting (if available)
            audioService.PlayGreeting();

            // Get user name
            uiService.DisplayHeader("USER REGISTRATION");
            string userName = uiService.GetUserInput("Please enter your name: ");
            
            // Validate user name
            while (string.IsNullOrWhiteSpace(userName) || userName.Length < 2)
            {
                uiService.DisplayError("Please enter a valid name (at least 2 characters).");
                userName = uiService.GetUserInput("Please enter your name: ");
            }

            // Create user object
            User user = new User(userName);
            chatbotService.SetUser(user);

            // Display welcome message
            uiService.DisplayWelcomeMessage(userName);

            // Main conversation loop
            bool continueConversation = true;
            
            while (continueConversation)
            {
                // Display prompt
                uiService.DisplayPrompt(userName);
                string userInput = Console.ReadLine() ?? string.Empty;

                // Increment message count
                user.IncrementMessageCount();

                // Get chatbot response
                string response = chatbotService.GetResponse(userInput);

                // Display bot response
                uiService.DisplayBotResponse(response);

                // Check for exit conditions
                string lowerInput = userInput.ToLower().Trim();
                if (lowerInput == "bye" || lowerInput == "goodbye" || 
                    lowerInput == "exit" || lowerInput == "quit" ||
                    lowerInput.Contains("thank you"))
                {
                    continueConversation = false;
                }
            }

            // Display session summary
            uiService.DisplayHeader("SESSION SUMMARY");
            Console.WriteLine($"  Thank you for using the Cybersecurity Awareness Bot, {userName}!");
            Console.WriteLine($"  Session duration: {DateTime.Now - user.SessionStart}");
            Console.WriteLine($"  Messages exchanged: {user.MessagesExchanged}");
            Console.WriteLine();
            uiService.DisplaySuccess("Stay safe online! 🛡️");
            Console.WriteLine();
        }
    }
}
