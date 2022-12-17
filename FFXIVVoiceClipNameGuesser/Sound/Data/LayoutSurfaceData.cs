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
        throw new NotImplementedException();
    }

    public override void Write(BinaryWriter writer) {
        throw new NotImplementedException();
    }
}
