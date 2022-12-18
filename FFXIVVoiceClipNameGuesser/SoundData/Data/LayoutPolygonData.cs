using FFXIVVoicePackCreator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


[Flags]
public enum PolygonFlags {
    IsReverbObject = 0x80
}

public class LayoutPolygonData : SoundData {
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
    public byte SubSoundType;
    public PolygonFlags Flag;
    public byte VertexCount;
    public byte[] Reserved1 = new byte[1];
    public float RotSpeed;
    public byte[] Reserved2 = new byte[3 * 4];
    List<float4> positions = new List<float4>();
    public LayoutPolygonData() {
        //Parsed = new() {
        //    MaxRange,
        //    MinRange,
        //    Height,
        //    RangeVolume,
        //    Volume,
        //    Pitch,
        //    ReverbFac,
        //    DopplerFac,
        //    InteriorFac,
        //    Direction,
        //    SubSoundType,
        //    Flag,
        //    VertexCount,
        //    Reserved1,
        //    RotSpeed,
        //    Reserved2,
        //    // Positions go here
        //};

        for (var i = 0; i < 32; i++) { positions.Add(new float4()); }
    }

    public override void Read(BinaryReader reader) {
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
        (SubSoundType) = reader.ReadByte();
        (Flag) = (PolygonFlags)reader.ReadByte();
        (VertexCount) = reader.ReadByte();
        (Reserved1[0]) = reader.ReadByte();
        (RotSpeed) = reader.ReadSingle();
        for (var i = 0; i < 3 * 4; i++) {
            Reserved2[i] = reader.ReadByte();
        }
        for (var i = 0; i < 32; i++) {
            positions[i] = new float4(reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16());
        }
    }

    public override void Write(BinaryWriter writer) {
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
        writer.Write(SubSoundType);
        writer.Write((byte)Flag);
        writer.Write(VertexCount);
        writer.Write(Reserved1[0]);
        writer.Write(RotSpeed);
        foreach (byte value in Reserved2) {
            writer.Write(value);
        }
        foreach (float4 position in positions) {
            writer.Write(position.X);
            writer.Write(position.Y);
            writer.Write(position.Z);
            writer.Write(position.W);
        }
    }
}
