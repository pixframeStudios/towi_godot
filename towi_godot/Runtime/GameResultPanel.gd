extends "res://addons/towi_godot/Runtime/TowiEnums.gd"

var text
var calificationImages = []
var okButton
var offColor
var onColor

var m_offColor = Color(0.2,0.2,0.2,0.8)
var m_onColor = Color.yellow

func ShowCalification(result):
	if(calificationImages.len() < GameResult.Excellent):
		push_error("You need at least 3 images to represent the califiction")
		return
		
	for i in GameResult.Excellent:
		if(i < result):
			calificationImages[i].color = Color.white
			continue
		calificationImages[i].color = offColor
		
