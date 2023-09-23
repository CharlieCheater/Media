using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media.Domain
{
    public class VideoTrack : Track
    {
        public VideoTrack(string name, string artist, 
            string path, TimeSpan duration, uint bitrate, Resolution resolution) 
            : base(name, artist, path, duration)
        {
            Bitrate = bitrate;
            Resolution = resolution;
        }
        public uint Bitrate { get; set; }
        public Resolution Resolution { get; set; }
        public override string GetInfo()
        {
            return "[ВИДЕО] " + base.GetInfo();
        }
    }
}
