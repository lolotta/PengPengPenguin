using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _gameSettings;
    
    
    public void StartGame()
    {
        SceneManager.LoadSceneAsync("Prototype", LoadSceneMode.Additive);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    
}
