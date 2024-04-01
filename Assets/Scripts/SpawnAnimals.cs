using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAnimals : MonoBehaviour
{
    [SerializeField] private GameObject[] animalPrefabs;
    [Header("Spawn point")]
    [SerializeField] private float spawnRangePositionX;
    [SerializeField] private float spawnRangePositionZTop;
    [SerializeField] private float spawnRangePositionZBottom;
    [Header("instant point")]
    [SerializeField] private float rightX;
    [SerializeField] private float leftX;
    [SerializeField] private float PositionZ;
    [Header("Time Details")]
    [SerializeField] private float timeToStart;
    [SerializeField] private float delayRepeating;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimalsX", timeToStart, delayRepeating);
        InvokeRepeating("SpawnRandomAnimalsZLeft", timeToStart, delayRepeating);
        InvokeRepeating("SpawnRandomAnimalsZRight", timeToStart, delayRepeating);
    }
    void SpawnRandomAnimalsX()
    {
        int animalNumber;
        
        //the length of array is 3 and it means that array elements is[0,1,2] but when using this function we just sign from 0 to the latest number
        //0f array + 1 as we can type it like that Random.Range(0,3);
        animalNumber = Random.Range(0, animalPrefabs.Length);
        
        Vector3 spawnPositionX = new Vector3(Random.Range(-spawnRangePositionX, spawnRangePositionX), 0, PositionZ);
        
        Instantiate(animalPrefabs[animalNumber], spawnPositionX, animalPrefabs[animalNumber].transform.rotation);
    }
    void SpawnRandomAnimalsZRight()
    {
        int animalNumber;
        animalNumber = Random.Range(0, animalPrefabs.Length);

        Vector3 spawnPositionZ = new Vector3(rightX, 0, Random.Range(spawnRangePositionZBottom, spawnRangePositionZTop));

        Instantiate(animalPrefabs[animalNumber], spawnPositionZ,Quaternion.Euler(animalPrefabs[animalNumber].transform.rotation.x, animalPrefabs[animalNumber].transform.rotation.y-90, animalPrefabs[animalNumber].transform.rotation.z));
    } 
    void SpawnRandomAnimalsZLeft()
    {
        int animalNumber;
        animalNumber = Random.Range(0, animalPrefabs.Length);

        Vector3 spawnPositionZ = new Vector3(leftX, 0, Random.Range(spawnRangePositionZBottom, spawnRangePositionZTop));

        Instantiate(animalPrefabs[animalNumber], spawnPositionZ, Quaternion.Euler(animalPrefabs[animalNumber].transform.rotation.x, animalPrefabs[animalNumber].transform.rotation.y + 90, animalPrefabs[animalNumber].transform.rotation.z));
    }
}
