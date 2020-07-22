using System;
using System.IO;

namespace Utility.Library
{
    static class Situation{
        public const string basicString = "[Utility Debug call] :";
        public const int account = 0;
        public const string account_local = "account";
        public const string accountString = "Account] :";
        public const int audio = 1;
        public const string audioString = "Audio] :";
        public const string audio_local = "audio";
        public const int board = 2;
        public const string boardString = "Board] :";
        public const string board_local = "board";
        public const int device = 3;
        public const string deviceString = "device] :";
        public const string device_local = "device";
        public const int mixer = 4;
        public const string mixerString = "Mixer] :";
        public const string mixer_local = "mixer";
        public const int QRNG = 5;
        public const string QRNG_String = "QRNG] :";
        public const string QRNG_local = "QRNG";
        public const int speaker = 6;
        public const string speakerString = "Speaker] :";
        public const string speaker_local = "speaker";
    }

    static class CategoryDebug{
        public const int INFO = 0;
        public const string INFOString = "[RT_INFO_";
        public const int debug = 1;
        public const string debugString = "[RT_Debug_";
        public const int error = 2;
        public const string errorString = "[RT_ERROR_";
        public const int test = 3;
        public const string testString = "[RT_TEST_";
    }

    public class Debug
    {
        public string console_debug_line = "";
        public string file_direct = "./RT_Debug/";
        public string file_path;
        public string file_name;
        
        
        public Debug(){
            DirectoryInfo di = new DirectoryInfo(file_direct);
            if(di.Exists == false){
                di.Create();
            }
        }
        public Debug(int param_category, int param_location, string param_situation){
            DirectoryInfo di = new DirectoryInfo(file_direct);
            if(di.Exists == false){
                di.Create();
            }
            CategorizeDebug(param_category);
            InputSituation(param_location, param_situation);
            PrintDebugLine();
        }


        public void CategorizeDebug(int param_category){
            int switch_debug = param_category;
            switch(switch_debug){
                case CategoryDebug.INFO:
                    console_debug_line = CategoryDebug.INFOString;
                    file_name += "INFO";
                break;
                case CategoryDebug.error:
                    console_debug_line = CategoryDebug.errorString;
                    file_name += "error";
                break;
                case CategoryDebug.debug:
                    console_debug_line = CategoryDebug.debugString;
                    file_name += "debug";
                break;
                case CategoryDebug.test:
                    console_debug_line = CategoryDebug.testString;
                    file_name += "test";
                break;
                default :
                    console_debug_line = "This error is out of Library part.";
                break;
            }
            file_name += System.DateTime.Now.ToString("_yyyyMMdd.txt");
        }

        public void InputSituation(int param_location, string param_situation){
            int switch_debug = param_location;
            switch(switch_debug){
                case Situation.account:
                    console_debug_line += Situation.accountString + param_situation;
                break;
                case Situation.audio:
                    console_debug_line += Situation.audioString + param_situation;
                break;
                case Situation.board:
                    console_debug_line += Situation.boardString + param_situation;
                break;
                case Situation.device:
                    console_debug_line += Situation.deviceString + param_situation;
                break;
                case Situation.mixer:
                    console_debug_line += Situation.mixerString + param_situation;
                break;
                case Situation.QRNG:
                    console_debug_line += Situation.QRNG_String + param_situation;
                break;
                case Situation.speaker:
                    console_debug_line += Situation.speakerString + param_situation;
                break;
            }
        }
        public void PrintDebugLine(){ 
            System.Console.WriteLine(console_debug_line);

            file_path = file_direct + file_name;
            FileStream fs = new FileStream(file_path,FileMode.Append, FileAccess.ReadWrite);;
            StreamWriter sw = new System.IO.StreamWriter(fs, System.Text.Encoding.UTF8);
        }
        
    }
}