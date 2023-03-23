class AAAAAAAAAAA
{/*
	
	FIX:
	----

	When first getting to Outfit ship menu, the display on the right shows the default weapon even if the current ships
		first weapon isn't set to that. 

	Make stuff happen on player death. 
		Have death animations/sounds. 
		Other stuff?

	Make all input work on menus (like WASD or arrow keys, using InputActions, not just mouse click events). 
		Move, select, cancel? 

	Fine tune item magnet.

	Fill out/redesign HUD. 
		Add HP bar. 
		Coins.
		Whatever powerup items you have available.
		Icons for current buffs/debuffs. 

	Make UI look good/unique. Functionality is there, now make it look good. 
		Combine the select ship and select weapon screens eventually? Or not. Get them both working on their own first. 	

	Make a variety of different ships/weapons/enemies. 
		Standardize sizes/positions/pivots for everything. Player ships, guns, weapon slot. Don't worry about enemies, they can be unique. 
		It'll make the menu way easier, plus it'll be less likely to break at different resolutions. 
			Ships fit into a 256x256 square. Pivot where you want its center to be in the menu. 
			Gun fit into a 32x64 rectangle. Pivot on the very bottom middle, where it will attach to the ship. 
				The weapon slot GOs on the Ship Menu Prefabs have a 100 x 200 size in the transform, and have an image component. 
			Weapon slot slightly bigger than gun. Pivot so it lines up with gun/ship. Near the bottom. 

	Make some unique "powerup" items. Bombs, invincibility, recover HP, etc. 

	SFX/Music!
		Ambient scifi nerd music or rock battle music? Maybe the first for levels and the second for bosses. 

	JUICE!!!
		Particle effects for everything, screen shake when hit/shooting/enemy explodes, SFX for everything, menu animations, popup texts, etc. 
		When collecting a bunch of coins, have them each make a quiet satisfying pop sound,
			but have the frequency (both pitch and how often the sound gets played per second) increase until done collecting that batch. 




	TODO:
	-----

	Since this is made for PC (for now), ie landscape view, make the camera far away so you can see a lot.

	Have the camera take a randomly curving path (which generally tends upward) instead of just going straight up? 

	Use pretty gems instead of coins for currency. Big fancy ones could be worth more than plain little ones. Kinda like the zelda rupee thing.

	Maybe do different theme? Underwater, airplanes, spaceships, alien monsters, fantasy stuff?

	Make different types of projectiles. Like bow shaped "wave" ones, and different bullets, and lasers and bombs, and little drone things, all sorts of stuff. 

	Make prefabs of arrangements of enemies. Like a diagonal line of enemies. Then spawn those randomly instead of random single units. 
		It'll make it look better, and give better control over gameplay/difficulty. 

	Get rid of the choose ship canvas entirely? Just replace the "Done Shopping" button in the ShopUI scripts to be a "Select Ship" button.
		Then whichever ship is currently selected will be your ship. 

	Break up each "piece" of UI into its own class? And make prefabs that have that class and instantiate them with a UI manager?
		The UI manager could pass whatever data is needed into the constructors. 

	Prototype full level.
		Timer? Certain number of enemies? 
		End level UI/screen.

	Shop 
		Comes up after beating a level. 
		Can buy new ships/weapons/items with money from levels. 
		Have separate inventories for ships, weapons, and items. 

	Prepare for level 
		Comes up after done shopping. 
		Choose which ship to use.
		Choose which guns to put on it. 
		Deal with items later, not sure how/if it will be implemented. 
		Once ready, start next level. 

	Keep track of all the stats.
		Kills (of each enemy type and totals)
		Time played
		Money earned
		Money spent
		Percent complete
		Bullets fired
		Everything

	JUICE!
		SFX/Music
		Screen shake?
			At least shake the sprite that got hit.
		Particle effects, for getting hit and for dying. 
		Shake player ship when shooting, like recoil? 
		Definitely screen shake when colliding with other enemies. 

	Save System
		Save level index, ships owned, coins, weapons owned, which weapons are on which ships, etc. 
		Gameplay statistics, time played, kills, bullets shot, every stupid little stat. 

	Maybe add in a "shields" system later? Want to keep it simple though. 

----------------------------------------------------------------------------

	Top view spaceship shooter. 
	Background and enemies move down past you to make it seem like you're moving. 
	Able to upgrade/buy new ships/weapons/usable items, using money you collect from each round. 
	Each level has either a timer or a certain number of enemies, then a boss fight.
		Boss floats along with you, unlike enemies who will fly past. 
		Maybe have mini-bosses in the middle of the levels? 

	Gameplay Loop
		Play through level, kill enemies, collect money/items, kill boss.
		Shop for new ships/weapons/items.
		Choose ship/weapons/items for next run.
		Repeat. 






















*/}