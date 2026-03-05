using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using CybersecurityChatbot.Models;

namespace CybersecurityChatbot.Services
{
    /// <summary>
    /// Service for handling chatbot responses and conversation logic
    /// </summary>
    public class ChatbotService
    {
        private readonly List<Response> _responses;
        private User _currentUser;

        public ChatbotService()
        {
            _responses = ResponseBank.GetResponses();
            _currentUser = new User();
        }

        /// <summary>
        /// Sets the current user
        /// </summary>
        public void SetUser(User user)
        {
            _currentUser = user;
        }

        /// <summary>
        /// Gets the current user
        /// </summary>
        public User GetCurrentUser()
        {
            return _currentUser;
        }

        /// <summary>
        /// Validates user input
        /// </summary>
        public bool IsValidInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;
            
            if (input.Trim().Length < 2)
                return false;

            return true;
        }

        /// <summary>
        /// Generates a response based on user input
        /// </summary>
        public string GetResponse(string userInput)
        {
            if (!IsValidInput(userInput))
            {
                return GetInvalidInputResponse();
            }

            // Normalize input for comparison
            string normalizedInput = userInput.ToLower().Trim();
            
            // Check each response for keyword matches
            foreach (var response in _responses)
            {
                foreach (var keyword in response.Keywords)
                {
                    // Use word boundary matching for better accuracy
                    if (Regex.IsMatch(normalizedInput, $@"\b{Regex.Escape(keyword)}\b", RegexOptions.IgnoreCase))
                    {
                        // Handle exit commands
                        if (response.Category == "Exit")
                        {
                            return FormatExitResponse(response.ResponseText);
                        }
                        return response.ResponseText;
                    }
                }
            }

            // No match found - return default response
            return GetDefaultResponse();
        }

        /// <summary>
        /// Formats exit response with user name
        /// </summary>
        private string FormatExitResponse(string response)
        {
            return response.Replace("{userName}", _currentUser.Name);
        }

        /// <summary>
        /// Gets response for invalid input
        /// </summary>
        private string GetInvalidInputResponse()
        {
            string[] responses = new[]
            {
                "I didn't quite understand that. Could you rephrase?",
                "Sorry, I didn't catch that. Can you try again?",
                "I'm not sure I understand. Could you phrase that differently?",
                "That doesn't seem to match any of my cybersecurity topics. Try asking about passwords, phishing, or safe browsing!"
            };

            Random random = new Random();
            return responses[random.Next(responses.Length)];
        }

        /// <summary>
        /// Gets default response for unrecognized input
        /// </summary>
        private string GetDefaultResponse()
        {
            string[] responses = new[]
            {
                "I'm not sure I understand that. Try asking about:\n" +
                "  🔐 Passwords - How to stay secure\n" +
                "  🎣 Phishing - Avoiding scams\n" +
                "  🔗 Safe Browsing - Internet safety\n" +
                "  🛡️ Malware - Virus protection\n\n" +
                "Or type 'help' for more options!",

                "I don't have information on that topic yet. Here are some things I can help with:\n" +
                "  • Password safety\n" +
                "  • Phishing awareness\n" +
                "  • Safe browsing practices\n" +
                "  • Malware protection\n\n" +
                "What would you like to know?",

                "That's outside my area of expertise. I'm here to help with cybersecurity! Try asking:\n" +
                "  'How do I create a strong password?'\n" +
                "  'What is phishing?'\n" +
                "  'How do I stay safe online?'"
            };

            Random random = new Random();
            return responses[random.Next(responses.Length)];
        }
    }
}

