using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class LevelSetup : MonoBehaviour
{
    
    public List<GameObject> spawnPoints;
    public GameObject spawnPrefab;

    public  float maxTimeLimit = 2.25f;
    void OnEnable()
    {
        
        if (spawnPrefab==null) return;

        ShuffleSpawnPoints();

        foreach (GameObject spawnPoint in spawnPoints)
        {
            StartCoroutine(RandomizedInstantiate(UnityEngine.Random.Range(0, maxTimeLimit), spawnPoint));
        }
    }

    IEnumerator RandomizedInstantiate(float time, GameObject spawnPoint){
        yield return new WaitForSeconds(time);

        GameObject spawn = Instantiate(spawnPrefab, spawnPoint.transform.position, Quaternion.identity);
        spawn.transform.parent = spawnPoint.transform;
        spawn.tag = "Hammer";
    }

    void ShuffleSpawnPoints(){
        System.Random random = new  System.Random();

        int n = spawnPoints.Count;  
        while(n>1){
            n--;
            int k =  random.Next(n+1);
            GameObject value = spawnPoints[k];
            spawnPoints[k] = spawnPoints[n];
            spawnPoints[n] = value;
        }
    }
}
