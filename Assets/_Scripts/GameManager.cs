using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager
{
    public enum GameState {MENU, GAME, PAUSE, ENDGAME};

    public GameState gameState {get; private set;}
    public int vidas;
    public int pontos;
    public int highscore;
    public bool newGame = false;

    private static GameManager _instance;

    public static GameManager GetInstance()
    {
        if(_instance == null)
        {
            _instance = new GameManager();
        }

        return _instance;
    }

    private GameManager()
    {
        vidas = 3;
        pontos = 0;
        gameState = GameState.MENU;
        highscore = LoadHighscore();
    }

    public delegate void ChangeStateDelegate();
    public static ChangeStateDelegate changeStateDelegate;

    public void ChangeState(GameState nextState)
    {
        // if(nextState == GameState.GAME) Reset();
        gameState = nextState;
        changeStateDelegate();  
    }

    public void Reset()
    {
        SaveHighscore();
        vidas = 3;
        pontos = 0;
        newGame = true;
    }

    public void SaveHighscore()
    {
        if(pontos > highscore) highscore = pontos;
        File.WriteAllText(Application.dataPath +"/highscore.txt",highscore.ToString());
    }

    public int LoadHighscore()
    {
        var highscoreString = File.ReadAllText(Application.dataPath +"/highscore.txt");
        highscore = int.Parse(highscoreString);
        return highscore;

    }


}
