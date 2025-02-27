using UnityEngine;
using System.Collections;
public class S_ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectToSpawn; // L'objet à spawner
    public MeshCollider spawnArea; // Zone de spawn en 3D

    public int spawnCount; // Nombre d'objets à spawner
    public float spawnDelay = 1f; // Temps entre chaque spawn
    public GameObject Key;
    public bool randomKey=false;

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
        if (S_GameManager.Instance.GM_Key==null && randomKey)
            {
                S_GameManager.Instance.GM_Key=Instantiate(Key, spawnPosition, Quaternion.identity);
            }
        else
        {
            int randomNumber = Random.Range(0,objectToSpawn.Length);
            Instantiate(objectToSpawn[randomNumber], spawnPosition, Quaternion.identity);
        }
        
        yield return new WaitForSeconds(spawnDelay);
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
