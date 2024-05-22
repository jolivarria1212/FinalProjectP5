using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrianGenerator : MonoBehaviour
{
    private Vector3 currentPosition = new Vector3(0, 0, 0);

    [SerializeField] private List<GameObject> terrians = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        SpawnTerrian();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            SpawnTerrian();
        }
    }

    private void SpawnTerrian()
    {
        Instantiate(terrians[Random.Range(0,terrians.Count)], currentPosition, Quaternion.identity);
        currentPosition.x++;
    }
}