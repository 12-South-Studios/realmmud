-- BAROCH/CONVERSATIONS.LUA
-- This is the conversations-file for the Vale of Baroch
-- Revised: 2009.09.27
-- Author: Jason Murdick
f = loadfile(getDataPath() .. "\\types.lua")();


-- First, make sure I have the zone
zone.this = getEntityByID(2);
if (zone.this == nil) then
	ErrorLog("baroch\\shops.lua was unable to retrieve a zone object");
	return
end


SystemLog("=================== ZONE 'BAROCH' - CONVERSATIONS ===================");

newChat = createConversation(26001, "General Guard Greeting");
chat.this = newChat;
chat.this:AddNode(1, 0, "hello", "Greetings!", 0);

mob = getEntityByID(22001);
mob:AddChatTree(chat.this);


-- EOF