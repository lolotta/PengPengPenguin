using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaccineScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _speed = 4f;



    
    void Update()
    {
        
        transform.Translate(Vector3.up * _speed * Time.deltaTime);

        if (transform.position.y > 7f)
        {
            Destroy(this.gameObject);
        }
        
    }


    
}