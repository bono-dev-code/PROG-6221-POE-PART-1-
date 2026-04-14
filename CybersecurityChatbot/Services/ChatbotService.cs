using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using CybersecurityChatbot.Models;

namespace CybersecurityChatbot.Services
{
    /// <summary>
    /// Handles chatbot logic, keyword matching, and responses
    /// </summary>
    public class ChatbotService
    {
        private readonly List<Response> _responses;
        private readonly Random _random;
        private User _currentUser;

        public ChatbotService()
        {
            _responses = ResponseBank.GetResponses();
            _random = new Random();
            _currentUser = new User();
        }

        public void SetUser(User user)
        {
            _currentUser = user;
        }

        public User GetCurrentUser()
        {
            return _currentUser;
        }

        // =========================
        // INPUT VALIDATION
        // =========================
        public bool IsValidInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            if (input.Trim().Length < 2)
                return false;

            return true;
        }

        // =========================
        // MAIN RESPONSE HANDLER
        // =========================
        public string GetResponse(string userInput)
        {
            if (!IsValidInput(userInput))
            {
                return GetInvalidInputResponse();
            }

            string normalizedInput = NormalizeInput(userInput);

            foreach (var response in _responses)
            {
                if (MatchesAnyKeyword(normalizedInput, response.Keywords))
                {
                    string selected = GetRandomResponse(response);

                    if (response.Category == "Exit")
                    {
                        return selected.Replace("{userName}", _currentUser.Name);
                    }

                    return selected;
                }
            }

            return GetDefaultResponse();
        }

        // =========================
        // NORMALIZE INPUT
        // =========================
        private string NormalizeInput(string input)
        {
            return input.ToLower().Trim();
        }

        // =========================
        // FIXED KEYWORD MATCHING (IMPORTANT)
        // =========================
        private bool MatchesAnyKeyword(string input, IEnumerable<string> keywords)
        {
            foreach (string keyword in keywords)
            {
                string normalizedKeyword = keyword.ToLower().Trim();

                // Exact match
                if (input == normalizedKeyword)
                {
                    return true;
                }

                // Match full word / phrase only
                string pattern = $@"\b{Regex.Escape(normalizedKeyword)}\b";

                if (Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        // =========================
        // RANDOM RESPONSE
        // =========================
        private string GetRandomResponse(Response response)
        {
            if (response.ResponseOptions == null || response.ResponseOptions.Count == 0)
            {
                return "I am sorry, I do not have a response for that yet.";
            }

            return response.ResponseOptions[_random.Next(response.ResponseOptions.Count)];
        }

        // =========================
        // INVALID INPUT RESPONSES
        // =========================
        private string GetInvalidInputResponse()
        {
            string[] responses =
            {
                "I did not quite understand that. Please type a full question.",
                "That input seems incomplete. Try asking about passwords, phishing, or safe browsing.",
                "Please enter a meaningful message so I can assist you properly.",
                "I am here to help with cybersecurity topics. Try asking something like 'What is phishing?'"
            };

            return responses[_random.Next(responses.Length)];
        }

        // =========================
        // DEFAULT RESPONSES
        // =========================
        private string GetDefaultResponse()
        {
            string[] responses =
            {
                "I am not sure I understand that yet. Try asking about:\n" +
                "• Password safety\n" +
                "• Phishing scams\n" +
                "• Safe browsing\n" +
                "• Malware\n" +
                "• Online privacy",

                "That topic is outside my current knowledge. I can help with passwords, scams, malware, privacy, and safe browsing.",

                "Could you rephrase that? I work best with cybersecurity topics like phishing, suspicious links, and passwords."
            };

            return responses[_random.Next(responses.Length)];
        }
    }
}