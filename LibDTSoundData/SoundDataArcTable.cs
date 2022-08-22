namespace DTSoundData
{
    /// <summary>
    /// A data class used to store an ARC-Table
    /// </summary>
    public class SoundDataArcTable
    {
        /// <summary>
        /// The amount of entries
        /// </summary>
        public int entryCount { get; set; }
        /// <summary>
        /// THe size of the table in (presumably) bytes
        /// </summary>
        public int tableSize { get; set; }
        /// <summary>
        /// (Presumably) offset from one file to another within the ARC-File)
        /// </summary>
        public int relativeFileDataOffset { get; set; }
        /// <summary>
        /// The point where this table starts
        /// </summary>
        public int tableStartOffset { get; set; }
        /// <summary>
        /// Size of the name table
        /// </summary>
        public int stringTableSize { get; set; }
        /// <summary>
        /// A map containing the sound files
        /// </summary>
        /// <typeparam name="int">The ID</typeparam>
        /// <typeparam name="SoundDataFile">The File</typeparam>
        public Dictionary<int, SoundDataFile> fileList = new Dictionary<int, SoundDataFile>();
    }
}