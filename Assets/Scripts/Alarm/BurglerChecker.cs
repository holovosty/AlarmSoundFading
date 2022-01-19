using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BurglerChecker : MonoBehaviour
{
    [SerializeField] private UnityEvent _startAlarm;
    [SerializeField] private UnityEvent _stopAlarm;

    private RaycastHit2D _hit;
    private bool _isAlarm;

    private void FixedUpdate()
    {
        _hit = Physics2D.Raycast(transform.position, Vector2.up);

        if (_hit.collider.TryGetComponent<Player>(out Player player) && !_isAlarm && Input.GetKey(KeyCode.D))
        {
            _startAlarm.Invoke();
            _isAlarm = true;
        }
        else if (_hit.collider.TryGetComponent<Player>(out player) && _isAlarm && Input.GetKey(KeyCode.A))
        {
            _stopAlarm.Invoke();
            _isAlarm = false;
        }
    }
}
