using System;
using System.Threading;

namespace CybersecurityChatbot.Services
{
    /// <summary>
    /// Service for handling console UI formatting and visual elements
    /// </summary>
    public class UIService
    {
        // Console colors
        private readonly ConsoleColor _primaryColor = ConsoleColor.Cyan;
        private readonly ConsoleColor _secondaryColor = ConsoleColor.White;
        private readonly ConsoleColor _accentColor = ConsoleColor.Green;
        private readonly ConsoleColor _warningColor = ConsoleColor.Yellow;
        private readonly ConsoleColor _errorColor = ConsoleColor.Red;

        /// <summary>
        /// Displays the ASCII art logo for the chatbot
        /// </summary>
        public void DisplayAsciiArt()
        {
            Console.ForegroundColor = _primaryColor;
            Console.WriteLine(@"");
            Console.WriteLine(@"   ██████╗ ███████╗████████╗██████╗  ██████╗  █████╗ ██████╗  ██████╗  ");
            Console.WriteLine(@"  ██╔════╝ ██╔════╝╚══██╔══╝██╔══██╗██╔═══██╗██╔══██╗██╔══██╗██╔═══██╗ ");
            Console.WriteLine(@"  ██║  ███╗█████╗     ██║   ██████╔╝██║   ██║███████║██████╔╝██║   ██║ ");
            Console.WriteLine(@"  ██║   ██║██╔══╝     ██║   ██╔══██╗██║   ██║██╔══██║██╔══██╗██║   ██║ ");
            Console.WriteLine(@"  ╚██████╔╝███████╗   ██║   ██║  ██║╚██████╔╝██║  ██║██║  ██║╚██████╔╝ ");
            Console.WriteLine(@"   ╚═════╝ ╚══════╝   ╚═╝   ╚═╝  ╚═╝ ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝ ╚═════╝  ");
            Console.WriteLine(@"");
            Console.WriteLine(@"        ╔═══════════════════════════════════════════════╗        ");
            Console.WriteLine(@"        ║   CYBERSECURITY AWARENESS BOT v1.0            ║        ");
            Console.WriteLine(@"        ║   Protecting South Africans Online            ║        ");
            Console.WriteLine(@"        ╚═══════════════════════════════════════════════╝        ");
            Console.WriteLine(@"");
            Console.ResetColor();
            Console.WriteLine();
        }

        /// <summary>
        /// Displays a decorative header
        /// </summary>
        public void DisplayHeader(string title)
        {
            Console.ForegroundColor = _primaryColor;
            int borderWidth = Math.Max(title.Length + 4, 60);
            string border = new string('═', borderWidth);
            int paddingLeft = (borderWidth - title.Length) / 2;
            string centeredTitle = new string(' ', paddingLeft) + title;
            Console.WriteLine($"\n{border}");
            Console.WriteLine(centeredTitle);
            Console.WriteLine(border);
            Console.ResetColor();
            Console.WriteLine();
        }

        /// <summary>
        /// Displays a section divider
        /// </summary>
        public void DisplayDivider()
        {
            Console.ForegroundColor = _secondaryColor;
            Console.WriteLine(new string('─', 60));
            Console.ResetColor();
        }

