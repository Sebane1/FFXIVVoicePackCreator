using FFXIVVoicePackCreator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class LayoutPolylineObstructionData : SoundData {
    public float2 Height;
    public float ObstacleFac;
    public float HiCutFac;
    public ObstructionFlags Flags;
    public byte VertexCount;
    public byte[] Reserved1 = new byte[2];
    public float Width;
    public float FadeRange;
    public short OpenTime;
    public short CloseTime;
    List<float4> positions = new List<float4>();
    public LayoutPolylineObstructionData() {
        for (var i = 0; i < 16; i++) {
            //$"Position {15 - i}"
            positions.Insert(0, new float4());
        }
    }

    public override void Read(BinaryReader reader) {
        for (var i = 0; i < 16; i++) {
            positions[i] = new float4(reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16());
        }
        Height = new float2(reader.ReadInt16(), reader.ReadInt16());
        ObstacleFac = reader.ReadSingle();
        HiCutFac = reader.ReadSingle();
        Flags = (ObstructionFlags)reader.ReadByte();
        VertexCount = reader.ReadByte();
        for (var i = 0; i < 2; i++) {
            Reserved1[i] = reader.ReadByte();
        }
        Width = reader.ReadSingle();
        FadeRange = reader.ReadSingle();
        OpenTime = reader.ReadInt16();
        CloseTime = reader.ReadInt16();
    }

    public override void Write(BinaryWriter writer) {
        //Write positions first
        foreach (float4 position in positions) {
            writer.Write(position.X);
            writer.Write(position.Y);
            writer.Write(position.Z);
            writer.Write(position.W);
        }
        writer.Write(Height.X);
        writer.Write(Height.Y);
        writer.Write(ObstacleFac);
        writer.Write(HiCutFac);
        writer.Write((int)Flags);
        writer.Write(VertexCount);
        foreach (byte value in Reserved1) {
            writer.Write(value);
        }
        writer.Write(Width);
        writer.Write(FadeRange);
        writer.Write(OpenTime);
        writer.Write(CloseTime);
    }
}
