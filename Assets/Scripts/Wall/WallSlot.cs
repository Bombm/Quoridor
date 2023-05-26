using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSlot : MonoBehaviour
{
    private MouseController _mouseController;
    private Wall _wall;

    private void ConnectWall()
    {
        _mouseController.DisconnectWall();

        _wall = _mouseController.GrabbedWall;

        _wall.transform.position = transform.position;
    }

    private void DisconnectWall()
    {
        _mouseController.ConnectWall();

        _wall = null;
    }

    private void Start()
    {
        transform.parent.transform.parent.TryGetComponent<MouseController>(out _mouseController);
    }

    private void OnMouseEnter()
    {
        if (_mouseController.GrabbedWall != null)
        {
            this.ConnectWall();
        }
    }

    private void OnMouseExit()
    {
        if (_mouseController.GrabbedWall != null)
        {
            this.DisconnectWall();
        }
    }

    private void OnMouseDown()
    {
        if (_mouseController.GrabbedWall != null)
        {
            _mouseController.PlaceWall(transform.position);

            this.ConnectWall();
        }
    }
}
