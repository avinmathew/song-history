# Song History

A application that connects to a Google Spreadsheet, and aggregates song history data from multiple worksheets. The result is that each song is associated with the date when the song was last selected and the number of times it has been selected. The input spreadsheet is assumed to have the following structure:

- A worksheet called "Songs" exists and is the complete list of songs that will presented to the user.
- Assumes each worksheet is assigned a name that is a parseable date (e.g. 2013 January 1).
- A worksheet has three columns: (A) song position in program, (B) the song name, (C) the song number. Only (B) is currently parsed from a worksheet and is mandatory if data in column A is present.
- A worksheet can have songs other than those in the master "Songs" list. They just won't be displayed in the results.

The default Google account email and password, and spreadsheet name is configuration in the application config.
