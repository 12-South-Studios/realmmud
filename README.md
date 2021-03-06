RealmMUD - A multi-user dungeon application

Copyright (C) 2001 - 2015 Jason Murdick/Joseph Sheppard

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details. 

You should have received a copy of the GNU General Public License along with this program.  If not, see www.gnu.org/licenses.
-----------------------------------------------------------------------------------------------------------------------------

RealmMUD is an original MUD (Multi-User Dimension or Dungeon) project that has evolved since 2001.  It began as a simple MUD written in C called TMUD (originally written by Zanth), ported to c++ in 2004 and then rewritten from the ground up in C# from 2008 onwards.

RealmMUD is split into two major components (at this time):
 * RealmServer
 * RealmEditor

However, the repository contains five distinct Visual Studio solutions:
 * RealmMUD - The main server component of the MUD.
 * Realm.Edit - The primary tool for editing/creating content for the MUD.
 * Realm.Library - A large set of common libraries containing common data structures and functions.
 * Realm.Database - A solution that defines the database entities (using Code-First Entity Framework) and also functions to deploy schema migrations to the three databases used by the MUD (Realm, RealmAdmin, and RealmLive).
 * Realm.Build.Tool - A tool that exports constant data from the database to a Globals file.

RealmMUD utilizes numerous third-party libraries including:
 * Ninject - https://github.com/ninject/ninject/blob/master/LICENSE.txt
 * NCalc - https://ncalc.codeplex.com/license
 * Log4Net - http://logging.apache.org/log4net/license.html
 * Lua - http://www.lua.org/license.html
 * MOQ - https://code.google.com/p/moq/source/browse/trunk/License.txt
 * NUnit - http://nunit.org/index.php?p=license&r=2.6.2
 * LuaInterface - https://code.google.com/p/luainterface/ 

Relevant License files are also included in the main repository folder.

Obsolete Folders/Files - Because of the long-term nature of this project and the fact that its grown and evolved so much over the years (C, C++, C#, flat-files, Lua, database, etc) there are numerous legacy files remaining in the structure.  For example, nearly every file in the /Data/ folder is obsolete but has been left in place for reference.  

Documentation Files - Some files within the /Documentation/ folder are also obsolete, from a day before the project was under source control.  Other files, such as the Startup Process, Code Concepts, and Combat Calculations are there for reference and may not be relevant to any future projects.
