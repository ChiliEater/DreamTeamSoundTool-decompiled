namespace DTSoundData
{
    public class SoundDataArcTable
    {
        public int entryCount { get; set; }
        public int tableSize { get; set; }
        public int relativeFileDataOffset { get; set; }
        public int tableStartOffset { get; set; }
        public int stringTableSize { get; set; }
        public Dictionary<int, SoundDataFile> fileList = new Dictionary<int, SoundDataFile>();
    }
}