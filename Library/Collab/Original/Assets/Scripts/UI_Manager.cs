using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 



public class UI_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    private int _score = 0;
    private int _life = 3;
    private bool _playerAlive = true;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _lifeText; 
    [SerializeField] private Text _finalScore;
    [SerializeField] private Text _gameOver;
    [SerializeField] private GameObject _gameSettings;

    public void AddScore(int score)
    {
        _score += score; 
        _scoreText.text = "Score: " + _score; 
        _finalScore.text = "Your Score: " + _score;

    }

    public void LostLife(int damage)
    {
        _life -= damage; 
        _lifeText.text = "Health: " + _life; 
        
    }

    public void AddLife(int power)
    {
        _life += power;
        _lifeText.text = "Health: " + _life; 
        
    }

    public int GetScore()
    {
        return _score;
    }

    public void PlayerDies()
    {
        _playerAlive = false;
    }
    void Start()
    {
        
        _scoreText.text = "Score: " + _score;
        _lifeText.text = "Health: " + _life;
        _finalScore.text = "Your Score: " + _score;
    }

    private void Update()
    {
        if (!_playerAlive)
        {
            _scoreText.transform.Translate(Vector3.up * 100);            
            _lifeText.transform.Translate(Vector3.up * 100);   
            _finalScore.transform.position =  new Vector3(_finalScore.transform.position.x, 100f, _finalScore.transform.position.z);
            _gameOver.transform.position = new Vector3(_gameOver.transform.position.x, 0f, _gameOver.transform.position.z);
            
            if (Input.GetKey(KeyCode.Space))
            {
                _gameSettings = GameObject.FindWithTag("gameSettings");
                if (_gameSettings != null)
                {
                    Destroy(_gameSettings.gameObject);
                }
                
                
                SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Single); 
            }
        }
    }
    
}
