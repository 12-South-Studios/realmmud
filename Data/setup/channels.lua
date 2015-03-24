-- CHANNELS.LUA
-- This is the channels data file
-- Revised: 2009.12.14
-- Author: Jason Murdick
f = loadfile(GetAppSetting("dataPath") .. "\\modules\\module_base.lua")();


systemLog("=================== REALMMUD SETUP - CHANNELS ===================");
newchannel = createChannel(1, "error", ChannelType.System, false, true, false, "");
if (newchannel == nil) then
	errorLog("Unable to create 'error' channel");
end

newchannel = createChannel(2, "debug", ChannelType.System, false, true, false, "");
if (newchannel == nil) then
	errorLog("Unable to create 'debug' channel");
end

newchannel = createChannel(3, "wizard", ChannelType.System, true, true, false, "");
if (newchannel == nil) then
	errorLog("Unable to create 'wizard' channel");
else
	channel.this = newchannel;
	channel.this:AddRestriction("W");
	channel.this:AddRestriction("A");
end

newchannel = createChannel(4, "builder", ChannelType.System, true, true, false, "");
if (newchannel == nil) then
	errorLog("Unable to create 'builder' channel");
else
	channel.this = newchannel;
	channel.this:AddRestriction("B");
end

newchannel = createChannel(5, "general", ChannelType.System, true, true, false, "");
if (newchannel == nil) then
	errorLog("Unable to create 'general' channel");
else
	channel.this = newchannel;
	channel.this:AddRestriction("P");
end


newchannel = createChannel(6, "marketplace", ChannelType.System, true, true, false, "");
if (newchannel == nil) then
	errorLog("Unable to create 'marketplace' channel");
else
	channel.this = newchannel;
	channel.this:AddRestriction("P");
end


newchannel = createChannel(7, "ooc", ChannelType.User, true, true, false, "");
if (newchannel == nil) then
	errorLog("Unable to create 'ooc' channel");
else
	channel.this = newchannel;
	channel.this:AddRestriction("P");
end

-- EOF