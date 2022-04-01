using Godot;
using System;

public class TowiGameManagerEditor : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

    protected bool showGameInfo = false;
    public override void OnInspectorGUI()
    {
        TowiGameManager towiGameManager = (TowiGameManager)target;

        showGameInfo = EditorGUILayout.Foldout(showGameInfo, "GameSettings");
        if (showGameInfo) 
        {
            towiGameManager.gameName = EditorGUILayout.TextField("Game Name", towiGameManager.gameName);
            towiGameManager.rounds = EditorGUILayout.IntField("Number of game rounds", towiGameManager.rounds);
            towiGameManager.pointsPerRound = EditorGUILayout.IntField("Points per round", towiGameManager.pointsPerRound);
        }
    }
}
