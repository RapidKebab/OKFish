using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawn : MonoBehaviour
{
    public GameObject fish; //the fish to spawn
    [SerializeField] private int spawnNo;   //no of fish to spawn
    [SerializeField] private float maxZ;    //bounds of the "pond"
    [SerializeField] private float minZ;    //bounds of the "pond"
    [SerializeField] private float maxX;    //bounds of the "pond"
    [SerializeField] private float minX;    //bounds of the "pond"

    void Start()
    {
        SpawnFish(spawnNo);
    }

    public void SpawnFish(int n)   //if called with 0 this will spawn the predetermined spawn number of fish, else it'll spawn n fish.
    {
        if (n == 0)
            n = spawnNo;
        for(int i = 0; i < n; i++)
        {
            Instantiate(fish, new Vector3(Random.Range(minX, maxX), 0, Random.Range(minZ, maxZ)), Quaternion.Euler(0, Random.Range(0, 360), 0));
        }
    }
}
