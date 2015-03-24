-- ONCLIENTENTER.LUA
-- Main menu screen when a client first connects
-- Revised: 2009.09.24
-- Author: Jason Murdick
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();


local str = MxpTag("GameTitle") .. "W E L C O M E   T O   T H E   S E V E N   R E A L M S" .. MxpTag("/GameTitle") .. "\r\n\r\n" .. 
    "*=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=*\r\n" .. 
    "| Code:    " .. getGameTitle() .. ", revised 2012.09.10\r\n" ..
    "| Telnet:  " .. MxpTag("I") .. "www.sevenrealms.net 9001" .. MxpTag("/I") .. "\r\n" ..
    "|\r\n" ..
    "| Implementors: " .. MxpTag("C cyan") .. "Gwareth (gwareth@sevenrealms.net)" .. MxpTag("/C") .. "\r\n" ..
    "|               " .. MxpTag("C cyan") .. "Zanth (zanth@sevenrealms.net)" .. MxpTag("/C") .. "\r\n" ..
    "|\r\n" ..
    "*=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=*\r\n" ..
    " Use " .. MxpTag("MenuCmd1") .. "NEWACCOUNT (Name)" .. MxpTag("/MenuCmd1") .. " to create a new game account.\r\n" ..
    " Use " .. MxpTag("MenuCmd1") .. "CONNECT (Name)" .. MxpTag("/MenuCmd1") .. " to connect to your existing game account.\r\n" ..
    " Use " .. MxpTag("MenuCmd2") .. MxpTag("send") .. "WHO" .. MxpTag("/send") .. MxpTag("/MenuCmd2") .. " to find out who is currently online.\r\n" ..
    " Use " .. MxpTag("MenuCmd2") .. MxpTag("send") .. "CREDITS" ..  MxpTag("/send") .. MxpTag("/MenuCmd2") .. " to find out more about the mud.\r\n" ..
    " Use " .. MxpTag("MenuCmd3") .. MxpTag("send") .. "QUIT" .. MxpTag("/send") .. MxpTag("/MenuCmd3") .. " to logout.\r\n" ..
    "*---------------------------------------------------------------------------*\r\n"

user = getLastConnected();
if user == nil then 
     errorLog('OnClientEnter.lua -> getlastConnected returned nil');
     return
end

printString(MessageScope.Character, str, user, nil, nil, nil, nil);

-- EOF