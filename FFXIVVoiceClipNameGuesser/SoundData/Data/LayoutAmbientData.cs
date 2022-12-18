using FFXIVVoicePackCreator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class LayoutAmbientData : SoundData {
    public float Volume;
    public float Pitch;
    public float ReverbFac;
    public float4 DirectVolume1;
    public float4 DirectVolume2;
    public byte[] Reserved = new byte[4];

    public LayoutAmbientData() {

    }

    public override void Read(BinaryReader reader) {
        Volume = reader.ReadSingle();
        Pitch = reader.ReadSingle();
        ReverbFac = reader.ReadSingle();
        DirectVolume1 = new float4(reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16());
        DirectVolume2 = new float4(reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16());
        Reserved[0] = reader.ReadByte();
        Reserved[1] = reader.ReadByte();
        Reserved[2] = reader.ReadByte();
        Reserved[3] = reader.ReadByte();
    }

    public override void Write(BinaryWriter writer) {
        writer.Write(Volume);
        writer.Write(Pitch);
        writer.Write(ReverbFac);

        writer.Write(DirectVolume1.X);
        writer.Write(DirectVolume1.Y);
        writer.Write(DirectVolume1.Z);
        writer.Write(DirectVolume1.W);

        writer.Write(DirectVolume2.X);
        writer.Write(DirectVolume2.Y);
        writer.Write(DirectVolume2.Z);
        writer.Write(DirectVolume2.W);

        new MemoryStream(Reserved).CopyTo(writer.BaseStream);
    }
}
