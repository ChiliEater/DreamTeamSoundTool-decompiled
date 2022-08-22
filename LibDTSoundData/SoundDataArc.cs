using System.Dynamic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace DTSoundData
{
    /// <summary>
    /// Dictionary containing each sound type from the ARC-File
    /// </summary>
    /// <typeparam name="int">The Sound type ID</typeparam>
    /// <typeparam name="string">The sound type's name</typeparam>
    /// <returns></returns>
    public enum SoundTypes : int
    {
        WAVE = 0,
        SE = 1,
        SEB = 2,
        STRSE = 4,
        STRBGM = 5,
        STRVOICE = 6
    }

    /// <summary>
    /// This class provides functions to read and convert an ARC-File into a generally usable format
    /// </summary>
    public class SoundDataArc
    {
        /// <summary>
        /// Offset to (presumably) skip the header info
        /// </summary>
        private const int OFFSET_PAD = 32;
        /// <summary>
        /// Multiplier to jump to an entry
        /// </summary>
        private const int OFFSET_MULTIPLIER = 16;
        /// <summary>
        /// The file extension of the output files
        /// </summary>
        private const string FILE_EXTENSION = ".rsd";

        /// <summary>
        /// Relative path to the ARC-File
        /// </summary>
        private string path;

        /// <summary>
        /// Dictionary that holds all ARC-Tables
        /// </summary>
        /// <typeparam name="int">ID of the table</typeparam>
        /// <typeparam name="SoundDataArcTable">The table</typeparam>
        private Dictionary<int, SoundDataArcTable> tables = new Dictionary<int, SoundDataArcTable>();


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="filename">Relative path to the ARC-File</param>
        public SoundDataArc(string filename)
        {
            path = filename;
            parseArchive();
        }

        /// <summary>
        /// Extracts the contents of the ARC-File onto disk
        /// </summary>
        /// <param name="outFolder">The desired output folder</param>
        public void extractArchive(string outFolder)
        {
            if (!Directory.Exists(outFolder))
            {
                Directory.CreateDirectory(outFolder);
            }
            using BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open));

            foreach (KeyValuePair<int, SoundDataArcTable> table in tables)
            {
                string str = Path.Combine(outFolder, ((SoundTypes) table.Key).ToString());
                if (!Directory.Exists(str))
                {
                    Directory.CreateDirectory(str);
                }

                foreach(KeyValuePair<int, SoundDataFile> file in table.Value.fileList)
                {
                    reader.BaseStream.Seek(table.Value.tableStartOffset + file.Value.offset, SeekOrigin.Begin);
                    
                    using BinaryWriter writer = new BinaryWriter(File.Open(Path.Combine(str, file.Value.name + FILE_EXTENSION), FileMode.Create));
                    writer.Write(reader.ReadBytes(file.Value.size));
                    writer.Close();
                }
            }
            reader.Close();
        }

        /// <summary>
        /// Reads metadata from the set ARC-File
        /// </summary>
        private void parseArchive()
        {
            long length = new FileInfo(path).Length;
            using BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open));

            while (reader.BaseStream.Position < length)
            {
                // Get ARC-Table info
                SoundDataArcTable arcTable = new SoundDataArcTable();
                int tableKey = reader.ReadInt32();
                arcTable.entryCount = reader.ReadInt32();
                arcTable.tableSize = reader.ReadInt32();
                arcTable.relativeFileDataOffset = reader.ReadInt32();
                arcTable.tableStartOffset = reader.ReadInt32();
                arcTable.stringTableSize = reader.ReadInt32();
                
                // Get file infos
                for (int entryKey = 0; entryKey < arcTable.entryCount; entryKey++)
                {
                    reader.BaseStream.Seek(arcTable.tableStartOffset + OFFSET_PAD + entryKey * OFFSET_MULTIPLIER, SeekOrigin.Begin);
                    SoundDataFile file = new SoundDataFile();
                    file.fileID = reader.ReadInt32();
                    file.size = reader.ReadInt32();
                    file.offset = reader.ReadInt32();
                    arcTable.fileList.Add(entryKey, file);
                }

                // Reset position
                reader.BaseStream.Seek(arcTable.tableStartOffset + OFFSET_PAD + arcTable.entryCount * OFFSET_MULTIPLIER, SeekOrigin.Begin);

                // Trim whitespaces
                for (int entryKey = 0; entryKey < arcTable.entryCount; entryKey++)
                {
                    arcTable.fileList[entryKey].name = reader.ReadString().TrimEnd(new char[1]);
                }

                // Add table to dictionary and advance stream
                tables.Add(tableKey, arcTable);
                reader.BaseStream.Seek(arcTable.tableStartOffset + arcTable.tableSize, SeekOrigin.Begin);
            }

            reader.Close();
        }

        /// <summary>
        /// Unused function from the original assembly. Stubbed, just in case
        /// </summary>
        /// <param name="sourceFolder"></param>
        /// <param name="newSoundArchive"></param>
        /// <returns></returns>
        private bool buildArchive(string sourceFolder, string newSoundArchive)
        {
            return false;
        }
    }
}
