extends Node

var instance

var gameName = "Name of the game in towi db";
var rounds = 3
var pointsPerRound = 1;
var score;
var historyIndex = 0;

var initialText 
var tutorialText;
var confrimationText;
var positiveRoundResultText;
var negativeRoundResultText;
var finalPositiveResultText;
var finaNegativelResultText;



# Called when the node enters the scene tree for the first time.
func _ready():
	Init() # Replace with function body.

func Init():
	if(instance == null):
		instance = self
	else:
		queue_free()

func OnDestroy():
	if(instance == self):
		instance = null
