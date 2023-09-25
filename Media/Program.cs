using Media.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Media
{
    internal class Program
    {
        static TrackCollection _trackCollection = new TrackCollection();

        static void Main(string[] args)
        {
            _trackCollection.AddTrack(new AudioTrack("Тест", "Тестер", "П:/Тест.mp3", TimeSpan.FromSeconds(180), 128));
            _trackCollection.AddTrack(new AudioTrack("Тест2", "Тестер", "П:/Тест.mp3", TimeSpan.FromSeconds(240), 128));
            _trackCollection.AddTrack(new AudioTrack("Тест3", "Тестер", "П:/Тест.mp3", TimeSpan.FromSeconds(170), 128));
            _trackCollection.AddTrack(new VideoTrack("Тест4", "Тестер", "П:/Тест.mp4", TimeSpan.FromSeconds(256), 128, new Resolution(720, 480)));
            _trackCollection.AddTrack(new VideoTrack("Тест5", "Тестер", "П:/Тест.mp4", TimeSpan.FromSeconds(256), 128, new Resolution(720, 480)));
            _trackCollection.AddTrack(new VideoTrack("Тест6", "Тестер", "П:/Тест.mp4", TimeSpan.FromSeconds(256), 128, new Resolution(720, 480)));
            _trackCollection.AddTrack(new VideoTrack("Тест7", "Тестер", "П:/Тест.mp4", TimeSpan.FromSeconds(256), 128, new Resolution(720, 480)));

            //_trackCollection.DisplayAll();

            var tracks = _trackCollection.Tracks.ToList();

            // Если хотя бы один элемент соответствует условию, то возвращается true
            var any = tracks.Any(x => x.Name == "Тест1"); 

            // Если все элементы соответствует условию, то возвращается true
            var all = tracks.All(x => x.Name.Contains("Тест"));

            // Если массив содержит этот элемент, то возвращается true
            var contains = tracks.Contains(tracks[0]);

            // Если в массиве существует элемент с заданным условием, то возвращается true
            var exist = tracks.Exists(x => x.Name == "Тест");

            // перед попыткой преобразования проверяет, можно ли преобразовать элемент в целевой тип,
            // и отфильтровывает несовместимые типы
            var ofType = tracks.OfType<VideoTrack>().ToList();

            // Преобразование типов, от базового к производному и от производного к базовому
            // Использовать, когда уверены на 100%, что используется один тип данных
            var cast = ofType.Cast<Track>();
            var group = tracks.GroupBy(x => (x.Artist, x.Path));
            var pageSize = 3;
            var count = tracks.Count();
            var maxPage = count / pageSize;

            for (int page = 1; page <= maxPage + 1; page++)
            {
                var select = tracks.Skip((page - 1) * pageSize)
                .Take(pageSize).Select(x => x.GetInfo());
                foreach (var item in select)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine(new string('-', 10) + $"{page} страница" + new string('-', 10));
            }
            Console.ReadKey();
        }
    }
}
