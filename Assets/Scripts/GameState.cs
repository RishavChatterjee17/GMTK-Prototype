using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameState", menuName = "State/GameState", order = 0)]
public class GameState : ScriptableObject 
{    
    [TextArea(14,10)] [SerializeField] string emailText;
    [SerializeField] GameState[] nextStates;

    public string GetStateText()
    {
        return emailText;
    }

    public GameState[] GetNextStates()
    {
        return nextStates;
    }
}
