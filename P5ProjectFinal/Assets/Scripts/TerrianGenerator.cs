using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrianGenerator : MonoBehaviour
{
    [SerializeField] private int maxTerrianCount;
    [SerializeField] private List<TerrianData> terrianDatas = new List<TerrianData>();

    private List<GameObject> currentTerrians = new List<GameObject>();
    private Vector3 currentPosition = new Vector3(0, 0, 0);

    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < maxTerrianCount; i++)
        {
            SpawnTerrian(true);
        }
        maxTerrianCount = currentTerrians.Count;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            SpawnTerrian(false);
        }
    }

    private void SpawnTerrian(bool isStart)
    {
        int whichTerrain = Random.Range(0, terrianDatas.Count);
        int terrainInSuccession = Random.Range(1, terrianDatas[whichTerrain].maxInSuccession);
        for (int i = 0; i < terrainInSuccession; i++)
        {
            GameObject terrain = Instantiate(terrianDatas[whichTerrain].terrain, currentPosition, Quaternion.identity);
            currentTerrians.Add(terrain);
            if (!isStart)
            {
                if (currentTerrians.Count > maxTerrianCount)
                {
                    Destroy(currentTerrians[0]);
                    currentTerrians.RemoveAt(0);
                }
                currentPosition.x++;
            }
        }
    }
}