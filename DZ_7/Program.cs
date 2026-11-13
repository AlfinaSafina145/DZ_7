using System;
using System.Collections.Generic;

namespace Homework8_2
{
    class Song
    {
        string name;
        string author;
        public Song prev;

        public void SetName(string name) { this.name = name; }
        public void SetAuthor(string author) { this.author = author; }
        public void SetPrev(Song prev) { this.prev = prev; }

        public void PrintInfo()
        {
            Console.WriteLine($"Песня: '{name}', Исполнитель: {author}");
        }

        public string Title()
        {
            return $"{name} - {author}";
        }

        public override bool Equals(object d)
        {
            if (d == null) return false;
            if (d is Song otherSong)
            {
                return this.name == otherSong.name && this.author == otherSong.author;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(name, author);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Song> playlist = new List<Song>();

            Song song1 = new Song(); song1.SetName("Династия"); song1.SetAuthor("madk1d");
            Song song2 = new Song(); song2.SetName("Морем"); song2.SetAuthor("АлоэВера");
            Song song3 = new Song(); song3.SetName("Колыбельная"); song3.SetAuthor("milkovsky");
            Song song4 = new Song(); song4.SetName("Династия"); song4.SetAuthor("madk1d");

            playlist.Add(song1);
            playlist.Add(song2);
            playlist.Add(song3);
            playlist.Add(song4);

            Console.WriteLine("=== Плейлист ===");
            foreach (Song s in playlist)
            {
                s.PrintInfo();
            }

            Console.WriteLine("\n=== Сравнение 1-й и 2-й песни ===");
            if (playlist[0].Equals(playlist[1]))
                Console.WriteLine("Одинаковые песни");
            else
                Console.WriteLine("Разные песни");

            Console.WriteLine("\n=== Сравнение 1-й и 4-й песни ===");
            if (playlist[0].Equals(playlist[3]))
                Console.WriteLine("Одинаковые песни");
            else
                Console.WriteLine("Разные песни");
        }
    }
}