using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float delay;
    [SerializeField] private float increment;
    [SerializeField] private float incrementDelay;
    [SerializeField] private float minDelay;

    [SerializeField] private Boundaries[] bounds;


    float timer;
    float nextSpawn;
    float nextIncrement;
    private void Start()
    {
        nextSpawn = delay;
    }
    private void Update()
    {
        if (delay < minDelay) delay = minDelay;
        timer += Time.deltaTime;
        if(timer >= nextSpawn)
        {
            Spawn();
            nextSpawn = timer + delay;
        }
        if(timer >= nextIncrement && delay > minDelay)
        {
            Scaling();
            nextIncrement = timer + incrementDelay;
        }
    }
    private void Spawn()
    {
        int r = Random.Range(0, bounds.Length);
        Vector2 spawnAt = new Vector2(Random.Range(bounds[r].minX, bounds[r].maxX),
                                      Random.Range(bounds[r].minY, bounds[r].maxY));

        Instantiate(enemy, spawnAt ,Quaternion.identity);
    }

    private void Scaling()
    {
        delay -= increment;

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        for(int i = 0; i < bounds.Length; i++)
        {
            Vector3 center = new Vector3((bounds[i].minX + bounds[i].maxX) / 2, (bounds[i].minY + bounds[i].maxY) / 2, 0);
            Vector3 size = new Vector3((bounds[i].maxX - bounds[i].minX), (bounds[i].maxY - bounds[i].minY), 0);
            Gizmos.DrawWireCube(center, size);
        }
    }

    [System.Serializable]
    public class Boundaries
    {
        public int minX;
        public int maxX;
        public int minY;
        public int maxY;

    }

}
