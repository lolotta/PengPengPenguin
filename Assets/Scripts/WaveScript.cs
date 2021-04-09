using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveScript : MonoBehaviour
{
    private bool _playerDeath = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlayerDeath()
    {
        _playerDeath = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (!_playerDeath)
        {
            transform.Translate(  0.0005f * Vector3.right * Time.time);
            if (transform.position.x > 9)
            {
                transform.position = new Vector3(
                    -9f,
                    transform.position.y,
                    transform.position.z);
            }
        }
        
    }
}
