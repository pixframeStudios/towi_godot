extends EditorPlugin

const ASSETS_PATH = "Packages/com.pixframe-studios.towi-plugin/Assets";

func GetOrCreateCanvas():
	var canvasObject
	var canva = get_node("canvaObject")
	if(!canva):
		canvasObject = Node.new()
	return canvasObject
	
func GetUIButtonSprites():
	var objects
	var spriteDiccionary
	
	return spriteDiccionary
	
#regions Anchores

#export var box_size = Vector2(200,200) setget set_boxsize, boxsize
#func SetAnchoredPos(node):
#	return SetAnchoredPos(node, Vector2(0.5,1), Vector2(0.5,1))

#func SetAnchoredPos(node, anchoredPos):
#	return SetAnchoredPos(node, Vector2(0.5,1,), Vector2(0.5,1), anchoredPos)


#func SetAnchoredPos(node, Vector2 minAnchor, Vector2 maxAnchor):
#{
#	return SetAnchoredPos(gameObject, minAnchor, maxAnchor, Vector2.ZERO);
#}
#
func SetAnchoredPos(node, minAnchor, maxAnchor, anchoredPos):
	var rect = node
	rect.anchorMin = minAnchor
	rect.anchorMax = maxAnchor
	rect.anchoredPosition = anchoredPos
	return rect



#endregion

#func CreateTowiPanel(canvas):
#	return CreateTowiPanel(canvas, Vector2(400, 200))

func CreateTowiPanel(node, panelSize):
	var gameObject = Image.new()
	gameObject.get_parent().add_child(node)
	var panelImage = ImageTexture.new()
	#var rect = SetAnchoredPos(node, 0, panelSize/2)
	var panelAsset = load("res://addons/towi_godot/Assets/UI/Panel.png")
	panelImage.texture = panelAsset
	return gameObject
	
func CreateStar(parent, number, starSize, starPos):
	var starAsset = load("res://addons/towi_godot/Assets/UI/Star.png")
	var centerAnchor = 1*0.5
	var butonCreatedButton = CreateButton($"Star {number + 1}", parent, centerAnchor, centerAnchor, starPos, starAsset, starSize)
	
#func CreateText()
#	return	
	
func CreateButton( buttonName,  parent,  minAnchor,  maxAnchor, anchoredPos, sprite, buttonSize):
	var newButton = Button.new()
	newButton.text = buttonName
	var newButtonRect = SetAnchoredPos(newButton, minAnchor, maxAnchor, anchoredPos)
	var newButtonImage = newButton.icon
	newButtonImage = sprite
	return newButton

func CreateResultPanel():
	var canvas = GetOrCreateCanvas()
	var uiSprites = GetUIButtonSprites()
	
	var panelSize = Vector2(400, 200)
	var textRectSize = Vector2((-panelSize.y * 0.25), (panelSize.y/2)-((panelSize.y/2)*0.1))
	var buttonSize = Vector2(32,32)
	var starSize = Vector2(48,48)
	
	var panel = CreateTowiPanel(canvas, panelSize)
#	var gameResult = Add script GameResultPanel
	var gameResultTextPos = Vector2(0, -(textRectSize.y/2)-(panelSize.y/2)*0.15)
#	gameRestul.text
	
	
