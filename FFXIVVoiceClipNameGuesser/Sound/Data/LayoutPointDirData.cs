using FFXIVVoicePackCreator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class LayoutPointDirData : SoundData {
    public float4 Position;
    public float4 Direction;
    public float RangeX;
    public float RangeY;
    public float MaxRange;
    public float MinRange;
    public float2 Height;
    public float RangeVolume;
    public float Volume;
    public float Pitch;
    public float ReverbFac;
    public float DopplerFac;
    public float InteriorFac;
    public float FixedDirection;
    public byte[] Reserved1 = new byte[3 * 4];

    public LayoutPointDirData() {

    }

    public override void Read(BinaryReader reader) {
        Position = new float4(reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16());
        Direction = new float4(reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16());
        (RangeX) = reader.ReadSingle();
        (RangeY) = reader.ReadSingle();
        (MaxRange) = reader.ReadSingle();
        (MinRange) = reader.ReadSingle();
        Height = new float2(reader.ReadInt16(), reader.ReadInt16());
        (RangeVolume) = reader.ReadSingle();
        (Volume) = reader.ReadSingle();
        (Pitch) = reader.ReadSingle();
        (ReverbFac) = reader.ReadSingle();
        (DopplerFac) = reader.ReadSingle();
        (InteriorFac) = reader.ReadSingle();
        (FixedDirection) = reader.ReadSingle();
        for (int i = 0; i < 3 * 4; i++) {
            Reserved1[i] = reader.ReadByte();
        }
    }

    public override void Write(BinaryWriter writer) {
        writer.Write(Position.X);
        writer.Write(Position.Y);
        writer.Write(Position.Z);
        writer.Write(Position.W);

        writer.Write(Direction.X);
        writer.Write(Direction.Y);
        writer.Write(Direction.Z);
        writer.Write(Direction.W);

        writer.Write(RangeX);
        writer.Write(RangeY);
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
        writer.Write(FixedDirection);
        foreach (byte value in Reserved1) {
            writer.Write(value);
        }
    }
}
