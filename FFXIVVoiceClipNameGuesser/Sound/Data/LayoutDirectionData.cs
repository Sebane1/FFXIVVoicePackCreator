using FFXIVVoicePackCreator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class LayoutDirectionData : SoundData {
        public float Volume;
        public float Pitch;
        public float ReverbFac;
        public float Direction;
        public float RotSpeed;
        public byte[] Reserved = new byte[3 * 4];

        public LayoutDirectionData() {
        }

        public override void Read(BinaryReader reader) {
            throw new NotImplementedException();
        }

        public override void Write(BinaryWriter writer) {
            throw new NotImplementedException();
        }
    }
