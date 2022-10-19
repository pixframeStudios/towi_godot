extends Node

var instance

#Header
var gameName = "Name of the game in towi db";
var rounds = 3
var pointsPerRound = 1;
var score;
var historyIndex = 0;

##
var initialText
var tutorialText;
var confirmationText;
var positiveRoundResultText;
var negativeRoundResultText;
var finalPositiveResultText;
var finaNegativelResultText;
var bonusText;



# Called when the node enters the scene tree for the first time.
func _ready():
	Init() # Replace with function body.

func ShowInitialText():
	pass

##HELPERS
func SceneInitialization():
	#Useful for change StartMenu to InitialText
	pass
func GameInitialization():
	#Useful for change from InitialText to tutorial text
	pass
func ExplaiGame():
	#Useful for showing the tutorial text and images
	pass
func SetGameObjectives():
	#Useful for setting up the rounds, objectives and bonus
	pass
func BeginGame():
	#Useful for setting up the things that will appear on the game scene, and amking the game loop
	pass
func ShowResult():
	#Useful for check and verify the score, the actualRound, the levels and showing it on the next screen
	pass
##END HELPERS


func Init():
	if(instance == null):
		instance = self
	else:
		queue_free()

func OnDestroy():
	if(instance == self):
		instance = null
		
