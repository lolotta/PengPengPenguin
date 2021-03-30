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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _timeToVaccinate)
        {
            _timeToVaccinate = Time.time + _vaccinationRate;
            Instantiate(_vaccinePrefab, _player.transform.position + new Vector3(0f, 1.5f, 0f), Quaternion.identity, this.transform);
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
