using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GameSettingsScript : MonoBehaviour
{
    
    private bool _penguinMode = true;
    private bool _mountainMode = false;
    private bool _forestMode = false;

    
    private static bool created = false;


    
    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;

        }
        else
        {
            Destroy(this.gameObject);
           
        }
        
        
    }
    
    public void Penguin()
    {
        _penguinMode = true;
        _mountainMode = false;
        _forestMode = false;
    }
    
    public void Mountain()
    {
        _penguinMode = false;
        _mountainMode = true;
        _forestMode = false;
    }
    
    public void Forest()
    {
        _penguinMode = false;
        _mountainMode = false;
        _forestMode = true;
    }
    
    public bool PenguinON()
    {
        return _penguinMode;
    }
    
    public bool MountainOn()
    {
        return _mountainMode;
    }
    
    public bool ForestOn()
    {
        return _forestMode;
    }
    
    
}
