using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media.Domain
{
    public class TrackCollection
    {
        private List<Track> _tracks;
        public IReadOnlyCollection<Track> Tracks => _tracks;
        public TrackCollection() 
        {
            _tracks = new List<Track>();
        }
        public void AddTrack(Track track)
        {
            if(_tracks.Contains(track))
            {
                Console.WriteLine("Уже есть трек");
                return;
            }
            _tracks.Add(track);
        }
        public void RemoveTrack(Track track)
        {
            if (!_tracks.Contains(track))
            {
                Console.WriteLine("Такого трэка нет в списке");
                return;
            }
            _tracks.Remove(track);
        }
        public void DisplayAll()
        {
            int index = 1;
            foreach(var track in _tracks) 
            {
                Console.WriteLine($"{index++} " + track.GetInfo());
            }
        }
    }
}
