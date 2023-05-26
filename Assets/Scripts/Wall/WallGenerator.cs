using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : GridGenerator<Wall> {
    [SerializeField] private float _leftX;
    [SerializeField] private float _rightX;
    [SerializeField] private float _offsetY;

    public override Dictionary<Vector2Int, Wall> Generate(Vector2Int size)
    {
        Dictionary<Vector2Int, Wall> output = base.Generate(size);

        int count = 0;
        foreach (KeyValuePair<Vector2Int, Wall> entry in output)
        {
            entry.Value.Rotate();

            float x;
            if (count % 2 == 0)
            {
                x = _leftX;
            } else
            {
                x = _rightX;
            }

            entry.Value.transform.position = new Vector3(x, count / 2 + _offsetY);
            entry.Value.OwnerId = count % 2;
            entry.Value.OriginalPosition = entry.Value.transform.position;

            count++;
        }

        return output;
    }
}
