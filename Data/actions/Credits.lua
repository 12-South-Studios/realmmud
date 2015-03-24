-- File:    Credits.lua
-- Purpose: Display the credits for the mud server
-- Created: 02/01/07
-- By:      Gwareth
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();


local str = '////////////////////////////////////////////////////////////////////////////////\r\n' .. 
'//	Copyright &copy; 2012 Jason Murdick\r\n' .. 
'//\r\n' ..
'//  ' .. getGameTitle() .. ' is free software; you can redistribute it and/or modify\r\n\r\n' ..
'//  it under the terms of the GNU General Public License as published by\r\n' ..
'//  the Free Software Foundation; either version 2 of the License, or\r\n' ..
'//  (at your option) any later version.\r\n' ..
'//\r\n' ..
'//  ' .. getGameTitle() .. ' is distributed in the hope that it will be useful,\r\n' ..
'//  but WITHOUT ANY WARRANTY; without even the implied warranty of\r\n' ..
'//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the\r\n' ..
'//  GNU General Public License for more details.\r\n' ..
'//\r\n' ..  
'//  You should have received a copy of the GNU General Public License\r\n' ..
'//  along with ' .. getGameTitle() .. '; if not, write to the Free Software\r\n' ..
'//  Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA\r\n' ..
'//\r\n' ..  
'//  Original concept:  Joseph Sheppard\r\n' ..
'//  MUD Coding and Development:  Jason Murdick and Joseph Sheppard\r\n' ..
'//  System Design and Development:  Todd Lucas and Jason Murdick\r\n' ..
'////////////////////////////////////////////////////////////////////////////////';

 user = getCurrentUser();
 if user == nil then 
      errorLog('Credits.lua -> getCurrentUser returned nil');
      return
 end

 printString(CHAR, str, user, nil, nil, nil, nil);

-- EOF
