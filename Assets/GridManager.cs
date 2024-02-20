using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private Grid grid;
    [SerializeField] private int width, height;
    [SerializeField] private int numGems = 10;
    [SerializeField] private GameObject gemPrefab;
    [SerializeField] private int baseProbability;

    private int probability;
    private bool hasSpawned = false;
    
    private void Start()
    {
        grid = GetComponent<Grid>();
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                int random = Random.Range(0, 101);

                if (random < 100 - probability)
                {
                    var worldPosition = grid.GetCellCenterWorld(new Vector3Int(x - 2,y - 2));
                    var spawnedGem = Instantiate(gemPrefab, worldPosition, Quaternion.identity);
                    spawnedGem.name = $"Gem {x} {y}";
                    hasSpawned = true;

                    if (hasSpawned)
                        probability = baseProbability;
                    else
                        probability = probability * 2;
                }
            }
        }
    }
}
