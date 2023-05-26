using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color _idleColor;
    [SerializeField] private Color _hoveredColor;
    [SerializeField] private Color _selectedColor;
    [SerializeField] private Color _selectedHoveredColor;
    [SerializeField] private SpriteRenderer _sprite;

    public Vector2Int GetCoordinates()
    {
        return new Vector2Int((int)transform.position.x, (int)transform.position.y);
    }

    public Color GetSelectedColor()
    {
        return _selectedColor;
    }

    public void Deselect()
    {
        _sprite.color = _idleColor;
        _isSelected = false;
    }

    private bool _isSelected = false;
    private TurnEngine _moveController;
    private Map _map;

    private void Start()
    {
        transform.parent.TryGetComponent<TurnEngine>(out _moveController);
        transform.parent.TryGetComponent<Map>(out _map);
    }

    private void OnMouseEnter()
    {
        if (!_isSelected)
        {
            _sprite.color = _hoveredColor;
        }
        else
        {
            _sprite.color = _selectedHoveredColor;
        }
    }

    private void OnMouseExit()
    {
        if (!_isSelected)
        {
            _sprite.color = _idleColor;
        }
        else
        {
            _sprite.color = _selectedColor;
        }
    }

    private void OnMouseDown()
    {
        if (_map.AreTilesAtCoordinatesAdjacent(this.GetCoordinates(), _moveController.CurrentPlayerCoordinates) &&
            _map.CanMove(_moveController.CurrentPlayerCoordinates, this.GetCoordinates()))
        {
            if (!_isSelected)
            {
                _map.DeselectAllTiles();

                _isSelected = true;
                _sprite.color = _selectedHoveredColor;
            }
            else
            {
                Vector2Int tileCoordinates = new Vector2Int((int)transform.position.x, (int)transform.position.y);

                _moveController.PassToNextTurn(tileCoordinates);

                _isSelected = false;
            }
        }
    }
}
