# Cybersecurity Awareness Chatbot

## 👨‍💻 Author

**Nenguda Bono**
- **Student ID**: ST10484954
- **Course**: Prog 6221
- **Institution**:RoseBank college
- **Project**: PROG 6221 POE Part 1


A command-line chatbot application designed to educate users about cybersecurity topics in South Africa. This is Part 1 of the portfolio of evidence for the Cybersecurity Awareness initiative.

## Features

- **Voice Greeting**: Plays a welcome message when the application launches
- **ASCII Art Logo**: Displays a visual cybersecurity-themed logo
- **Personalized Interaction**: Remembers and uses the user's name
- **Topic-based Responses**: Covers:
  - Password Safety
  - Phishing Awareness
  - Safe Browsing
  - Malware Protection
  - Social Engineering
  - South Africa-specific cyber threats
- **Input Validation**: Handles unexpected or invalid inputs gracefully
- **Enhanced Console UI**: Uses colors, borders, and formatting for a better user experience

## Project Structure

```
CybersecurityChatbot/
├── Models/
│   ├── User.cs              # User class with automatic properties
│   └── Response.cs          # Response model and response bank
├── Services/
│   ├── AudioService.cs      # Audio playback service
│   ├── ChatbotService.cs    # Chatbot logic and response handling
│   └── UIService.cs         # Console UI formatting
├── Resources/
│   └── greeting.wav        # Voice greeting file (you need to record this)
├── Program.cs              # Main program entry point
└── CybersecurityChatbot.csproj
```

## Getting Started

### Prerequisites

- .NET 8.0 SDK or later
- Windows operating system (for audio playback)

### Installation

1. Clone this repository to your local machine
2. Navigate to the project directory
3. Build the project:
   ```bash
   cd CybersecurityChatbot
   dotnet build
   ```

### Greeting.WAV

1.A voice message with a welcoming users ( "Hello! Welcome to the Cybersecurity Awareness Bot. I'm here to help you stay safe online.")
2.The audio file is saved as `greeting.wav` in the `Resources` folder
3. The audio file is  in WAV format for compatibility with System.Media

### Running the Application

```bash
dotnet run
```


## Video Presentation

Record a video presentation (8-10 minutes) explaining:
- Code structure and organization
- How the chatbot logic works
- Voice integration implementation
- Console UI formatting techniques
- Demo of the running application

Uploaded as an unlisted YouTube video and the link in submission.


## License

This project is for educational purposes.

## References

1. Australian Cyber Security Centre (2023) *Small Business Cyber Security Guide*. Australian Government. Available at: https://www.cybersecurity.gov.au .

2. Blank, S. (2013) 'It's Not About the Technology', *Stanford Business*. Available at: https://gblank.sites.stanford.edu .

3. Cisco (2023) *Cybersecurity Fundamentals*. Cisco Networking Academy. Available at: https://www.netacad.com .

4. Interpol (2023) *Cybercrime in Africa: Facts and Figures*. Interpol. Available at: https://www.interpol.int .

5. South African Banking Risk Information Centre (SABRIC) (2023) *Annual Crime Statistics 2022*. SABRIC. Available at: https://www.sabric.co.za .

6. National Institute of Standards and Technology (NIST) (2020) *Security and Privacy Controls for Information Systems and Organizations*. NIST Special Publication 800-53. Available at: https://csrc.nist.gov/publications .

7. KnowBe4 (2023) *Phishing Security Awareness Training*. KnowBe4 Inc. Available at: https://www.knowbe4.com .

8. W3Schools (2024) *C# Tutorial*. W3Schools. Available at: https://www.w3schools.com/cs/ .

