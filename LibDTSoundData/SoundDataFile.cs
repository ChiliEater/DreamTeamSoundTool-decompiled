namespace DTSoundData
{
    /// <summary>
    /// This data class holds info about a sound file
    /// </summary>
    public class SoundDataFile
    {
        /// <summary>
        /// The file ID
        /// </summary>
        public int fileID { get; set; }
        /// <summary>
        /// The size of the file
        /// </summary>
        public int size { get; set; }
        /// <summary>
        /// The position of the file in the ARC-File
        /// </summary>
        public int offset { get; set; }
        /// <summary>
        /// The name of this file as the string table indicates
        /// </summary>
        public string? name { get; set; }
    }
}