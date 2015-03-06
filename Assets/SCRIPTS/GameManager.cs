//More info here rusticode.com/2014/01/21/creating-game-manager-using-singleton-pattern-and-monobehaviour-in-unity3d/
//This script is a state manager Singleton that uses events and delegates to broadcast.

using UnityEngine;
using System.Collections;
using System;//For saving
using System.Runtime.Serialization.Formatters.Binary;//For saving
using System.IO;//For saving

public delegate void OnStateChangeHandler();

public enum GameState
{
    NullState,
    Intro,
    Loading,
    MainMenu,
    Game
}

public class GameManager 
{
    public event OnStateChangeHandler OnStateChange;
    protected GameManager() { }
    private static GameManager _instance = null;
    public GameState gameState { get; private set; }

    //singleton pattern implementation
    public static GameManager Instance 
    {
        get 
        {
            if (GameManager._instance == null)
            {
               GameManager._instance = new GameManager();
            }
            return GameManager._instance;
        }
    }

    public void SetGameState(GameState gameState)
    {
        this.gameState = gameState;
        if (OnStateChange != null)
            OnStateChange();//triggering of the event
    }
}
