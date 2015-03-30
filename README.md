# realmmud
Automatically exported from code.google.com/p/realmmud

RealmMUD is an original MUD (Multi-User Dimension or Dungeon) project that has evolved since 2001.  It began as a simple MUD written in C called TMUD (originally written by Zanth), ported to c++ in 2004 and then rewritten from the ground up in C# from 2008 onwards.

RealmMUD is split into two major components (at this time):
 * RealmServer
 * RealmEditor

However, the repository contains five distinct Visual Studio solutions:
 * RealmMUD - The main server component of the MUD.
 * Realm.Edit - The primary tool for editing/creating content for the MUD.
 * Realm.Library - A large set of common libraries containing common data structures and functions.
 * Realm.Database - A SQL Server project that defines the MUD's database schema.
 * Realm.Build.Tool - A tool that exports constant data from the database to a Globals file.
 
Licensing:
RealmMUD is licensed under the GNU General Public License v3.0 (http://opensource.org/licenses/GPL-3.0) and as such no warranties exist from use of this software and all changes and moficiations down-stream must use this licensing agreement. 
