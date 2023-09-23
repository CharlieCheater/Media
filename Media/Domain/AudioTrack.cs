using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media.Domain
{
    public class AudioTrack : Track
    {
        public AudioTrack(string name, string artist, 
            string path, TimeSpan duration, uint bitrate) 
            : base(name, artist, path, duration)
        {
            Bitrate = bitrate;
        }
        public uint Bitrate { get; set; }
        public override string GetInfo()
        {
            return "[АУДИО] " + base.GetInfo();
        }
    }
}
