using System;
using System.IO;
using System.Media;

namespace CybersecurityChatbot.Services
{
    /// <summary>
    /// Service for handling audio playback functionality
    /// </summary>
    public class AudioService
    {
        private readonly string _audioFilePath;

        public AudioService(string audioFilePath)
        {
            _audioFilePath = audioFilePath;
        }

        /// <summary>
        /// Plays the voice greeting audio file
        /// </summary>
        public void PlayGreeting()
        {
            try
            {
                if (File.Exists(_audioFilePath))
                {
                    SoundPlayer player = new SoundPlayer(_audioFilePath);
                    player.PlaySync(); // Play synchronously
                    Console.WriteLine();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("[Audio file not found. Please ensure greeting.wav is in the Resources folder.]");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"[Audio playback note: {ex.Message}]");
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Creates a placeholder audio file with instructions
        /// </summary>
        public static void CreatePlaceholderAudioFile(string path)
        {
            try
            {
                // This creates an empty WAV file as a placeholder
                // In production, you would replace this with an actual recorded greeting
                using (FileStream fs = File.Create(path))
                {
                    // WAV header for a very short silent audio
                    byte[] header = new byte[44];
                    // RIFF header
                    header[0] = 0x52; header[1] = 0x49; header[2] = 0x46; header[3] = 0x46;
                    // File size - 8
                    header[4] = 0x24; header[5] = 0x00; header[6] = 0x00; header[7] = 0x00;
                    // WAVE
                    header[8] = 0x57; header[9] = 0x41; header[10] = 0x56; header[11] = 0x45;
                    // fmt 
                    header[12] = 0x66; header[13] = 0x6D; header[14] = 0x74; header[15] = 0x20;
                    // Subchunk1Size (16)
                    header[16] = 0x10; header[17] = 0x00; header[18] = 0x00; header[19] = 0x00;
                    // AudioFormat (1 = PCM)
                    header[20] = 0x01; header[21] = 0x00;
                    // NumChannels (1 = mono)
                    header[22] = 0x01; header[23] = 0x00;
                    // SampleRate (44100)
                    header[24] = 0x44; header[25] = 0xAC; header[26] = 0x00; header[27] = 0x00;
                    // ByteRate
                    header[28] = 0x88; header[29] = 0x58; header[30] = 0x01; header[31] = 0x00;
                    // BlockAlign
                    header[32] = 0x02; header[33] = 0x00;
                    // BitsPerSample
                    header[34] = 0x10; header[35] = 0x00;
                    // data
                    header[36] = 0x64; header[37] = 0x61; header[38] = 0x74; header[39] = 0x61;
                    // Subchunk2Size
                    header[40] = 0x00; header[41] = 0x00; header[42] = 0x00; header[43] = 0x00;
                    
                    fs.Write(header, 0, 44);
                }
            }
            catch
            {
                // Silently fail if we can't create the placeholder
            }
        }
    }
}
