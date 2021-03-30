using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoronaScript : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y < -5)
        {
            transform.position = new Vector3(
                Random.Range(-10f, 10f),
                7,
                0);
            
        }
        transform.Rotate(new Vector3(0f, 90f, 0f) * Time.deltaTime, Space.World);
        
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerScript>().Damage();
            Destroy(this.gameObject);
        }
        else if (other.CompareTag("vaccine"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);

        }
    }
}
