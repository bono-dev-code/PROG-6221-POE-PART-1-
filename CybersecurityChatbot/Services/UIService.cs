using System;
using System.Threading;

namespace CybersecurityChatbot.Services
{
    /// <summary>
    /// Handles all console UI formatting and display
    /// </summary>
    public class UIService
    {
        private readonly ConsoleColor _primaryColor = ConsoleColor.Cyan;
        private readonly ConsoleColor _secondaryColor = ConsoleColor.White;
        private readonly ConsoleColor _accentColor = ConsoleColor.Green;
        private readonly ConsoleColor _errorColor = ConsoleColor.Red;
        private readonly ConsoleColor _infoColor = ConsoleColor.Yellow;

        // =========================
        // ASCII ART HEADER
        // =========================
        public void DisplayAsciiArt()
        {
            Console.Clear();
            Console.ForegroundColor = _primaryColor;

            Console.WriteLine();
            Console.WriteLine(" ██████╗██╗   ██╗██████╗ ███████╗██████╗ ");
            Console.WriteLine("██╔════╝╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗");
            Console.WriteLine("██║      ╚████╔╝ ██████╔╝█████╗  ██████╔╝");
            Console.WriteLine("██║       ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗");
            Console.WriteLine("╚██████╗   ██║   ██████╔╝███████╗██║  ██║");
            Console.WriteLine(" ╚═════╝   ╚═╝   ╚═════╝ ╚══════╝╚═╝  ╚═╝");

            Console.WriteLine();
            Console.WriteLine("════════════════════════════════════════════════════════════");
            Console.WriteLine("        CYBERSECURITY AWARENESS CHATBOT (SA EDITION)       ");
            Console.WriteLine("════════════════════════════════════════════════════════════");

            Console.ResetColor();
            Console.WriteLine();
        }

        // =========================
        // HEADER
        // =========================
        public void DisplayHeader(string title)
        {
            Console.ForegroundColor = _primaryColor;
            Console.WriteLine("════════════════════════════════════════════════════════════");
            Console.WriteLine(CenterText(title, 60));
            Console.WriteLine("════════════════════════════════════════════════════════════");
            Console.ResetColor();
            Console.WriteLine();
        }

        // =========================
        // WELCOME MESSAGE
        // =========================
        public void DisplayWelcomeMessage(string userName)
        {
            Console.ForegroundColor = _accentColor;
            Console.WriteLine($"Welcome, {userName}!");
            Console.ResetColor();

            DisplayTypingEffect("I am your Cybersecurity Awareness Assistant.");
            DisplayTypingEffect("Ask me anything about staying safe online.");

            Console.WriteLine();
            Console.ForegroundColor = _infoColor;
            Console.WriteLine("You can ask about:");
            Console.WriteLine("• Password safety");
            Console.WriteLine("• Phishing scams");
            Console.WriteLine("• Malware");
            Console.WriteLine("• Safe browsing");
            Console.WriteLine("• Privacy");
            Console.WriteLine("• Social engineering");
            Console.ResetColor();
            Console.WriteLine();
        }

        // =========================
        // USER PROMPT
        // =========================
        public void DisplayPrompt(string userName)
        {
            Console.ForegroundColor = _accentColor;
            Console.Write($"{userName}> ");
            Console.ResetColor();
        }

        // =========================
        // BOT RESPONSE (FIXED VERSION)
        // =========================
        public void DisplayBotResponse(string response)
        {
            Console.ForegroundColor = _primaryColor;
            Console.WriteLine();
            Console.WriteLine("BOT SAYS:");
            Console.ResetColor();

            Console.ForegroundColor = _secondaryColor;

            string[] lines = response.Split('\n');

            foreach (string line in lines)
            {
                DisplayWrappedLine(line, Console.WindowWidth - 4);
            }

            Console.ResetColor();
            Console.WriteLine();
        }

        // =========================
        // TEXT WRAPPING (IMPORTANT FIX)
        // =========================
        private void DisplayWrappedLine(string text, int maxWidth)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                Console.WriteLine();
                return;
            }

            string[] words = text.Split(' ');
            string currentLine = "";

            foreach (string word in words)
            {
                if ((currentLine + word).Length + 1 > maxWidth)
                {
                    Console.WriteLine(currentLine.TrimEnd());
                    currentLine = "";
                }

                currentLine += word + " ";
            }

            if (!string.IsNullOrWhiteSpace(currentLine))
            {
                Console.WriteLine(currentLine.TrimEnd());
            }
        }

        // =========================
        // TYPING EFFECT
        // =========================
        public void DisplayTypingEffect(string message, int delayMs = 15)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(delayMs);
            }
            Console.WriteLine();
        }

        // =========================
        // INPUT
        // =========================
        public string GetUserInput(string prompt)
        {
            Console.ForegroundColor = _accentColor;
            Console.Write(prompt);
            Console.ResetColor();

            return Console.ReadLine()?.Trim() ?? "";
        }

        // =========================
        // ERROR
        // =========================
        public void DisplayError(string message)
        {
            Console.ForegroundColor = _errorColor;
            Console.WriteLine($"[ERROR] {message}");
            Console.ResetColor();
        }

        // =========================
        // INFO
        // =========================
        public void DisplayInfo(string message)
        {
            Console.ForegroundColor = _infoColor;
            Console.WriteLine($"[INFO] {message}");
            Console.ResetColor();
        }

        // =========================
        // SUCCESS
        // =========================
        public void DisplaySuccess(string message)
        {
            Console.ForegroundColor = _accentColor;
            Console.WriteLine($"[SUCCESS] {message}");
            Console.ResetColor();
        }

        // =========================
        // CENTER TEXT
        // =========================
        private string CenterText(string text, int width)
        {
            if (string.IsNullOrWhiteSpace(text) || text.Length >= width)
                return text;

            int leftPadding = (width - text.Length) / 2;
            return new string(' ', leftPadding) + text;
        }
    }
}