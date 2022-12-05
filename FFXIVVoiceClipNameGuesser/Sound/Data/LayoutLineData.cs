using FFXIVVoicePackCreator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class LayoutLineData : SoundData {
        public float4 StartPosition;
        public float4 EndPosition;
        public float MaxRange;
        public float MinRange;
        public float2 Height;
        public float RangeVolume;
        public float Volume;
        public float Pitch;
        public float ReverbFac;
        public float DopplerFac;
        public float InteriorFac;
        public float Direction;
        public byte[] Reserved1 = new byte[4];

        public LayoutLineData() {

        }

    public override void Read(BinaryReader reader) {
        throw new NotImplementedException();
    }

    public override void Write(BinaryWriter writer) {
        throw new NotImplementedException();
    }
}
