using System.Collections.Generic;
using UnityEngine;

public class TileGridLayout : MonoBehaviour
{
    [SerializeField] private int gridX, gridY;
    [SerializeField] private GameObject tileObject;

    private List<GameObject> _tileList = new List<GameObject>();

    private void SetupGrid()
    {

        // when object duplicated tile list will be empty,
        // this statement will control this case
        if (_tileList.Count <= 0)
        {
            foreach (Transform child in transform)
            {
                _tileList.Add(child.gameObject);
            }
        }

        foreach (var tile in _tileList)
        {
            DestroyImmediate(tile);
        }
        
        _tileList.Clear();

        var tileSize = new Vector2(tileObject.transform.localScale.x, tileObject.transform.localScale.z);
        for (int x = 0; x < gridY; x++)
        {
            for (int y = 0; y < gridX; y++)
            {
                var pos = new Vector3(transform.position.x + x * tileSize.x, 0, transform.position.z + y * tileSize.y);
                var obj = Instantiate(tileObject, pos, Quaternion.identity);
                obj.transform.SetParent(transform);
                _tileList.Add(obj);
            }
        }
    }

    public void SetGrids()
    {
        SetupGrid();
    }
}