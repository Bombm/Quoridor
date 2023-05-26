using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMap : MonoBehaviour
{
    [SerializeField] private WallSlotGenerator _wallSlotGenerator;
    [SerializeField] private WallGenerator _wallGenerator;
    [SerializeField] private Map _map;
    [SerializeField] private TurnEngine _turnEngine;

    public bool CanMove(Vector2Int fromCoordinates, Vector2Int toCoordinates)
    {
        KeyValuePair<Vector2Int, Vector2Int> comparable = new KeyValuePair<Vector2Int, Vector2Int>(fromCoordinates, toCoordinates);

        for (int i = 0; i < _cantMove.Count; i++)
        {
            if (_cantMove[i].Key == comparable.Key && _cantMove[i].Value == comparable.Value)
            {
                return false;
            }
        }

        return true;
    }

    public int GetCurrentPlayerId()
    {
        return _turnEngine.CurrentPlayerId;
    }

    public void AddMoveRestrictionEntry(Vector2Int fromCoordinates, Vector2Int toCoordinates)
    {
        _cantMove.Add(new KeyValuePair<Vector2Int, Vector2Int>(fromCoordinates, toCoordinates));
    }

    private Dictionary<Vector2Int, WallSlot> _wallSlots;
    private List<KeyValuePair<Vector2Int, Vector2Int>> _cantMove = new List<KeyValuePair<Vector2Int, Vector2Int>>();

    private void Start()
    {
        _wallSlots = _wallSlotGenerator.Generate(new Vector2Int(_map.GetSize().x - 1, _map.GetSize().y - 1));
        _wallGenerator.Generate(new Vector2Int(1, 20));
    }
}
