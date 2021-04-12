using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour
{
    // Start is called before the first frame update
    private float _speed;
    void Start()
    {
        _speed = Random.Range(0.1f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * (_speed * Time.deltaTime));
        if (transform.position.x > 180)
        {
            transform.position = new Vector3(
                -60,
                Random.Range(transform.position.y - 1f, transform.position.y + 1f),
                transform.position.z);
            
        }
    }
}
