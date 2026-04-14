using System;
using System.IO;
using System.Text;
using CybersecurityChatbot.Models;
using CybersecurityChatbot.Services;

namespace CybersecurityChatbot
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Console.Title = "Cybersecurity Awareness Bot";

            UIService uiService = new UIService();
            ChatbotService chatbotService = new ChatbotService();

            string audioPath = FindGreetingAudioPath();
            AudioService audioService = new AudioService(audioPath);

            uiService.DisplayAsciiArt();
            audioService.PlayGreeting();

            uiService.DisplayHeader("USER REGISTRATION");
            string userName = uiService.GetUserInput("Please enter your name: ");

            while (string.IsNullOrWhiteSpace(userName) || userName.Length < 2)
            {
                uiService.DisplayError("Please enter a valid name with at least 2 characters.");
                userName = uiService.GetUserInput("Please enter your name: ");
            }

            User user = new User(userName);
            chatbotService.SetUser(user);

            uiService.DisplayWelcomeMessage(userName);

            bool continueConversation = true;

            while (continueConversation)
            {
                uiService.DisplayPrompt(userName);
                string userInput = Console.ReadLine() ?? string.Empty;

                if (!string.IsNullOrWhiteSpace(userInput))
                {
                    user.IncrementMessageCount();
                }

                string response = chatbotService.GetResponse(userInput);
                uiService.DisplayBotResponse(response);

                string lowerInput = userInput.ToLower().Trim();

                if (lowerInput == "bye" ||
                    lowerInput == "goodbye" ||
                    lowerInput == "exit" ||
                    lowerInput == "quit" ||
                    lowerInput == "thank you" ||
                    lowerInput == "thanks")
                {
                    continueConversation = false;
                }
            }

            uiService.DisplayHeader("SESSION SUMMARY");
            Console.WriteLine($"Thank you for using the Cybersecurity Awareness Bot, {user.Name}.");
            Console.WriteLine($"Messages exchanged: {user.MessagesExchanged}");
            Console.WriteLine($"Session started: {user.SessionStart}");
            Console.WriteLine($"Session ended:   {DateTime.Now}");
            Console.WriteLine();

            uiService.DisplaySuccess("Stay alert, think before you click, and stay safe online.");
            Console.WriteLine();
        }

        private static string FindGreetingAudioPath()
        {
            string[] possiblePaths =
            {
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "greeting.wav"),
                Path.Combine(Directory.GetCurrentDirectory(), "Resources", "greeting.wav"),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Resources", "greeting.wav")
            };

            foreach (string path in possiblePaths)
            {
                string fullPath = Path.GetFullPath(path);

                if (File.Exists(fullPath))
                {
                    return fullPath;
                }
            }

            return string.Empty;
        }
    }
}