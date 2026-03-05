# Cybersecurity Awareness Chatbot

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

### Recording Your Voice Greeting

1. Record a voice message welcoming users (e.g., "Hello! Welcome to the Cybersecurity Awareness Bot. I'm here to help you stay safe online.")
2. Save the audio file as `greeting.wav` in the `Resources` folder
3. The audio file must be in WAV format for compatibility with System.Media

### Running the Application

```bash
dotnet run
```

## GitHub Setup

### Initial Setup

1. Create a new repository on GitHub
2. Initialize git in your project:
   ```bash
   git init
   git add .
   git commit -m "Initial commit: Set up project structure"
   ```
3. Add your GitHub repository as remote:
   ```bash
   git remote add origin https://github.com/yourusername/CybersecurityChatbot.git
   git push -u origin main
   ```

### Making Commits

Make at least 6 meaningful commits with descriptive messages:
- Initial commit: Set up project structure
- Added Models: User and Response classes
- Added Services: Audio, Chatbot, and UI services
- Implemented voice greeting functionality
- Added ASCII art and console UI enhancements
- Implemented response system with input validation
- Final polish and testing

### Setting Up GitHub Actions CI

1. Create `.github/workflows` directory
2. Create a workflow file (e.g., `dotnet.yml`):

```yaml
name: .NET CI

on:
  push:
    branches: [ main ]
  pull_request:
    branches: [ main ]

jobs:
  build:
    runs-on: ubuntu-latest

    steps:
    - uses: actions/checkout@v3
    - name: Setup .NET
      uses: actions/setup-dotnet@v3
      with:
        dotnet-version: '8.0.x'
    - name: Restore dependencies
      run: dotnet restore
    - name: Build
      run: dotnet build --no-restore
    - name: Test
      run: dotnet test --no-build --verbosity normal
```

3. Commit and push the workflow file
4. Verify the CI workflow runs successfully (green check mark)

## Video Presentation

Record a video presentation (8-10 minutes) explaining:
- Code structure and organization
- How the chatbot logic works
- Voice integration implementation
- Console UI formatting techniques
- Demo of the running application

Upload as an unlisted YouTube video and include the link in your submission.

## Requirements Checklist

- [x] Voice greeting (WAV file required)
- [x] ASCII art image display
- [x] Text-based greeting and user interaction
- [x] Basic response system for cybersecurity topics
- [x] Input validation
- [x] Enhanced console UI with colors and formatting
- [x] Code structure with separate classes and methods
- [x] GitHub repository with minimum 6 commits
- [x] GitHub Actions CI workflow
- [x] Video presentation

## License

This project is for educational purposes.

