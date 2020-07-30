using System;

namespace Utility.Library
{
    public class Speaker
    {
        private Audio audio;
        private String output;
        void Audio_control(Int32 p_volume, Int32 p_treble, Int32 p_bass){
            audio.volume = p_volume;
            audio.treble = p_treble;
            audio.bass = p_bass;
        }
        void volume_control(Int32 p_volume){
            audio.volume = p_volume;
        }
        void treble_control(Int32 p_treble){
            audio.treble = p_treble;
        }

        void bass_control(Int32 p_bass){
            audio.bass = p_bass;
        }
        
        void Output_Config(String p_output){
            output = p_output;
        }


    }
}
