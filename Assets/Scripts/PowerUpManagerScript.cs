using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField]
    private GameObject _power_up_prefab;
    
    [SerializeField] private float _delay = 7f;
    
    

    private bool _spawningON = true;
    void Start()
    {
        StartCoroutine(PowerUpSystem());
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

    public void onPlayerDeath()
    {
        _spawningON = false;
    }
    IEnumerator PowerUpSystem()
    {
        while (_spawningON)
        {

            Instantiate(_power_up_prefab, new Vector3(Random.Range(-8f, 8f), 7f, 0f), Quaternion.identity, this.transform);

            yield return new WaitForSeconds(_delay);

        }

        yield return null;

    }
}