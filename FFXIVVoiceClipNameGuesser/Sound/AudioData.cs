using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVVoicePackCreator {
    public abstract class AudioData {
        public abstract WaveStream GetStream();

        public abstract void Write(BinaryWriter writer);
    }
}
