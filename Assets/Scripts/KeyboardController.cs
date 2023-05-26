using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : MonoBehaviour
{
    [SerializeField] private MouseController _mouseController;

    private void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            _mouseController.GrabbedWall.Rotate();
        }
    }
}
