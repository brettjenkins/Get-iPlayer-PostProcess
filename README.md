Get-iPlayer-PostProcess
=======================

This is a .NET 4 application that watches a folder where the output of Get iPlayer goes and tidies up the file before moving to a Plex watched folder.

The following things are done to a file:

All underscores are removed and replaced with spaces
If it's a datebased programme (e.g. news) it removes the season and series from the filename, and from the file metadata so Plex doesn't try putting it as season 1 episode 1. Also renames season folder to represent the year.

If it's a normal tv show, it will largely leave it alone, other than move it to the plex folder.

At the end, the programme can refresh the Plex library.

Notes
========================

This was written mostly for my own use, therefore the code isn't the most elegant, it's just something i've put together to fulfil a need. Error handling isn't particularly good either. However, I thought I'd put it on here and release under the GNU as someone else may find it useful, and may want to improve upon it. Be my guest!
