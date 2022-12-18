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
        StartPosition = new float4(reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16());
        EndPosition = new float4(reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16());
        (MaxRange) = reader.ReadSingle();
        (MinRange) = reader.ReadSingle();
        Height = new float2(reader.ReadInt16(), reader.ReadInt16());
        (RangeVolume) = reader.ReadSingle();
        (Volume) = reader.ReadSingle();
        (Pitch) = reader.ReadSingle();
        (ReverbFac) = reader.ReadSingle();
        (DopplerFac) = reader.ReadSingle();
        (InteriorFac) = reader.ReadSingle();
        (Direction) = reader.ReadSingle();
        for (int i = 0; i < 0; i++) {
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
        writer.Write(Pitch);
        writer.Write(ReverbFac);
        writer.Write(DopplerFac);
        writer.Write(InteriorFac);
        writer.Write(Direction);
        foreach (byte value in Reserved1) {
            writer.Write(value);
        }
    }
}
