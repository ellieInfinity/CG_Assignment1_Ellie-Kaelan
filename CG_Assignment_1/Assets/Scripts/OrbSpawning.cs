using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OrbSpawning : MonoBehaviour
{
    [SerializeField] private Transform [] spawnpoints;

    [SerializeField] private GameObject prefab;

    [SerializeField] private float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnOrbs", 0, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnOrbs()
    {
        int rand = Random.Range(0, spawnpoints.Length);
        GameObject newOrb = Instantiate(prefab, spawnpoints[rand].position, Quaternion.identity);
        newOrb.transform.parent = transform;
    }
}
