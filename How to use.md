## First Steps
After the installation process you can see the plugin in the addons folder on your project with the name towi_godot. Don´t forget to get active the plugin in Project Settings, in the Plugin tab.This folder contains 3 folders and a gd file: Assets, Editor and Runtime and towi.gd


## Main folders
### Assets
The Assets folder contains the UI material you can use like a grid with many button icons, the panel asset, a purple button asset, a star asset and the NunitoFont to create a standard with the text.

#### GRID
![grid](https://github.com/pixframeStudios/towi_godot/blob/main/towi_godot/Assets/UI/GridBotones.png)
#### Panel
![panel](https://github.com/pixframeStudios/towi_godot/blob/main/towi_godot/Assets/UI/Panel.png)
#### Star
![star](https://github.com/pixframeStudios/towi_godot/blob/main/towi_godot/Assets/UI/Star.png)

### Editor
The Editor folder contains 1 .gd script and an icon.
The script is GameUICreator and contains many functions to create the User Interface. It is designed to make the process easier to make a canva or configure the camera for a 2D game.

### Runtime
Runtime is the folder with more scripts to help in the development process. The folder contains 5 .gd scripts.
- The first one is GameResultPanel, it works to create a Result Panel when the player finishes a game. It contains one function called ShowCalification and extends from Towi Enums.
- The second script is Towi Enum. It contains two enums to get and set variables. The first enums corresponds to GamePhase, and the second one to GameResult
- The third script is TowiGameManger. Here you can set variables as GameName, rounds, score and many texts. The idea is that you create a unique GameManger that extends form TowiGameManger.
- The fourth script is TowiMath, only contains the GetResult function that helps to set a score for a game. It extends from TowiEnums
- The fifth script and last one script is TowiUtils, it extends from a Spatial Node and only contains de GetScreenSize function.

