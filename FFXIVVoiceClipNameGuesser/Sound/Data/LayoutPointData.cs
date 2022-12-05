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
        throw new NotImplementedException();
    }

    public override void Write(BinaryWriter writer) {
        throw new NotImplementedException();
    }
}
