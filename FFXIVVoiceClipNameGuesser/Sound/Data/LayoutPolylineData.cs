using FFXIVVoicePackCreator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class LayoutPolylineData : SoundData {
    public float MaxRange;
    public float MinRange;
    public float2 Height;
    public float RangeVolume;
    public float Volume;
    public float Pitch;
    public float ReverbFac;
    public float DopplerFac;
    public byte VertexCount;
    public byte[] Reserved1 = new byte[3];
    public float InteriorFac;
    public float Direction;
    List<float4> positions = new List<float4>();
    public LayoutPolylineData() {

        for (var i = 0; i < 16; i++) {
            ///$"Position {15 - i}"
            positions.Insert(0, new float4());
        }
    }

    public List<float4> Positions { get => positions; set => positions = value; }

    public override void Read(BinaryReader reader) {
        throw new NotImplementedException();
    }

    public override void Write(BinaryWriter writer) {
        //Write positions first
        throw new NotImplementedException();
    }
}
