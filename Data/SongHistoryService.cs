using System;
using System.Collections.Generic;
using System.Linq;
using Google.GData.Spreadsheets;

namespace SongHistory.Data
{
    public class SongHistoryService
    {
        private string _email;
        private string _password;
        private string _spreadsheet;

        private List<string> _allSongs = new List<string>();
        private List<SongList> _songLists = new List<SongList>();

        public SongHistoryService(string email, string password, string spreadsheet)
        {
            _email = email;
            _password = password;
            _spreadsheet = spreadsheet;
        }

        public IEnumerable<UnsungResult> GetUnsung()
        {
            if (!_allSongs.Any())
            {
                GetData(); // Only retrieve data if it isn't already cached
            }

            var results = new Dictionary<string, UnsungResult>();
            foreach (var song in _allSongs)
            {
                results.Add(song, new UnsungResult(song));
            }

            foreach (var songList in _songLists)
            {
                foreach (var song in songList.Songs)
                {
                    UnsungResult data;
                    if (results.TryGetValue(song.Title, out data)) // Ignore unknown songs
                    {
                        data.NumberOfTimes++;
                        data.LastSung = songList.Date > data.LastSung ? songList.Date : data.LastSung;
                    }
                }
            }

            return results.Values;
        }

        private void GetData()
        {
            var service = new SpreadsheetsService("SongHistory");
            service.setUserCredentials(_email, _password);

            var spreadsheetQuery = new SpreadsheetQuery();
            var feed = service.Query(spreadsheetQuery);

            var doc = (SpreadsheetEntry)feed.Entries.Single(e => e.Title.Text == _spreadsheet);

            AddAllSongs(service, doc);

            foreach (WorksheetEntry entry in doc.Worksheets.Entries.Where(e => e.Title.Text != "Songs"))
            {
                AddSongList(service, entry);
            }
        }

        private void AddAllSongs(SpreadsheetsService service, SpreadsheetEntry doc)
        {
            var songsSheet = doc.Worksheets.Entries.Single(e => e.Title.Text == "Songs") as WorksheetEntry;
            var cellQuery = new CellQuery(songsSheet.CellFeedLink);
            cellQuery.MaximumColumn = 1;
            cellQuery.MinimumRow = 2;
            var cellFeed = service.Query(cellQuery);

            foreach (CellEntry cell in cellFeed.Entries)
            {
                _allSongs.Add(cell.InputValue);
            }
        }

        private void AddSongList(SpreadsheetsService service, WorksheetEntry entry)
        {
            var date = DateTime.Parse(entry.Title.Text);
            var songList = new SongList(date);

            var cellQuery = new CellQuery(entry.CellFeedLink);
            cellQuery.MaximumColumn = 2;
            var cellFeed = service.Query(cellQuery);

            for (int i = 0; i < cellFeed.Entries.Count; i += 2)
            {
                var section = ((CellEntry)cellFeed.Entries[i]).InputValue;
                var title = ((CellEntry)cellFeed.Entries[i + 1]).InputValue;
                songList.Songs.Add(new Song(title, section));
            }

            _songLists.Add(songList);
        }
    }
}
