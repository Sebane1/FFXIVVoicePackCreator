using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVVoicePackCreator {
    public enum SoundObjectType {
        Null,
        Ambient,
        Direction,
        Point,
        PointDir,
        Line,
        Polyline,
        Surface,
        BoardObstruction,
        BoxObstruction,
        PolylineObstruction,
        Polygon,
        BoxExtController,
        LineExtController,
        PolygonObstruction
    }

    [Flags]
    public enum SoundObjectFlags1 {
        UseFixedDirection = 0x01,
        UnboundedDistance = 0x02,
        FirstInactive = 0x04,
        BottomInfinity = 0x08,
        TopInfinity = 0x10,
        Flag3D = 0x20,
        PointExpansion = 0x40,
        IsLittleEndian = 0x80
    }

    [Flags]
    public enum SoundObjectFlags2 {
        IsMaxRangeInterior = 0x01,
        UseDistanceFilters = 0x02,
        UseDirFirstPos = 0x04,
        IsWooferOnly = 0x08,
        IsFixedVolume = 0x10,
        IsIgnoreObstruction = 0x20,
        IsFirstFixedDirection = 0x40,
        IsLocalFixedDirection = 0x80
    }

    public class SoundLayout : SoundEntry {
        public ushort Size = 0x80;
        public SoundObjectType Type = SoundObjectType.Null;
        public byte Version;
        public SoundObjectFlags1 Flag1 = SoundObjectFlags1.UseFixedDirection;
        public byte GroupNumber;
        public short LocalId;
        public int BankId;
        public SoundObjectFlags2 Flag2 = SoundObjectFlags2.IsFirstFixedDirection;
        public byte ReverbType;
        public short AbGroupNumber;
        public float4 Volume;

        public SoundData Data = null;

        private List<object> Parsed;

        public SoundLayout() {
            Parsed = new List<object>() {
                Type,
                Version,
                Flag1,
                GroupNumber,
                LocalId,
                BankId,
                Flag2,
                ReverbType,
                AbGroupNumber,
                Volume
            };
        }

        public override void Read(BinaryReader reader) {
            Size = reader.ReadUInt16();
            Type = (SoundObjectType)reader.ReadByte();
            Version = reader.ReadByte();
            Flag1 = (SoundObjectFlags1)reader.ReadByte();
            GroupNumber = reader.ReadByte();
            LocalId = reader.ReadInt16();
            BankId = reader.ReadInt32();
            Flag2 = (SoundObjectFlags2)reader.ReadByte();
            ReverbType = reader.ReadByte();
            AbGroupNumber = reader.ReadInt16();
            Volume = new float4(reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16());
            UpdateData();
            // Data?.Read(reader);
        }

        public override void Write(BinaryWriter writer) {
            writer.Write(Size);
            writer.Write((byte)Type);
            writer.Write(Version);
            writer.Write((byte)Flag1);
            writer.Write(GroupNumber);
            writer.Write(LocalId);
            writer.Write(BankId);
            writer.Write((byte)Flag2);
            writer.Write(ReverbType);
            writer.Write(AbGroupNumber);
            writer.Write(Volume.X);
            writer.Write(Volume.Y);
            writer.Write(Volume.Z);
            writer.Write(Volume.W);
            // Data?.Write(writer);
        }

        public void UpdateData() {
            switch (Type) {
                case SoundObjectType.Ambient: Data = new LayoutAmbientData(); break;

                case SoundObjectType.Direction: Data = new LayoutDirectionData(); break;

                case SoundObjectType.Point: Data = new LayoutPointData(); break;

                case SoundObjectType.PointDir: Data = new LayoutPointDirData(); break;

                case SoundObjectType.Line: Data = new LayoutLineData(); break;

                case SoundObjectType.Polyline: Data = new LayoutPolylineData(); break;

                case SoundObjectType.Surface: Data = new LayoutSurfaceData(); break;

                case SoundObjectType.BoardObstruction: Data = new LayoutBoardObstructionData(); break;

                case SoundObjectType.BoxObstruction: Data = new LayoutBoxObstructionData(); break;

                case SoundObjectType.PolylineObstruction: Data = new LayoutPolylineObstructionData(); break;

                case SoundObjectType.Polygon: Data = new LayoutPolygonData(); break;

                case SoundObjectType.LineExtController: Data = new LayoutLineExtControllerData(); break;

                case SoundObjectType.PolygonObstruction: Data = new LayoutPolygonObstructionData();  break;
            };
        }
    }
}
