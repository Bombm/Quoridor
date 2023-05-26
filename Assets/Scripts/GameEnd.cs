using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    public static string WinnerName;

    [SerializeField] private SceneLoader _sceneLoader;

    public void EndGame(string playerName)
    {
        WinnerName = playerName;

        _sceneLoader.Load("EndScene");
    }
}
