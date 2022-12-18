using FFXIVVoicePackCreator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



[Flags]
public enum PointEnvironmentFlags {
    IsUseEnvFilterDepth = 0x40,
    IsFireWorks = 0x80
}

[Flags]
public enum PointFlags {
    IsReverbObject = 0x40,
    IsWhizGenerate = 0x80
}

public class LayoutPointData : SoundData {
    public float4 Position;
    public float MaxRange;
    public float MinRange;
    public float2 Height;
    public float RangeVolume;
    public float Volume;
    public float Pitch;
    public float ReverbFac;
    public float DopplerFac;
    public float CenterFac;
    public float InteriorFac;
    public float Direction;
    public float NearFadeStart;
    public float NearFadeEnd;
    public float FarDelayFac;
    public PointEnvironmentFlags Environment;
    public PointFlags Flag;
    public byte[] Reserved1 = new byte[2];
    public float LowerLimit;
    public short FadeInTime;
    public short FadeOutTime;
    public float ConvergenceFac;
    public byte[] Reserved2 = new byte[4];

    public LayoutPointData() {
    }

    public override void Read(BinaryReader reader) {
        Position = new float4(reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16());
        (MaxRange) = reader.ReadSingle();
        (MinRange) = reader.ReadSingle();
        Height = new float2(reader.ReadInt16(), reader.ReadInt16());
        (RangeVolume) = reader.ReadSingle();
        (Volume) = reader.ReadSingle();
        (Pitch) = reader.ReadSingle();
        (ReverbFac) = reader.ReadSingle();
        (DopplerFac) = reader.ReadSingle();
        (CenterFac) = reader.ReadSingle();
        (InteriorFac) = reader.ReadSingle();
        (Direction) = reader.ReadSingle();
        (NearFadeStart) = reader.ReadSingle();
        (NearFadeEnd) = reader.ReadSingle();
        (FarDelayFac) = reader.ReadSingle();
        (Environment) = (PointEnvironmentFlags)reader.ReadByte();
        (Flag) = (PointFlags)reader.ReadByte();
        for (int i = 0; i < 2; i++) {
            Reserved1[i] = reader.ReadByte();
        }
        (LowerLimit) = reader.ReadSingle();
        (FadeInTime) = reader.ReadInt16();
        (FadeOutTime) = reader.ReadInt16();
        (ConvergenceFac) = reader.ReadSingle();
        for (int i = 0; i < 4; i++) {
            Reserved2[i] = reader.ReadByte();
        }
    }

    public override void Write(BinaryWriter writer) {
        writer.Write(Position.X);
        writer.Write(Position.Y);
        writer.Write(Position.Z);
        writer.Write(Position.W);

        writer.Write(MaxRange);
        writer.Write(MinRange);
        writer.Write(Height.X);
        writer.Write(Height.Y);
        writer.Write(RangeVolume);
        writer.Write(Volume);
        writer.Write(Pitch);
        writer.Write(ReverbFac);
        writer.Write(DopplerFac);
        writer.Write(CenterFac);
        writer.Write(InteriorFac);
        writer.Write(Direction);
        writer.Write(NearFadeStart);
        writer.Write(NearFadeEnd);
        writer.Write(FarDelayFac);
        writer.Write((byte)Environment);
        writer.Write((byte)Flag);
        foreach (byte value in Reserved1) {
            writer.Write(value);
        }
        writer.Write(LowerLimit);
        writer.Write(FadeInTime);
        writer.Write(FadeOutTime);
        writer.Write(ConvergenceFac);
        foreach (byte value in Reserved2) {
            writer.Write(value);
        }
    }
}
