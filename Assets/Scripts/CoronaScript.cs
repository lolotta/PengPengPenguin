using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoronaScript : MonoBehaviour
{
    private float _speed;
    private float _speedRange = 3f;
    private bool _sunsetSpeed = false;
    private bool _nightSpeed = false;

    // Start is called before the first frame update
    void Start()
    {
        _speed = Random.Range(_speedRange, _speedRange + 2);
    }

    //Makes the new coronas faster
    public void SunsetLevel()
    {
        if (_sunsetSpeed == false)
        {
            _speedRange = 6f;
            _speed = Random.Range(_speedRange, _speedRange + 2);
            _sunsetSpeed = true;
        }
    }
    
    public void NightLevel()
    {
        if (_nightSpeed == false)
        {
            _speedRange = 8f;
            _speed = Random.Range(_speedRange, _speedRange + 2);
            _nightSpeed = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * (_speed * Time.deltaTime));
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
            SoundManagerScript.PlaySound("loseLife");
            GameObject.FindWithTag("Player").GetComponent<PlayerScript>().HealthCount(1);
            other.GetComponent<PlayerScript>().Damage();
            Destroy(this.gameObject);
        }
        else if (other.CompareTag("vaccine"))
        {
            SoundManagerScript.PlaySound("hitCorona");
            GameObject.FindWithTag("Player").GetComponent<PlayerScript>().ScoreCount(1);
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}