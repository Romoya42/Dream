using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class S_ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectToSpawn; // L'objet à spawner
    public MeshCollider spawnArea; // Zone de spawn en 3D

    public int spawnCount; // Nombre d'objets à spawner
    public float spawnDelay = 1f; // Temps entre chaque spawn
    public GameObject Key;
    public bool randomKey=false;
    private List<GameObject> spawnedObjects = new List<GameObject>();


    public void Spawner()
    {
        if (randomKey)
        {
            spawnCount++;
        }
        for (int i = 0; i < spawnCount; i++)
        {
            StartCoroutine(SpawnObjects());         
        }
        
    }

    private IEnumerator SpawnObjects()
    {
        Vector3 spawnPosition = GetRandomPointInCollider();
        Quaternion randomRotation = Quaternion.Euler(0, Random.Range(0f, 360f), 0); // Rotation aléatoire sur l'axe Y
        GameObject newObject;

        if (S_GameManager.Instance.GM_Key == null && randomKey)
        {
            newObject = Instantiate(Key, spawnPosition, randomRotation);
            S_GameManager.Instance.GM_Key = newObject;
        }
        else
        {
            int randomNumber = Random.Range(0, objectToSpawn.Length);
            newObject = Instantiate(objectToSpawn[randomNumber], spawnPosition, randomRotation);
        }

        spawnedObjects.Add(newObject); 
        print(spawnedObjects);
        yield return new WaitForSeconds(spawnDelay);
    }


    public void DestroyAllSpawnedObjects()
    {
        print("suppr");
        foreach (GameObject obj in spawnedObjects)
        {
            if (obj != null)
            {
                Destroy(obj);
            }
        }
        spawnedObjects.Clear(); 
    }


    private Vector3 GetRandomPointInCollider()
    {
        if (spawnArea != null)
        {
            Bounds bounds = spawnArea.bounds;
            float x = Random.Range(bounds.min.x, bounds.max.x);
            float y = Random.Range(bounds.min.y, bounds.max.y);
            float z = Random.Range(bounds.min.z, bounds.max.z);
            return new Vector3(x, y, z);
        }

        return Vector3.zero;
    }
}
