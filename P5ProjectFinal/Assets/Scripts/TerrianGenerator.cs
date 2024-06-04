using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class TerrianGenerator : MonoBehaviour
{
    [SerializeField] private int minDistanceFromPlayer;
    [SerializeField] private int maxTerrianCount;
    [SerializeField] private List<TerrianData> terrianDatas = new List<TerrianData>();
    [SerializeField] private Transform terrainHolder;

    private List<GameObject> currentTerrians = new List<GameObject>();
    [HideInInspector] public Vector3 currentPosition = new Vector3(0, 0, 0);

    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < maxTerrianCount; i++)
        {
            SpawnTerrian(true, new Vector3(0, 0, 0));
        }
        maxTerrianCount = currentTerrians.Count;    
    }


    public void SpawnTerrian(bool isStart,  Vector3 playerPos)
    {
        if ((currentPosition.x - playerPos.x < minDistanceFromPlayer) || (isStart))
        {
            int whichTerrain = Random.Range(0, terrianDatas.Count);
            int terrainInSuccession = Random.Range(1, terrianDatas[whichTerrain].maxInSuccession);
            for (int i = 0; i < terrainInSuccession; i++)
            {
                GameObject terrain = Instantiate(terrianDatas[whichTerrain].possibleTerrian[Random.Range(0, terrianDatas[whichTerrain].possibleTerrian.Count)], currentPosition, Quaternion.identity, terrainHolder);
                terrain.transform.SetParent(terrainHolder);
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
}
        