        /// <summary>
        /// Displays a box frame for messages
        /// </summary>
        public void DisplayBox(string message, bool isUser = false)
        {
            ConsoleColor frameColor = isUser ? _accentColor : _primaryColor;
            ConsoleColor textColor = isUser ? _secondaryColor : _secondaryColor;

            string[] lines = message.Split('\n');
            int maxLength = 0;
            foreach (var line in lines)
            {
                if (line.Length > maxLength)
                    maxLength = line.Length;
            }

            maxLength = Math.Max(maxLength, 20);

            // Calculate border width: accounts for ║ + space + content + space + ║
            int borderWidth = maxLength + 2;

            Console.ForegroundColor = frameColor;
            Console.Write("╔");
            Console.Write(new string('═', borderWidth));
            Console.WriteLine("╗");

            foreach (var line in lines)
            {
                Console.ForegroundColor = frameColor;
                Console.Write("║ ");
                Console.ForegroundColor = textColor;
                Console.Write(line.PadRight(maxLength));
                Console.ForegroundColor = frameColor;
                Console.WriteLine(" ║");
            }

            Console.ForegroundColor = frameColor;
            Console.Write("╚");
            Console.Write(new string('═', borderWidth));
            Console.WriteLine("╝");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays a welcome message with formatting
        /// </summary>
        public void DisplayWelcomeMessage(string userName)
        {
            // Calculate the maximum width needed for the box
            string[] welcomeLines = new string[]
            {
                "        W E L C O M E   T O   O U R   C H A T B O T        ",
                "     Your Personal Cybersecurity Awareness Assistant       "
            };
            
            int maxWelcomeLength = 0;
            foreach (var line in welcomeLines)
            {
                if (line.Length > maxWelcomeLength)
                    maxWelcomeLength = line.Length;
            }
            
            // Calculate border width to match content: ║ + 2 spaces + content + 2 spaces + ║
            int borderWidth = maxWelcomeLength + 4;
            string topBorder = "╔" + new string('═', borderWidth) + "╗";
            string middleBorder = "║" + new string(' ', borderWidth) + "║";
            string bottomBorder = "╚" + new string('═', borderWidth) + "╝";
            
            Console.ForegroundColor = _accentColor;
            Console.WriteLine();
            Console.WriteLine(topBorder);
            Console.WriteLine(middleBorder);
            Console.WriteLine($"║  {welcomeLines[0].PadRight(maxWelcomeLength)}  ║");
            Console.WriteLine(middleBorder);
            Console.WriteLine($"║  {welcomeLines[1].PadRight(maxWelcomeLength)}  ║");
            Console.WriteLine(middleBorder);
            Console.WriteLine(bottomBorder);
            Console.ResetColor();

            Console.ForegroundColor = _secondaryColor;
            Console.WriteLine();
            Console.WriteLine($"  Hello, {userName}! 👋");
            Console.WriteLine();
            Console.WriteLine("  I'm here to help you stay safe online!");
            Console.WriteLine("  You can ask me about:");
            Console.WriteLine();
            Console.ForegroundColor = _accentColor;
            Console.WriteLine("    🔐  Password Safety");
            Console.WriteLine("    🎣  Phishing & Scams");
            Console.WriteLine("    🔗  Safe Browsing");
            Console.WriteLine("    🛡️  Malware Protection");
            Console.WriteLine("    🎭  Social Engineering");
            Console.WriteLine("    🇿🇦  South Africa Cyber Threats");
            Console.ResetColor();
            Console.WriteLine();
            DisplayDivider();
            Console.WriteLine();
        }

        /// <summary>
        /// Displays user input prompt
        /// </summary>
        public void DisplayPrompt(string userName)
        {
            Console.ForegroundColor = _accentColor;
            Console.Write($"\n{userName}> ");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays bot response with box
        /// </summary>
        public void DisplayBotResponse(string response)
        {
            DisplayBox(response, false);
        }

        /// <summary>
        /// Displays a typing effect for bot messages
        /// </summary>
        public void DisplayTypingEffect(string message, int delayMs = 20)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(delayMs);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Clears the console and displays fresh UI
        /// </summary>
        public void ClearAndReset()
        {
            Console.Clear();
            DisplayAsciiArt();
        }

        /// <summary>
        /// Displays error message
        /// </summary>
        public void DisplayError(string message)
        {
            Console.ForegroundColor = _errorColor;
            Console.WriteLine($"  ⚠ Error: {message}");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays info message
        /// </summary>
        public void DisplayInfo(string message)
        {
            Console.ForegroundColor = _warningColor;
            Console.WriteLine($"  ℹ {message}");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays success message
        /// </summary>
        public void DisplaySuccess(string message)
        {
            Console.ForegroundColor = _accentColor;
            Console.WriteLine($"  ✓ {message}");
            Console.ResetColor();
        }

        /// <summary>
        /// Gets user input with validation
        /// </summary>
        public string GetUserInput(string prompt)
        {
            Console.ForegroundColor = _accentColor;
            Console.Write(prompt);
            Console.ResetColor();
            string input = Console.ReadLine() ?? string.Empty;
            return input.Trim();
        }
    }
}

