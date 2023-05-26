using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSlotGenerator : GridGenerator<WallSlot> {
    public override Dictionary<Vector2Int, WallSlot> Generate(Vector2Int size)
    {
        Dictionary<Vector2Int, WallSlot> output = base.Generate(size);

        foreach (KeyValuePair<Vector2Int, WallSlot> entry in output)
        {
            entry.Value.transform.Translate(new Vector3(0.5f, 0.5f));
        }

        return output;
    }
}
