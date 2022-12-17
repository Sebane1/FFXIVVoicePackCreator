using FFXIVVoicePackCreator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class LayoutPolygonObstructionData : SoundData {
    public float ObstacleFac;
    public float HiCutFac;
    public ObstructionFlags Flags;
    public byte VertexCount;
    public byte[] Reserved1 = new byte[2];
    public short OpenTime;
    public short CloseTime;
    List<float4> positions = new List<float4>();

    public LayoutPolygonObstructionData() {
        for (short i = 0; i < 32; i++) {
            //15 - i
            positions.Insert(0, new float4((short)(15 - i)));
        }
    }

    public override void Read(BinaryReader reader) {
        throw new NotImplementedException();
    }

    public override void Write(BinaryWriter writer) {
        // Write positions first
        throw new NotImplementedException();
    }
}
