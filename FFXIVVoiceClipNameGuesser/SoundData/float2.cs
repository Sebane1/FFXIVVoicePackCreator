namespace FFXIVVoicePackCreator {
    public struct float2 {
        short x;
        short y;
        public float2(short x, short y) {
            this.x = x;
            this.y = y;
        }

        public short X { get => x; set => x = value; }
        public short Y { get => y; set => y = value; }
    }
}