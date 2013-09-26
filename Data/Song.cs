namespace SongHistory.Data
{
    public class Song
    {
        public string Title { get; set; }
        public string Section { get; set; }

        public Song(string title, string section)
        {
            Title = title;
            Section = section;
        }
    }
}
