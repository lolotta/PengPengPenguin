using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private float _speed = 7f;

    [SerializeField] private SpawnManagerScript _spawnManager;
    [SerializeField] private GameObject _vaccineManager;
    [SerializeField] private GameObject _levelUpManager;
    [SerializeField] private GameObject _powerUpManager;


    

    [SerializeField] private int _lives = 3;
    
    //private float _colorChannel = 1f;
    //private MaterialPropertyBlock _abp;

    
    void Start()
    {
        /*if (_abp == null)
        {
            _abp = new MaterialPropertyBlock();
            _abp.Clear();
            this.GetComponent<Renderer>().GetPropertyBlock(_abp);
        }*/
        transform.position = new Vector3(0, 0, 0);

    }

    void Update()
    {
       PlayerMovement();
    }

    public void Heal()
    {
        _lives++;
    }

    public void PowerUp()
    {
        _vaccineManager.GetComponent<VaccineManagerScript>().PowerUp();
    }
    public void Damage()
    {
        _lives--;

        /*_colorChannel -= 0.5f;
        _abp.SetColor("_Color", new Color(_colorChannel, 0, _colorChannel, 1f));
        this.GetComponent<Renderer>().SetPropertyBlock(_abp);*/
        
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
        else if (transform.position.y < -3.5f)
        {
            transform.position = new Vector3(transform.position.x,
                -3.5f,
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
