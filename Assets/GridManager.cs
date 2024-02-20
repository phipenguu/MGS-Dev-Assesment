using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [Header("Grid")]
    [SerializeField] private Grid grid;
    [SerializeField] private int width, height;

    [Header("Gems")]
    [SerializeField] private GameObject brownGem;
    [SerializeField] private GameObject redGem;
    [SerializeField] private GameObject greenGem;
    [SerializeField] private GameObject yellowGem;
    [SerializeField] private GameObject whiteGem;
    [SerializeField] private GameObject blueGem;
    [SerializeField] private int baseProbability;

    private int probability;
    private float gemColorBase = 100/6;
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
                var worldPosition = grid.GetCellCenterWorld(new Vector3Int(x - 2, y - 7));

                if (random <= gemColorBase)
                {
                    var spawnedGem = Instantiate(brownGem, worldPosition, Quaternion.identity);
                    spawnedGem.name = $"Gem {x} {y}";
                    hasSpawned = true;
                }
                else if (random > gemColorBase && random <= gemColorBase * 2)
                {
                    var spawnedGem = Instantiate(redGem, worldPosition, Quaternion.identity);
                    spawnedGem.name = $"Gem {x} {y}";
                    hasSpawned = true;
                }
                else if (random > gemColorBase * 2 && random <= gemColorBase * 3)
                {
                    var spawnedGem = Instantiate(greenGem, worldPosition, Quaternion.identity);
                    spawnedGem.name = $"Gem {x} {y}";
                    hasSpawned = true;
                }
                else if (random > gemColorBase * 3 && random <= gemColorBase * 4)
                {
                    var spawnedGem = Instantiate(yellowGem, worldPosition, Quaternion.identity);
                    spawnedGem.name = $"Gem {x} {y}";
                    hasSpawned = true;
                }
                else if (random > gemColorBase * 4 && random <= gemColorBase * 5)
                {
                    var spawnedGem = Instantiate(whiteGem, worldPosition, Quaternion.identity);
                    spawnedGem.name = $"Gem {x} {y}";
                    hasSpawned = true;
                }
                else if (random > gemColorBase * 5 && random <= gemColorBase * 6)
                {
                    var spawnedGem = Instantiate(blueGem, worldPosition, Quaternion.identity);
                    spawnedGem.name = $"Gem {x} {y}";
                    hasSpawned = true;
                }
            }
        }
    }
}
