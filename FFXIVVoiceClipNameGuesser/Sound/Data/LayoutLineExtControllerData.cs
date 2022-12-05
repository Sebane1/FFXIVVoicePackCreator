using FFXIVVoicePackCreator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



    public class LayoutLineExtControllerData : SoundData {
        public float4 StartPosition;
        public float4 EndPosition;
        public float MaxRange;
        public float MinRange;
        public float2 Height;
        public float RangeVolume;
        public float Volume;
        public float LowerLimit;
        public int FunctionNumber;
        public byte CalcType;
        public byte[] Reserved1 = new byte[ 3 + 4 * 4 ];

        public LayoutLineExtControllerData() {

        }

        public override void Read(BinaryReader reader) {
            throw new NotImplementedException();
        }

        public override void Write(BinaryWriter writer) {
            throw new NotImplementedException();
        }
    }
