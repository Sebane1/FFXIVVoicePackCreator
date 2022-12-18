using FFXIVVoicePackCreator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class LayoutDirectionData : SoundData {
    public float Volume;
    public float Pitch;
    public float ReverbFac;
    public float Direction;
    public float RotSpeed;
    public byte[] Reserved = new byte[3 * 4];

    public LayoutDirectionData() {
    }

    public override void Read(BinaryReader reader) {
        (Volume) = reader.ReadSingle();
        (Pitch) = reader.ReadSingle();
        (ReverbFac) = reader.ReadSingle();
        (Direction) = reader.ReadSingle();
        (RotSpeed) = reader.ReadSingle();
        for (int i = 0; i < (3 * 4); i++) {
            Reserved[i] = reader.ReadByte();
        }
    }

    public override void Write(BinaryWriter writer) {
        writer.Write(Volume);
        writer.Write(Pitch);
        writer.Write(ReverbFac);
        writer.Write(Direction);
        writer.Write(RotSpeed);
        foreach (byte value in Reserved) {
            writer.Write(value);
        }
    }
}
