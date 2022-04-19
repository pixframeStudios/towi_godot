extends Spatial
#
#/// <summary>
#/// This util will return the screen size of the current device in unity units
#/// x is the width of the device
#/// y is the height of the device
#/// </summary>
#/// <returns></returns>

func GetScreenSize():
	var camera = Camera2D.new()
	var cameraSize = OS.get_screen_size()
	if(camera==null):
		push_warning("You need a cemera to perform this action")
		return Vector2.ZERO
	
	return cameraSize
