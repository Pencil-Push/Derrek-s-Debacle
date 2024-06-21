using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayTheGame : MonoBehaviour
{
    public void PlayingGame()
    {
        SceneManager.LoadSceneAsync(2);
    }
}
