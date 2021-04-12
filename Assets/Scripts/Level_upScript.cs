using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Level up is more like a life up
public class Level_upScript : MonoBehaviour
{
    [SerializeField]
    private float _speed = 6f;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * (_speed * Time.deltaTime));
        transform.Rotate(new Vector3(0f, 90f, 0f) * Time.deltaTime, Space.World);
        
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            //play the levelUp sound, heal the player, and destroy the levelUp
            
            SoundManagerScript.PlaySound("levelUp");
            other.GetComponent<PlayerScript>().Heal();
            Destroy(this.gameObject);
            
            
        }
        
    }
}
