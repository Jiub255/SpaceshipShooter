class AAAAAAAAAAA
{/*
	
	FIX:
	----

	Combine the select ship and select weapon screens eventually. Get them both working on their own first. 

	Issue with how coins are dropped. Causing lag with a mere 50. Clearly doing something very wrong. 

	Standardize sizes/positions/pivots for everything. Player ships, guns, weapon slot. Don't worry about enemies, they can be unique. 
		It'll make the menu way easier, plus it'll be less likely to break at different resolutions. 
	
		Ships fit into a 256x256 square. Pivot where you want its center to be in the menu. 
		Gun fit into a 32x64 rectangle. Pivot on the very bottom middle, where it will attach to the ship. 
			The weapon slot GOs on the Ship Menu Prefabs have a 100 x 200 size in the transform, and have an image component. 
		Weapon slot slightly bigger than gun. Pivot so it lines up with gun/ship. Near the bottom. 



	TODO:
	-----

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