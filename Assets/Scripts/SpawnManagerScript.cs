using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField]
    private GameObject _virusPrefab;

    [SerializeField] private float _delay = 3f;
    
    

    private bool _spawningON = true;
    void Start()
    {
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

    public void onPlayerDeath()
    {
        _spawningON = false;
    }
    IEnumerator SpawnSystem()
    {
        while (_spawningON)
        {
            Instantiate(_virusPrefab, new Vector3(Random.Range(-8f, 8f), 7f, 0f), Quaternion.identity, this.transform);
            yield return new WaitForSeconds(_delay);

        }

        yield return null;

    }
}
