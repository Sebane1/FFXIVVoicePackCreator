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
        for (var i = 0; i < 16; i++) {
            positions[i] = new float4(reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16());
        }

        MaxRange = reader.ReadSingle();
        MinRange = reader.ReadSingle();
        Height = new float2(reader.ReadInt16(), reader.ReadInt16());
        RangeVolume = reader.ReadSingle();
        Volume = reader.ReadSingle();
        Pitch = reader.ReadSingle();
        ReverbFac = reader.ReadSingle();
        DopplerFac = reader.ReadSingle();
        VertexCount = reader.ReadByte();
        for (int i = 0; i < 3; i++) {
            Reserved1[i] = reader.ReadByte();
        }
        InteriorFac = reader.ReadSingle();
        Direction = reader.ReadSingle();
    }

    public override void Write(BinaryWriter writer) {
        //Write positions first
        foreach (float4 position in positions) {
            writer.Write(position.X);
            writer.Write(position.Y);
            writer.Write(position.Z);
            writer.Write(position.W);
        }

        writer.Write(MaxRange);
        writer.Write(MinRange);
        writer.Write(Height.X);
        writer.Write(Height.Y);
        writer.Write(RangeVolume);
        writer.Write(Volume);
        writer.Write(Pitch);
        writer.Write(ReverbFac);
        writer.Write(DopplerFac);
        writer.Write(VertexCount);
        foreach (byte value in Reserved1) {
            writer.Write(value);
        }
        writer.Write(InteriorFac);
        writer.Write(Direction);
    }
}
