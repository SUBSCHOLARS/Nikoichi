using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct WeightedObstacle
{
    public GameObject prefab;
    public float weight; // likelihood (e.g., 10, 30, 60)
}

public class ObstacleSpawner : MonoBehaviour
{
    public WeightedObstacle[] weightedObstacles;

    private int numberOfObstacles;
    public float minDistanceBetweenObstacles = 2f;

    private List<Vector2> usedPositions = new List<Vector2>();
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;

        float screenWidth = Mathf.Abs(mainCamera.ViewportToWorldPoint(new Vector3(1, 0)).x - mainCamera.ViewportToWorldPoint(new Vector3(0, 0)).x);
        float screenHeight = Mathf.Abs(mainCamera.ViewportToWorldPoint(new Vector3(0, 1)).y - mainCamera.ViewportToWorldPoint(new Vector3(0, 0)).y);
        float screenArea = screenWidth * screenHeight;

        numberOfObstacles = Mathf.FloorToInt(screenArea * 0.05f); // adjust for density
        Debug.Log("Spawning " + numberOfObstacles + " obstacles based on screen area.");

        SpawnObstaclesInView();
    }

    GameObject GetRandomWeightedPrefab()
    {
        float totalWeight = 0f;
        foreach (var entry in weightedObstacles)
        {
            totalWeight += entry.weight;
        }

        float randomValue = Random.Range(0, totalWeight);
        float cumulative = 0f;

        foreach (var entry in weightedObstacles)
        {
            cumulative += entry.weight;
            if (randomValue <= cumulative)
            {
                return entry.prefab;
            }
        }

        return weightedObstacles[0].prefab; // Fallback
    }

    void SpawnObstaclesInView()
    {
        int spawned = 0;
        int maxAttempts = 500;

        // Camera bounds
        Vector2 min = mainCamera.ViewportToWorldPoint(new Vector3(0, 0));
        Vector2 max = mainCamera.ViewportToWorldPoint(new Vector3(1, 1));
        float centerX = (min.x + max.x) / 2f;
        float centerY = (min.y + max.y) / 2f;

        // Guarantee at least one of each prefab spawns
        List<GameObject> mustSpawn = new List<GameObject>();
        foreach (var entry in weightedObstacles)
        {
            if (!mustSpawn.Contains(entry.prefab))
                mustSpawn.Add(entry.prefab);
        }

        while ((spawned < numberOfObstacles || mustSpawn.Count > 0) && maxAttempts > 0)
        {
            Vector2 randomPos = new Vector2(
                Random.Range(min.x, max.x),
                Random.Range(min.y, max.y)
            );

            // Skip top-left quadrant
            if (randomPos.x < centerX && randomPos.y > centerY)
            {
                maxAttempts--;
                continue;
            }

            if (!IsFarEnough(randomPos))
            {
                maxAttempts--;
                continue;
            }

            GameObject prefab;
            if (mustSpawn.Count > 0)
            {
                prefab = mustSpawn[0];
                mustSpawn.RemoveAt(0);
            }
            else
            {
                prefab = GetRandomWeightedPrefab();
            }

            GameObject instance = Instantiate(prefab, randomPos, Quaternion.identity);
            usedPositions.Add(randomPos);
            spawned++;
            maxAttempts--;
        }

        if (mustSpawn.Count > 0)
        {
            Debug.LogWarning("Some prefabs couldn't be spawned due to space limits.");
        }
    }

    bool IsFarEnough(Vector2 pos)
    {
        foreach (var p in usedPositions)
        {
            if (Vector2.Distance(p, pos) < minDistanceBetweenObstacles)
                return false;
        }
        return true;
    }
}
