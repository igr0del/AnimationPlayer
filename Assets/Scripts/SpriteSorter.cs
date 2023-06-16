using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSorter : MonoBehaviour
{
    [SerializeField] bool _isStatic = false;
    [SerializeField] private float _offset = 0;

    private int _sortingOrderBase = 0;
    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void LateUpdate()
    {
        _renderer.sortingOrder = (int)(_sortingOrderBase - transform.position.y + _offset);

        if (_isStatic)
            Destroy(this);
    }
}