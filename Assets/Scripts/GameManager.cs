using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float SpawnCounter = 10f;
    public GameObject EnemyPrefab;
    public bool IsActive;
    void Update()
    {
        if (!IsActive)
        {
            return;
        }
        if(SpawnCounter <= 0)
        {
            Debug.Log("spawn");
            Vector2 SpawnLocation = new Vector2(Random.Range(10, 0), Random.Range(10, 0));
            Instantiate(EnemyPrefab, SpawnLocation, Quaternion.identity);

            SpawnCounter = 10f;
        }

        SpawnCounter -= Time.deltaTime;
    }
}
