using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private MapGenerator _mapGenerator;
    [SerializeField] private Vector2Int _size;
    [SerializeField] private List<Player> _players;
    [SerializeField] private WallMap _wallMap;

    public Vector2Int GetSize()
    {
        return _size;
    }

    public bool AreTilesAtCoordinatesAdjacent(Vector2Int first, Vector2Int second)
    {
        return
        (
            (first.x == second.x) &&
            (Mathf.Abs(first.y - second.y) == 1) ||
            (first.y == second.y) &&
            (Mathf.Abs(first.x - second.x) == 1)
        );
    }

    public bool IsPlayerAt(Vector2Int playerPosition)
    {
        for (int i = 0; i < _players.Count; i++)
        {
            if (new Vector2Int((int)_players[i].transform.position.x, (int)_players[i].transform.position.y) == playerPosition)
            {
                return true;
            }
        }

        return false;
    }

    public bool CanMove(Vector2Int fromCoordinates, Vector2Int toCoordinates)
    {
        return _wallMap.CanMove(fromCoordinates, toCoordinates);
    }

    public void DeselectAllTiles()
    {
        foreach (KeyValuePair<Vector2Int, Tile> entry in _tiles)
        {
            entry.Value.Deselect();
        }
    }

    private Dictionary<Vector2Int, Tile> _tiles;

    private void Start()
    {
        _tiles = _mapGenerator.Generate(_size);
    }
}

public static class DefaultVectors
{
    public static Vector2Int DefaultVector2Int
    {
        get
        {
            return new Vector2Int(int.MinValue, int.MinValue);
        }
    }
}