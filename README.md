# Space Invader Samples

[Wikipedia article](https://en.wikipedia.org/wiki/Space_Invaders)

This project is an attempt to make a sample Space Invader game in less than 24 hours. Some gameplay elements are intentionally differs from the source material.

## Gameplay

Use `left` and `right` cursor to move the spaceship and press/hold `space` to fire.

Enemies move in group in a zig zag pattern and will move faster the more they are destroyed.

The game is cleared when enemies reach the bottom of the screen, or the player destroys all of the enemies.

## Technical features

The game uses scriptable objects to manage different kind of gameplay elements.

+ DataShipDisplay is used to manage the appearance of the Space ship. When the game is started it will select one random skin to apply to the Space ship.
+ DataBullet is used to manage different kind of bullet. When the player fires, there is a 15% chance of firing a critical shot that moves faster and deal more damage.
+ DataEnemy is used to manage the enemy hp, score, name and appearance. Random enemies are selected and allocated into the level.

To modify and update the list of data, select `Assets/SpaceInvaderTest/Prefabs/Model`, open `ModelData` context menu: `Collect all data` and save the change.

## Note on localization

Localization is done using Unity's built in Localization package. 2 languages are supported which are English and Vietnamese.

Live update in-game on locale change is supported. But due to some dynamic text template it is much more preferred to only allow changing locale on main menu.

## Demo link

[itch.io](https://inducpham.itch.io/space-invader-test)
