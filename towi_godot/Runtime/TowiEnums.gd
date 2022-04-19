extends Node

enum GamePhase{ Initialization, Tutorial, Confirmation, Game, RoundResult, Result, Evaluation}

#/// <summary>
#/// Game result will be used to determine if the player got enough knowledge to pass or not the level
#/// Recomendation
#/// Failed: under 8 out of 10 points
#/// Pass: 8 out of 10 points
#/// Good: 9 out fo 10 points
#/// Excellent: 10 out of 10 points
#/// </summary>

enum GameResult { Failed, Pass, Good, Excellent }
