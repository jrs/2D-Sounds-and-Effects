using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 _spawnPos = new Vector3(15, -3f, 0);
    private float _startDelay = 2;
    private float _repeatRate = 2.75f;

    private PlayerController _playerScript;

    // Start is called before the first frame update
    void Start()
    {
        _playerScript = GameObject.Find("Player").GetComponent<PlayerController>();InvokeRepeating("SpawnObstacle", _startDelay, _repeatRate);
    }

    void SpawnObstacle()
    {
        if(_playerScript.isGameOver == false)
        {
            Instantiate(obstaclePrefab, _spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
