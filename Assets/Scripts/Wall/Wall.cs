using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public int OwnerId { private get; set; }
    public Vector3 OriginalPosition { get; set; }
    public Orientation Orientation { get; private set; } = Orientation.VERTICAL;

    [SerializeField] private BoxCollider2D _collider;

    public void Rotate()
    {
        if (Orientation == Orientation.HORIZONTAL)
        {
            Orientation = Orientation.VERTICAL;
        }
        else
        {
            Orientation = Orientation.HORIZONTAL;
        }

        this.SetRotationByOrientation(Orientation);
    }

    public void Grab()
    {
        _collider.enabled = false;
    }

    private MouseController _mouseController;
    private WallMap _map;

    private void SetRotationByOrientation(Orientation orientation)
    {
        if (orientation == Orientation.VERTICAL)
        {
            transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        }
        else
        {
            transform.eulerAngles = new Vector3(0.0f, 0.0f, 90.0f);
        }
    }

    private void Start()
    {
        this.SetRotationByOrientation(Orientation);

        transform.parent.TryGetComponent<MouseController>(out _mouseController);
        transform.parent.TryGetComponent<WallMap>(out _map);
    }

    private void OnMouseDown()
    {
        if (OwnerId == _map.GetCurrentPlayerId())
        {
            _mouseController.GrabWall(this);
        }
    }
}

public enum Orientation
{
    HORIZONTAL = 0,
    VERTICAL = 1
}