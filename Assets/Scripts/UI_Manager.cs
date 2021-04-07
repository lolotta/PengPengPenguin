using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 



public class UI_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    private int _score = 0;
    private int _life = 3; 
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _lifeText; 

    public void AddScore(int score)
    {
        _score += score; 
        _scoreText.text = "Score: " + _score; 
    }

    public void LostLife(int damage)
    {
        _life -= damage; 
        _lifeText.text = "Health: " + _life; 
        
    }

    void Start()
    {
        _scoreText.text = "Score: " + _score;
        _lifeText.text = "Health: " + _life; 
    }
    
}
