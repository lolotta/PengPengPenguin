using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float _speed = 7f;

    [SerializeField] private SpawnManagerScript _spawnManager;
    [SerializeField] private GameObject _vaccineManager;
    [SerializeField] private GameObject _levelUpManager;
    [SerializeField] private GameObject _powerUpManager;
    [SerializeField] private GameObject _backgroundManager;
    [SerializeField] private GameObject _gameSettings;


    
    [SerializeField] private GameObject _penguin;
    [SerializeField] private GameObject _sheep;
    [SerializeField] private GameObject _cow;
    
    private bool _penguinMode = false;
    private bool _mountainMode = false;
    private bool _forestMode = false;

    
    
    [SerializeField] public int _lives = 3;
    
    [SerializeField] private UI_Manager _uiManager;

    void Start()
    {
        
        transform.position = new Vector3(0, 0, 0);
        _gameSettings = GameObject.FindWithTag("gameSettings");
        if (_gameSettings.GetComponent<GameSettingsScript>().PenguinON())
        {
            _penguinMode = true;
            Instantiate(_penguin, transform.position, transform.rotation * Quaternion.Euler (0f, 180f, 0f), this.transform);

        } else if (_gameSettings.GetComponent<GameSettingsScript>().MountainOn())
        {
            _mountainMode = true;
            Instantiate(_sheep, transform.position, transform.rotation * Quaternion.Euler (0f, 180f, 0f), this.transform);

        } else if (_gameSettings.GetComponent<GameSettingsScript>().ForestOn())
        {
            _forestMode = true;
            Instantiate(_cow, transform.position, transform.rotation * Quaternion.Euler (0f, 180f, 0f), this.transform);

        }
        
    }

    void Update()
    {
        PlayerMovement();
        if (_uiManager.GetScore() == 10)
        {
            SoundManagerScript.PlaySound("nextLevel");
            SunsetLevel();
        }
        if (_uiManager.GetScore() == 110)
        {
            SoundManagerScript.PlaySound("nextLevel");

            NightLevel();
        }
    }

    public void SunsetLevel()
    {
        _backgroundManager.GetComponent<BackgroundManagerScript>().Sunset();
        _spawnManager.SunsetLevel();
        ScoreCount(90);
        
    }
    
    public void NightLevel()
    {
        _backgroundManager.GetComponent<BackgroundManagerScript>().Night();
        _spawnManager.NightLevel();
        ScoreCount(90);
        
    }
    // adds a live and updates the UI
    public void Heal()
    {
        _lives++;
        _uiManager.AddLife(power: 1);
    }

    public void PowerUp()
    {
        _vaccineManager.GetComponent<VaccineManagerScript>().PowerUp();
    }

    // ScoreCount is called in Corona and adds our scores
    public void ScoreCount(int score)
    {
        _uiManager.AddScore(score);
    }

    //health count is called in corona and distracts life
    public void HealthCount(int damage)
    {
        _uiManager.LostLife(damage);
    }

    //returns the current number of lives
    public int Lives()
    {
        return _lives;
    }

    public void Damage()
    {
        _lives--;
        
        if (_lives <= 0)
        {
            if (_spawnManager != null)
            {
                _spawnManager.onPlayerDeath();
            }
            else
            {
                Debug.LogError("Spawn manager not assigned, idiot");
            }

            if (_vaccineManager != null)
            {
                _vaccineManager.GetComponent<VaccineManagerScript>().DestroyVaccines();
            }
            else
            {
                Debug.LogError("vaccine manager not assigned, idiot");
            }

            if (_levelUpManager != null)
            {
                _levelUpManager.GetComponent<LevelUpManagerScript>().onPlayerDeath();
            }
            else
            {
                Debug.LogError("level up manager not assigned, idiot");
            }

            if (_powerUpManager != null)
            {
                _powerUpManager.GetComponent<PowerUpManagerScript>().onPlayerDeath();
            }
            else
            {
                Debug.LogError("level up manager not assigned, idiot");
            }
            if (_uiManager != null)
            {
                _uiManager.GetComponent<UI_Manager>().PlayerDies();
            }
            else
            {
                Debug.LogError("ui manager not assigned, idiot");
            }

            SoundManagerScript.PlaySound("die");

            Destroy(this.gameObject);
        }
    }


    void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 playerTranslate = new Vector3(
            horizontalInput * _speed * Time.deltaTime,
            verticalInput * _speed * Time.deltaTime,
            0);
        transform.Translate(playerTranslate);

        if (transform.position.y > 5f)
        {
            transform.position = new Vector3(transform.position.x,
                5f,
                0);
        }
        else if (transform.position.y < -4f)
        {
            transform.position = new Vector3(transform.position.x,
                -4f,
                0);
        }

        if (transform.position.x > 11.4f)
        {
            transform.position = new Vector3(-11.4f,
                transform.position.y,
                0);
        }
        else if (transform.position.x < -11.4f)
        {
            transform.position = new Vector3(11.4f,
                transform.position.y,
                0);
        }
    }
}