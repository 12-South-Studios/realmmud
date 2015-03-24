-- VOID/CONVERSATIONS.LUA
-- This is the conversations-file for the Void
-- Revised: 2012.02.22
-- Author: Jason Murdick
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();


-- First, make sure I have the zone
zone.this = getEntityByID(1);
if (zone.this == nil) then
	errorLog("void\\conversations.lua was unable to retrieve a zone object");
	return
end


systemLog("=================== ZONE 'VOID' - CONVERSATIONS ===================");

newChat = createConversation(5200, "General Greeting");
chat.this = newChat;
chat.this:AddNode(1, 0, "hello", "Greetings!", 0);


-- EOF