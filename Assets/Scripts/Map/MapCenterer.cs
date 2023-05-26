using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCenterer : MonoBehaviour
{
    [SerializeField] Transform _object;
    [SerializeField] Map _map;

    private void Start()
    {
        _object.position = new Vector3(_map.GetSize().x / 2.0f - 0.5f, _map.GetSize().y / 2.0f - 0.5f, -10.0f);
    }
}
