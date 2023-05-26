using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnEngine : MonoBehaviour
{
    public Vector2Int CurrentPlayerCoordinates { get; private set; }
    public int CurrentPlayerId { 
        get
        {
            return _currentPlayerId;
        } 
    }

    [SerializeField] private List<Player> _players;
    [SerializeField] private Map _map;

    public void PassToNextTurn(Vector2Int moveToTileWithCoordinates)
    {
        _players[_currentPlayerId].ActiveTurn = false;

        if (moveToTileWithCoordinates != DefaultVectors.DefaultVector2Int)
        {
            if (!_map.IsPlayerAt(moveToTileWithCoordinates))
            {
                _players[_currentPlayerId].MoveTo(moveToTileWithCoordinates);
            }
            else
            {
                Vector2Int offset = moveToTileWithCoordinates - CurrentPlayerCoordinates;
                _players[_currentPlayerId].MoveTo(moveToTileWithCoordinates + offset);
            }
        }

        _currentPlayerId++;
        if (_currentPlayerId == _players.Count)
        {
            _currentPlayerId = 0;
        }

        _players[_currentPlayerId].ActiveTurn = true;

        Vector3 currentPlayerPosition = _players[_currentPlayerId].transform.position;
        CurrentPlayerCoordinates = new Vector2Int((int)currentPlayerPosition.x, (int)currentPlayerPosition.y);
    }

    private int _currentPlayerId = 0;

    private void Start()
    {
        _players[_currentPlayerId].ActiveTurn = true;
        Vector3 currentPlayerPosition = _players[_currentPlayerId].transform.position;
        CurrentPlayerCoordinates = new Vector2Int((int)currentPlayerPosition.x, (int)currentPlayerPosition.y);
    }
}
