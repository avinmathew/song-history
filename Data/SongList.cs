using System;
using System.Collections.Generic;

namespace SongHistory.Data
{
    public class SongList
    {
        public DateTime Date { get; set; }
        public List<Song> Songs { get; set; }

        public SongList(DateTime date)
        {
            Date = date;
            Songs = new List<Song>();
        }
    }
}
