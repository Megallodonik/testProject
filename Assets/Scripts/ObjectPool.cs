using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : Component {
    private Queue<T> _pool = new Queue<T>();
    private T _prefab;
    private Transform _parent;

    public ObjectPool(T prefab, int size, Transform parent = null) {
        _prefab = prefab;
        _parent = parent;

        for (int i = 0; i < size; i++) {
            T obj = Object.Instantiate(_prefab, _parent);
            obj.gameObject.SetActive(false);
            _pool.Enqueue(obj);
        }
    }

    public T Get() {
        if (_pool.Count == 0)
            return null;

        T obj = _pool.Dequeue();
        obj.gameObject.SetActive(true);
        return obj;
    }

    public void Return(T obj) {
        obj.gameObject.SetActive(false);
        _pool.Enqueue(obj);
    }
}