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
        throw new NotImplementedException();
    }

    public override void Write(BinaryWriter writer) {
        throw new NotImplementedException();
    }
}
