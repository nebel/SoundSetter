﻿using System.IO;
using System.Reflection;
using Dalamud.Logging;
using Newtonsoft.Json;

namespace SoundSetter.OptionInternals
{
    public class OptionOffsets
    {
        public int PlayMusicWhenMounted { get; set; }
        public int EnableNormalBattleMusic { get; set; }
        public int EnableCityStateBGM { get; set; }
        public int PlaySystemSounds { get; set; }

        public int MasterVolume { get; set; }
        public int Bgm { get; set; }
        public int SoundEffects { get; set; }
        public int Voice { get; set; }
        public int SystemSounds { get; set; }
        public int AmbientSounds { get; set; }
        public int Performance { get; set; }

        public int Self { get; set; }
        public int Party { get; set; }
        public int OtherPCs { get; set; }

        public int MasterVolumeMuted { get; set; }
        public int BgmMuted { get; set; }
        public int SoundEffectsMuted { get; set; }
        public int VoiceMuted { get; set; }
        public int SystemSoundsMuted { get; set; }
        public int AmbientSoundsMuted { get; set; }
        public int PerformanceMuted { get; set; }
        public int EqualizerMode { get; set; }
        
        private OptionOffsets()
        {
        }

        public static OptionOffsets Load()
        {
            using var s = Assembly.GetExecutingAssembly().GetManifestResourceStream("SoundSetter.Offsets.json");
            if (s == null)
            {
                PluginLog.LogError("Failed to read option offsets!");
                return new OptionOffsets();
            }

            using var sr = new StreamReader(s);
            var data = sr.ReadToEnd();

            return JsonConvert.DeserializeObject<OptionOffsets>(data);
        }
    }
}