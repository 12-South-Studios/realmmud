-- BAROCH/CONVERSATIONS.LUA
-- This is the conversations-file for the Vale of Baroch
-- Revised: 2009.09.27
-- Author: Jason Murdick
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();


-- First, make sure I have the zone
zone.this = getEntityByID(2);
if (zone.this == nil) then
	errorLog("baroch\\conversations.lua was unable to retrieve a zone object");
	return
end


systemLog("=================== ZONE 'BAROCH' - CONVERSATIONS ===================");

newChat = createConversation(21250, "General Guard Greeting");
chat.this = newChat;
chat.this:AddNode(createChatNode(1, 0, "hello", "Greetings!", 0));


-- EOF