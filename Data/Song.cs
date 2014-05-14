using System;

namespace SongHistory.Data
{
    public class Song
    {
        public DateTime Date { get; set; }
        public string Section { get; set; }
        public string Name { get; set; }

        public Song(DateTime date, string section, string name)
        {
            Date = date;
            Name = name;
            Section = section;
        }
    }
}
