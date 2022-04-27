using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace DTSoundData
{
    public class SoundDataArc
    {
        /// <summary>
        /// Relative path to the ARC-File
        /// </summary>
        public string path;
        public Dictionary<int, SoundDataArcTable> tables = new Dictionary<int, SoundDataArcTable>();

        /// <summary>
        /// Dictionary containing each sound type from the ARC-File
        /// </summary>
        /// <typeparam name="int">The Sound type ID</typeparam>
        /// <typeparam name="string">The sound type's name</typeparam>
        /// <returns></returns>
        public Dictionary<int, string> soundTypes = new Dictionary<int, string>()
        {
            {
                0,
                "WAVE"
            },
            {
                1,
                "SE"
            },
            {
                2,
                "SEB"
            },
            {
                4,
                "STRSE"
            },
            {
                5,
                "STRBGM"
            },
            {
                6,
                "STRVOICE"
            }
        };

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="filename">Relative path to the ARC-File</param>
        public SoundDataArc(string filename)
        {
            this.path = filename;
            this.parseArchive();
        }

        private void parseArchive()
        {

        }

        public void extractArchive(string outFolder)
        {

        }

        public bool buildArchive(string sourceFolder, string newSoundArchive)
        {
            return false;
        }
    }
}
