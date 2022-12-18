namespace FFXIVVoicePackCreator {
    public struct float4 {
        short x;
        short y;
        short z;
        short w;
        public short X { get => x; set => x = value; }
        public short Y { get => y; set => y = value; }
        public short Z { get => z; set => z = value; }
        public short W { get => w; set => w = value; }
        public float4(short v = 0) {
            this.x = this.y = this.z = this.w = v;
        }

        public float4(short x, short y, short z, short w) {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }
    }
}