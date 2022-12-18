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
        Position1 = new float4(reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16());
        Position2 = new float4(reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16());
        Position3 = new float4(reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16());
        Position4 = new float4(reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16());

        (ObstacleFac) = reader.ReadSingle();
        (HiCutFac) = reader.ReadSingle();
        (Flags) = (ObstructionFlags)reader.ReadByte();
        for (int i = 0; i < 3; i++) {
            Reserved1[i] = reader.ReadByte();
        }
        (FadeRange) = reader.ReadSingle();
        (OpenTime) = reader.ReadInt16();
        (CloseTime) = reader.ReadInt16();
        for (int i = 0; i < 3; i++) {
            Reserved2[i] = reader.ReadByte();
        }
    }

    public override void Write(BinaryWriter writer) {
        writer.Write(Position1.X);
        writer.Write(Position1.Y);
        writer.Write(Position1.Z);
        writer.Write(Position1.W);

        writer.Write(Position2.X);
        writer.Write(Position2.Y);
        writer.Write(Position2.Z);
        writer.Write(Position2.W);


        writer.Write(Position3.X);
        writer.Write(Position3.Y);
        writer.Write(Position3.Z);
        writer.Write(Position3.W);


        writer.Write(Position4.X);
        writer.Write(Position4.Y);
        writer.Write(Position4.Z);
        writer.Write(Position4.W);

        writer.Write(ObstacleFac);
        writer.Write(HiCutFac);
        writer.Write((int)Flags);
        foreach (byte value in Reserved1) {
            writer.Write(value);
        }
        writer.Write(FadeRange);
        writer.Write(OpenTime);
        writer.Write(CloseTime);
        foreach (byte value in Reserved2) {
            writer.Write(value);
        }
    }
}
