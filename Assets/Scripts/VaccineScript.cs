using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaccineScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    private float _speed = 4f;

    private bool _powerUpOn = false;

    public void PowerOn()
    {
        _powerUpOn = true;
    }

    public void PowerDown()
    {
        _powerUpOn = false;

    }



    
    void Update()
    {
        
        transform.Translate(Vector3.up * _speed * Time.deltaTime);

        if (transform.position.y > 7f)
        {
            Destroy(this.gameObject);
        }
        
        if (_powerUpOn)
        {
            transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);

        }
        else
        {
            transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);

        }
        
        
        
    }


    
}