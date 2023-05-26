using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GridGenerator<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private GameObject _parent;
    [SerializeField] private T _prefab;

    public virtual Dictionary<Vector2Int, T> Generate(Vector2Int size)
    {
        Dictionary<Vector2Int, T> output = new Dictionary<Vector2Int, T>();

        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                int _id = 1 + x * size.x + y;
                T createdT = Instantiate(_prefab, new Vector3(x, y), Quaternion.identity);

                createdT.name = $"{typeof(T).Name} {_id}";
                createdT.transform.parent = _parent.transform;

                output.Add(new Vector2Int(x, y), createdT);
            }
        }

        return output;
    }
}
