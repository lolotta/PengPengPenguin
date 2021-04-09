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

    private bool _penguinMode = true;
    private bool _mountainMode = false;
    private bool _forestMode = false;

    public void PenguinMode()
    {
        _penguinMode = true;
    }
    
    public void MountainMode()
    {
        _mountainMode = true;
        _penguinMode = false;
    }
    
    public void ForestMode()
    {
        _forestMode = true;
        _mountainMode = false;
        _penguinMode = false;
    }
    
    void Start()
    {
        if (_penguinMode)
        {
            Instantiate(_bgPrefab, transform.position, Quaternion.identity, this.transform);
        } else if (_mountainMode)
        {
            Instantiate(_bgMountainPrefab, _bgMountainPrefab.transform.position, Quaternion.identity, this.transform);
        } else if (_forestMode)
        {
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
