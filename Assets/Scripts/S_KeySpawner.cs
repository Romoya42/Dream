using UnityEngine;

public class S_KeySpawner : MonoBehaviour
{
    public GameObject objectToSpawn; // L'objet à spawner
    public MeshCollider spawnArea; // Zone de spawn en 3D

    public int spawnCount = 1; // Nombre d'objets à spawner
    public float spawnDelay = 1f; // Temps entre chaque spawn

    public void SpawnKey()
    {
        
        StartCoroutine(SpawnObjects());
    }

    private System.Collections.IEnumerator SpawnObjects()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 spawnPosition = GetRandomPointInCollider();
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnDelay);
        }
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
