using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVVoicePackCreator {
    public abstract class SoundData {
        public abstract void Read(BinaryReader reader);

        public abstract void Write(BinaryWriter writer);
    }
}
