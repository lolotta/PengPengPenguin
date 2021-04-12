using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManagerScript : MonoBehaviour
{
    [SerializeField] 
    private GameObject _bgPrefab;
    
    [SerializeField] 
    private GameObject _sunsetPrefab;
    
    [SerializeField] 
    private GameObject _nightPrefab;
    
    [SerializeField] 
    private GameObject _bgMountainPrefab;
    
    [SerializeField] 
    private GameObject _sunsetMountainPrefab;
    
    [SerializeField] 
    private GameObject _nightMountainPrefab;
    
    [SerializeField] 
    private GameObject _bgForestPrefab;
    
    [SerializeField] 
    private GameObject _sunsetForestPrefab;
    
    [SerializeField] 
    private GameObject _nightForestPrefab;


    [SerializeField]
    private GameObject _gameSettings;


    private bool _penguinMode = false;
    private bool _mountainMode = false;
    private bool _forestMode = false;

   
    
    void Start()
    {
        _gameSettings = GameObject.FindWithTag("gameSettings");
        if (_gameSettings.GetComponent<GameSettingsScript>().PenguinON())
        {
            _penguinMode = true;
            Instantiate(_bgPrefab, transform.position, Quaternion.identity, this.transform);


        } else if (_gameSettings.GetComponent<GameSettingsScript>().MountainOn())
        {
            _mountainMode = true;
            Instantiate(_bgMountainPrefab, _bgMountainPrefab.transform.position, Quaternion.identity, this.transform);

        } else if (_gameSettings.GetComponent<GameSettingsScript>().ForestOn())
        {
            _forestMode = true;
            Instantiate(_bgForestPrefab, _bgForestPrefab.transform.position, Quaternion.identity, this.transform);

        }
        
        
    }

    public void Sunset()
    {
        foreach (Transform child in this.transform)
        {
            Destroy(child.gameObject);
        }
        if (_penguinMode)
        {
            Instantiate(_sunsetPrefab, transform.position, Quaternion.identity, this.transform);
        } else if (_mountainMode)
        {
            Instantiate(_sunsetMountainPrefab, _sunsetMountainPrefab.transform.position, Quaternion.identity, this.transform);
        } else if (_forestMode)
        {
            Instantiate(_sunsetForestPrefab, _sunsetForestPrefab.transform.position, Quaternion.identity, this.transform);
        }

    }
    
    public void Night()
    {
        foreach (Transform child in this.transform)
        {
            Destroy(child.gameObject);
        }
        if (_penguinMode)
        {
            Instantiate(_nightPrefab, transform.position, Quaternion.identity, this.transform);
        } else if (_mountainMode)
        {
            Instantiate(_nightMountainPrefab, _nightMountainPrefab.transform.position, Quaternion.identity, this.transform);
        } else if (_forestMode)
        {
            Instantiate(_nightForestPrefab, _nightForestPrefab.transform.position, Quaternion.identity, this.transform);
        }
    }
    void Update()
    {
        
    }
}
