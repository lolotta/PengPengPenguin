using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaccineManagerScript : MonoBehaviour
{
    [SerializeField] 
    private GameObject _vaccinePrefab;

    [SerializeField]
    private float _vaccinationRate = 0.4f;

    private float _timeToVaccinate = 0f;

    [SerializeField]
    private GameObject _player;

    private bool _powerUpOn = false;

    private float _powerUpTime = 10f;

    private float _powerDownAt;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
     public void PowerUp()
        {
            _vaccinationRate = 0.4f;
            _powerUpOn = true;
            _powerDownAt = Time.time + _powerUpTime;

        }
    
     public void PowerDown()
        {
            _vaccinationRate = 0.4f;
            _powerUpOn = false;
        }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _timeToVaccinate)
        {
            _timeToVaccinate = Time.time + _vaccinationRate;
            Instantiate(_vaccinePrefab, _player.transform.position + new Vector3(0f, 1.5f, 0f), Quaternion.identity, this.transform);
        }

        if (_powerUpOn && Time.time >= _powerDownAt)
        {
            PowerDown();
        }
    }

    public void DestroyVaccines()
    {
        foreach (Transform child in this.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
