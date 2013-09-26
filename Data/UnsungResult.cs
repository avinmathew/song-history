using System;

namespace SongHistory.Data
{
    public class UnsungResult
    {
        public string Song { get; set; }
        public int NumberOfTimes { get; set; }
        public DateTime LastSung { get; set; }
        public string LastSungString
        {
            get
            {
                if (LastSung == DateTime.MinValue)
                    return string.Empty;
                else
                    return LastSung.ToString("yyyy-MM-dd");
            }
        }

        public UnsungResult(string song)
        {
            Song = song;
            NumberOfTimes = 0;
            LastSung = DateTime.MinValue;
        }
    }
}
