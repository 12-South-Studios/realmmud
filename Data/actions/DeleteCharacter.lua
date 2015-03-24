-- File:    DeleteCharacter.lua
-- Purpose: Deletes the requested character file and entry
-- Created: 02/01/07
-- By:      Gwareth
f = loadfile(getDataPath() .. "modules/base.lua")()


function main()

	local user = getCurrentUser()
	if user == nil then
		ErrorLog("DeleteCharacter.lua:main -> getCurrentUser returned a nil value")
		return
	end
	
	local str = getProperty(user, "raw command")
	if str == nil then
		ErrorLog("DeleteCharacter.lua:main -> getProperty('raw command') returned a nil value")
		return
	end
	
	local verb = parseWord(str, 0)
	if verb == nil then
		ErrorLog("DeleteCharacter.lua:main -> parseWord('verb') returned a nil value")
		return
	end
	
	local charName = getProperty(user, "current character")
	if charName == nil then
		ErrorLog("DeleteCharacter.lua:main -> getProperty(current character) returned a nil value")
		return
	end
	
	local charPath = getDataPath() .. "characters/" .. cname .. ".lua"
	if Exists(charPath) == false then
		printString(SEND_TO_CHAR, "Unable to locate a character file with that name.", user)
	else
		setProperty(user, "current character", "nil") 
		
		-- remove the character file
		if os.remove(charPath) == nil then
			ErrorLog("DeleteCharacter.lua:main -> os.remove was unable to remove character file '" .. charPath .. "'.")
			return
		end
		
		removeNameFromCharList(user, charName)
		updateUserAccount(user)
	end
	
	setUserState(user, US_ACCOUNT_MENU)
	local path = getDataPath() .. "Menus/AccountMenu.lua"
	executeScript(path, true)	
end

-- EOF
