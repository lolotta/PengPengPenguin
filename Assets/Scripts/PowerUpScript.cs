using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    
    private float _speed = 6f;

    
    void Start()
    {
        SoundManagerScript.PlaySound("InstantiatePowerUp");

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        transform.Rotate(new Vector3(0f, 90f, 0f) * Time.deltaTime, Space.World);
        
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerScript>().PowerUp();
            SoundManagerScript.PlaySound("powerUp");

            Destroy(this.gameObject);
        }
        
    }
}