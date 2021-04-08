using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
