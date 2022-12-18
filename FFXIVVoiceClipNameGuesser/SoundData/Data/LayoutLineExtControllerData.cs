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
    public byte[] Reserved1 = new byte[3 + 4 * 4];

    public LayoutLineExtControllerData() {

    }

    public override void Read(BinaryReader reader) {
        StartPosition = new float4(reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16());
        EndPosition = new float4(reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16());
        (MaxRange) = reader.ReadSingle();
        (MinRange) = reader.ReadSingle();
        Height = new float2(reader.ReadInt16(), reader.ReadInt16());
        (RangeVolume) = reader.ReadSingle();
        (Volume) = reader.ReadSingle();
        (LowerLimit) = reader.ReadSingle();
        (FunctionNumber) = reader.ReadInt32();
        (CalcType) = reader.ReadByte();
        for (int i = 0; i < (3 + 4 * 4); i++) {
            Reserved1[i] = reader.ReadByte();
        }
    }

    public override void Write(BinaryWriter writer) {
        writer.Write(StartPosition.X);
        writer.Write(StartPosition.Y);
        writer.Write(StartPosition.Z);
        writer.Write(StartPosition.W);

        writer.Write(EndPosition.X);
        writer.Write(EndPosition.Y);
        writer.Write(EndPosition.Z);
        writer.Write(EndPosition.W);

        writer.Write(MaxRange);
        writer.Write(MinRange);
        writer.Write(Height.X);
        writer.Write(Height.Y);
        writer.Write(RangeVolume);
        writer.Write(Volume);
        writer.Write(LowerLimit);
        writer.Write(FunctionNumber);
        writer.Write(CalcType);
        foreach (byte value in Reserved1) {
            writer.Write(value);
        }
    }
}
