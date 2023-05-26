using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    UP = 0,
    RIGHT = 1,
    DOWN = 2,
    LEFT = 3,
    UNKNOWN = 4
}

public class Player : MonoBehaviour
{
    [HideInInspector] public bool ActiveTurn { get; set; }

    [SerializeField] private Vector2Int _startCoordinates;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private int _winX;
    [SerializeField] private GameEnd _gameEnd;
    [SerializeField] private string _name;

    public void MoveTo(Vector2Int coordinates)
    {
        if (coordinates.x == _winX)
        {
            _gameEnd.EndGame(_name);
        }

        transform.position = new Vector3(coordinates.x, coordinates.y);
    }

    private void Start()
    {
        _playerTransform.position = new Vector3(_startCoordinates.x, _startCoordinates.y);
    }
}