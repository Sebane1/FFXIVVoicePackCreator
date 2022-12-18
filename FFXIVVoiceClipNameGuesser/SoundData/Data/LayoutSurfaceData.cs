using FFXIVVoicePackCreator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



[Flags]
public enum SurfaceFlags {
    IsReverbObject = 0x80
}

public class LayoutSurfaceData : SoundData {
    public float4 Position1;
    public float4 Position2;
    public float4 Position3;
    public float4 Position4;
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
    public SurfaceFlags Flags;
    public byte[] Reserved1 = new byte[2];
    public float RotSpeed;
    public byte[] Reserved2 = new byte[3 * 4];

    public LayoutSurfaceData() {

    }

    public override void Read(BinaryReader reader) {
        Position1 = new float4(reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16());
        Position2 = new float4(reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16());
        Position3 = new float4(reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16());
        Position4 = new float4(reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16());

        MaxRange = reader.ReadSingle();
        (MinRange) = reader.ReadSingle();

        Height = new float2(reader.ReadInt16(), reader.ReadInt16());

        RangeVolume = reader.ReadSingle();
        Volume = reader.ReadSingle();
        Pitch = reader.ReadSingle();
        ReverbFac = reader.ReadSingle();
        DopplerFac = reader.ReadSingle();
        InteriorFac = reader.ReadSingle();
        Direction = reader.ReadSingle();
        SubSoundType = reader.ReadByte();
        Flags = (SurfaceFlags)reader.ReadByte();
        for (int i = 0; i < 2; i++) {
            Reserved1[i] = reader.ReadByte();
        }
        RotSpeed = reader.ReadSingle();
        for (int i = 0; i < 3 * 4; i++) {
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
        writer.Write((int)Flags);
        foreach (byte value in Reserved2) {
            writer.Write(value);
        }
        writer.Write(RotSpeed);
        foreach (byte value in Reserved2) {
            writer.Write(value);
        }
    }
}
