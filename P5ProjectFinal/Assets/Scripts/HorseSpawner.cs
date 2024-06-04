using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseSpawner : MonoBehaviour
{
    [SerializeField] private GameObject horse;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private float minSeparationTime;
    [SerializeField] private float maxSeparationTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnHorse());
    }

    private IEnumerator SpawnHorse()
    {
        yield return new WaitForSeconds(Random.Range(minSeparationTime, maxSeparationTime));
        Instantiate(horse, spawnPos.position, Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
