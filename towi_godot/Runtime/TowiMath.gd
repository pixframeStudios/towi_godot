extends "res://addons/towi_godot/Runtime/TowiEnums.gd"

#/// <summary>
#/// This function is used to get the result of the game with the following grades
#/// Failed: not pass or under 8 out of 10 points
#/// Pass: just enough to pass 8 out of 10 points
#/// Good: 9 out fo 10 points
#/// Excellent: 10 out of 10 points
#/// </summary>
#/// <param name="rounds"></param>
#/// <param name="calificationPerRound"></param>
#/// <param name="calification"></param>
#/// <param name="passScore"></param>
#/// <param name="goodScore"></param>
#/// <param name="excellentScore"></param>
#/// <returns></returns>

func GetResult(rounds, calificationPerRound, calification, passScore = 0.8, goodScore = 0.9, excellentScore = 1):
	var totalPossibleeCalification = rounds * calificationPerRound
	var finalScore = calification / totalPossibleeCalification
	
	if(finalScore < passScore):
		return GameResult.Failed
	elif(finalScore >= passScore && finalScore < goodScore):
		return GameResult.Pass
	elif(finalScore >= goodScore && finalScore < excellentScore):
		return GameResult.Good
	else:
		return GameResult.Excellent
