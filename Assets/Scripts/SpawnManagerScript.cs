using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField]
    private GameObject _virusPrefab;

    private float _delay;
    private float _delayRange;
    

    private bool _spawningON = true;
    private bool _sunsetON = false;
    private bool _nightON = false;
    void Start()
    {
        _delayRange = 2f;
        StartCoroutine(SpawnSystem());
    }

    // Update is called once per frame
    void Update()
    {
        if (!_spawningON)
        {
            foreach (Transform child in this.transform)
            {
                Destroy(child.gameObject);
            }
        }
            
    }

    //spawning gets faster
    public void SunsetLevel()
    {
        _delayRange = 1.5f;
        _sunsetON = true;

    }
    
    public void NightLevel()
    {
        _delayRange = 1f;
        _sunsetON = false;
        _nightON = true;

    }
    public void onPlayerDeath()
    {
        _spawningON = false;
    }
    IEnumerator SpawnSystem()
    {
        while (_spawningON)
        {
            _delay = Random.Range(_delayRange, _delayRange + 1f);
            Instantiate(_virusPrefab, new Vector3(Random.Range(-8f, 8f), 7f, 0f), Quaternion.identity, this.transform);
            
            //make sure that all coronas are in sunset mode
            if (_sunsetON){
                foreach (Transform child in this.transform)
                {
                    child.GetComponent<CoronaScript>().SunsetLevel();
                }
                
            }
            
            if (_nightON){
                foreach (Transform child in this.transform)
                {
                    child.GetComponent<CoronaScript>().NightLevel();
                }
                
            }
            
            yield return new WaitForSeconds(_delay);

        }

        yield return null;

    }
}
