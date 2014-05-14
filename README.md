# Song History

A application that connects to a Google Spreadsheet, and extracts song history data in order to provide the user which songs have been sung less frequently and when they were last sung. The input spreadsheet is assumed to have the following structure:

- A worksheet called "Songs" exists and is the complete list of songs that will presented to the user.
- A worksheet called "Selected" exists and has three columns: (A) date when the song was sung, (B) song position in program, (C) the song name.
- The "Selected" worksheet can have songs other than those in the master "Songs" list. They just won't be displayed in the results.

The default Google account email and password, and spreadsheet name can be configured in the application config.
