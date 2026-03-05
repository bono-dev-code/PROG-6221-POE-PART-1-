using System;
using System.Collections.Generic;

namespace CybersecurityChatbot.Models
{
    /// <summary>
    /// Represents a chatbot response with keywords and response text
    /// </summary>
    public class Response
    {
        public string[] Keywords { get; set; }
        public string ResponseText { get; set; }
        public string Category { get; set; }

        public Response(string[] keywords, string responseText, string category = "General")
        {
            Keywords = keywords;
            ResponseText = responseText;
            Category = category;
        }
    }

    /// <summary>
    /// Static class containing all predefined chatbot responses
    /// </summary>
    public static class ResponseBank
    {
        public static List<Response> GetResponses()
        {
            return new List<Response>
            {
                // Greeting responses
                new Response(new[] { "hello", "hi", "hey", "greetings" }, 
                    "Hello! Welcome to the Cybersecurity Awareness Bot. How can I help you stay safe online today?", "Greeting"),
                
                new Response(new[] { "how are you", "how do you do" }, 
                    "I'm doing great, thank you for asking! I'm here to help you learn about cybersecurity. What would you like to know?", "Greeting"),

                // Purpose and capabilities
                new Response(new[] { "purpose", "what can you do", "what do you do" }, 
                    "I'm your Cybersecurity Awareness Assistant! I can help you learn about:\n" +
                    "  🔐 Password Safety - Creating and managing secure passwords\n" +
                    "  🎣 Phishing - Identifying and avoiding scam emails/messages\n" +
                    "  🔗 Safe Browsing - Staying safe while browsing the internet\n" +
                    "  🛡️ General Cybersecurity Tips\n\n" +
                    "Just ask me about any of these topics!", "Information"),

                // Help keyword (general)
                new Response(new[] { "help" }, 
                    "I'm here to help you with cybersecurity! You can ask about:\n" +
                    "  🔐 Passwords - Creating secure passwords\n" +
                    "  🎣 Phishing - Avoiding scams\n" +
                    "  🔗 Safe Browsing - Internet safety\n" +
                    "  🛡️ Malware - Virus protection\n" +
                    "  🎭 Social Engineering\n" +
                    "  🇿🇦 South Africa specific issues\n\n" +
                    "Type 'help me' or 'more topics' to see all topics!", "Help"),

                // Password safety
                new Response(new[] { "password", "passwords", "secure password", "strong password" }, 
                    "🔐 PASSWORD SAFETY TIPS:\n\n" +
                    "1. Use at least 12 characters with a mix of letters, numbers, and symbols\n" +
                    "2. Never reuse passwords across different accounts\n" +
                    "3. Consider using a password manager\n" +
                    "4. Enable two-factor authentication (2FA) when available\n" +
                    "5. Never share your password with anyone\n\n" +
                    "Would you like more specific advice?", "Password Safety"),

                new Response(new[] { "password manager", "password vault" }, 
                    "A password manager is a tool that securely stores all your passwords in an encrypted vault.\n" +
                    "Benefits:\n" +
                    "  ✓ You only need to remember one master password\n" +
                    "  ✓ Generates strong, unique passwords for each account\n" +
                    "  ✓ Automatically fills login forms\n\n" +
                    "Popular options include LastPass, Dashlane, and Bitwarden.", "Password Safety"),

                // Phishing
                new Response(new[] { "phishing", "phish", "scam", "scam email", "suspicious email" }, 
                    "🎣 PHISHING AWARENESS:\n\n" +
                    "Phishing is when scammers try to trick you into revealing personal information.\n\n" +
                    "Warning Signs:\n" +
                    "  ⚠ Urgent or threatening language\n" +
                    "  ⚠ Suspicious sender addresses\n" +
                    "  ⚠ Links that don't match the displayed text\n" +
                    "  ⚠ Requests for personal or financial information\n" +
                    "  ⚠ Poor grammar and spelling\n\n" +
                    "What to do: Don't click! Delete and report suspicious messages.", "Phishing"),

                new Response(new[] { "phishing report", "report phishing" }, 
                    "To report phishing in South Africa:\n" +
                    "  📧 Forward suspicious emails to: safe@cybercrime.org.za\n" +
                    "  📱 Report SMS scams to: 7726 (SMS)\n" +
                    "  🌐 Visit: www.cybercrime.org.za\n\n" +
                    "You can also report to your bank if you've shared financial information.", "Phishing"),

                // Safe browsing
                new Response(new[] { "browsing", "safe browsing", "internet safety", "online safety" }, 
                    "🔗 SAFE BROWSING TIPS:\n\n" +
                    "1. Always check for HTTPS (lock icon) before entering personal information\n" +
                    "2. Be cautious with public Wi-Fi - avoid sensitive transactions\n" +
                    "3. Keep your browser and software updated\n" +
                    "4. Use pop-up blockers and ad blockers\n" +
                    "5. Don't download files from untrusted sources\n" +
                    "6. Be careful what personal info you share on social media\n\n" +
                    "Want to learn more about any specific topic?", "Safe Browsing"),

                // Malware
                new Response(new[] { "malware", "virus", "ransomware", "trojan", "malicious software" }, 
                    "🛡️ MALWARE PROTECTION:\n\n" +
                    "Malware is malicious software designed to damage or gain unauthorized access.\n\n" +
                    "Protection Tips:\n" +
                    "  ✓ Keep your antivirus software updated\n" +
                    "  ✓ Don't open attachments from unknown sources\n" +
                    "  ✓ Be careful with USB drives\n" +
                    "  ✓ Regular backups are essential\n" +
                    "  ✓ Keep your operating system updated\n\n" +
                    "Signs of infection: Slow computer, unexpected pop-ups, strange behavior.", "Malware"),

                // Social engineering
                new Response(new[] { "social engineering", "pretexting", "baiting" }, 
                    "🎭 SOCIAL ENGINEERING:\n\n" +
                    "This is when attackers manipulate you into giving up confidential information.\n\n" +
                    "Common Types:\n" +
                    "  • Pretexting: Creating a fake scenario to get info\n" +
                    "  • Baiting: Offering something enticing to hook you\n" +
                    "  • Quid Pro Quo: Offering a service for information\n\n" +
                    "Remember: Always verify the identity of anyone requesting information!", "Social Engineering"),

                // South Africa specific
                new Response(new[] { "south africa", "sa", "south african" }, 
                    "🇿🇦 CYBERSECURITY IN SOUTH AFRICA:\n\n" +
                    "South Africa has seen a significant rise in cyberattacks. Here's what you should know:\n\n" +
                    "  • Vishing (voice phishing) calls are common\n" +
                    "  • SIM swap fraud is prevalent\n" +
                    "  • Online banking scams are widespread\n" +
                    "  • Government institutions are often targeted\n\n" +
                    "  The Cybercrimes Act of 2020 criminalizes various cyber offenses.\n" +
                    "  Report incidents at: www.cybercrime.org.za", "South Africa"),

                // General help (more specific keywords)
                new Response(new[] { "help me", "need help", "what else", "more topics" }, 
                    "You can ask me about:\n" +
                    "  🔐 Passwords - How to create secure passwords\n" +
                    "  🎣 Phishing - Spotting scam emails and messages\n" +
                    "  🔗 Safe Browsing - Staying safe online\n" +
                    "  🛡️ Malware - Protecting against viruses\n" +
                    "  🎭 Social Engineering - Avoiding manipulation\n" +
                    "  🇿🇦 South Africa - Local cybersecurity issues\n\n" +
                    "Just type your question!", "Help"),

                // Exit
                new Response(new[] { "bye", "goodbye", "exit", "quit", "thank you", "thanks" }, 
                    "Thank you for using the Cybersecurity Awareness Bot! Remember to stay safe online. 😊\n\n" +
                    "Goodbye, {userName}! Come back anytime you have questions about cybersecurity.", "Exit")
            };
        }
    }
}

