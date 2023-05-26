using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public Wall GrabbedWall { get; private set; }

    [SerializeField] private TurnEngine _turnEngine;
    [SerializeField] private WallMap _wallMap;

    public void ConnectWall()
    {
        _isWallConnected = true;
    }

    public void DisconnectWall()
    {
        _isWallConnected = false;
    }

    public void GrabWall(Wall wall)
    {
        this.ConnectWall();

        GrabbedWall = wall;
        GrabbedWall.Grab();

        _isWallGrabbed = true;
    }

    public void PlaceWall(Vector3 slotPosition)
    {
        this.DisconnectWall();

        this.AddMoveRestrictions(slotPosition);

        GrabbedWall = null;

        _isWallGrabbed = false;

        _turnEngine.PassToNextTurn(DefaultVectors.DefaultVector2Int);
    }

    private bool _isWallConnected = false;
    private bool _isWallGrabbed = false;

    private void AddMoveRestrictions(Vector3 slotPosition)
    {
        Vector2Int floor = new Vector2Int(Mathf.FloorToInt(slotPosition.x), Mathf.FloorToInt(slotPosition.y));
        Vector2Int ceiling = new Vector2Int(Mathf.CeilToInt(slotPosition.x), Mathf.CeilToInt(slotPosition.y));

        Vector2Int bottomLeftTile = floor;
        Vector2Int bottomRightTile = new Vector2Int(ceiling.x, floor.y);
        Vector2Int topLeftTile = new Vector2Int(floor.x, ceiling.y);
        Vector2Int topRightTile = ceiling;

        Debug.Log(bottomLeftTile);
        Debug.Log(bottomRightTile);
        Debug.Log(topLeftTile);
        Debug.Log(topRightTile);

        if (GrabbedWall.Orientation == Orientation.HORIZONTAL)
        {
            _wallMap.AddMoveRestrictionEntry(bottomLeftTile, topLeftTile);
            _wallMap.AddMoveRestrictionEntry(bottomRightTile, topRightTile);
            _wallMap.AddMoveRestrictionEntry(topLeftTile, bottomLeftTile);
            _wallMap.AddMoveRestrictionEntry(topRightTile, bottomRightTile);
        }
        else
        {
            _wallMap.AddMoveRestrictionEntry(bottomLeftTile, bottomRightTile);
            _wallMap.AddMoveRestrictionEntry(topLeftTile, topRightTile);
            _wallMap.AddMoveRestrictionEntry(bottomRightTile, bottomLeftTile);
            _wallMap.AddMoveRestrictionEntry(topRightTile, topLeftTile);
        }
    }

    private void Update()
    {
        if (_isWallGrabbed && _isWallConnected)
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0.0f;
            GrabbedWall.transform.position = position;
        }
    }
}
