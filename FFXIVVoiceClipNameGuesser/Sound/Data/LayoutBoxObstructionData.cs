using FFXIVVoicePackCreator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class LayoutBoxObstructionData : SoundData {
    public float4 Position1;
    public float4 Position2;
    public float4 Position3;
    public float4 Position4;
    public float2 Height;
    public float ObstacleFac;
    public float HiCutFac;
    public ObstructionFlags Flags;
    public byte[] Reserved1 = new byte[3];
    public float FadeRange;
    public short OpenTime;
    public short CloseTime;
    public byte[] Reserved2 = new byte[4];

    public LayoutBoxObstructionData() {

    }

    public override void Read(BinaryReader reader) {
        throw new NotImplementedException();
    }

    public override void Write(BinaryWriter writer) {
        throw new NotImplementedException();
    }
}
