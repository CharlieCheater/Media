using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Media.Domain
{
    public class Track
    {
        public Track(string name, string artist, string path, TimeSpan duration)
        {
            Name = name;
            Artist = artist;
            Path = path;
            Duration = duration;
        }
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Path { get; set; }
        public TimeSpan Duration { get; set; }

        public virtual string GetInfo()
        {
            return $"{Name} - {Artist} ({Duration.ToString(@"hh\:mm\:ss")})";
        }
    }
}
