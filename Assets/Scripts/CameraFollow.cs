using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform _player;
    private Vector3 _tempPos;
    [SerializeField]
    private float minX, maxX;
    void Start()
    {
        _player = GameObject.FindWithTag("Player").transform;
    }

    void LateUpdate()
    {
        var transform1 = transform;
        _tempPos = transform1.position;
        _tempPos.x = _player.position.x;
        if (_tempPos.x < minX) _tempPos.x = minX;
        if (_tempPos.x > maxX) _tempPos.x = maxX;
        transform1.position = _tempPos;
    }
}
