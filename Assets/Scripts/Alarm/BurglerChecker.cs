using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]

public class BurglerChecker : MonoBehaviour
{
    [SerializeField] private UnityEvent _burglerCameIn;
    [SerializeField] private UnityEvent _burglerCameOut;

    private bool _isAlarm;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player) && !_isAlarm && Input.GetKey(KeyCode.D))
        {
            _burglerCameIn.Invoke();
            _isAlarm = true;
        }
        else if (collision.TryGetComponent<Player>(out player) && _isAlarm && Input.GetKey(KeyCode.A))
        {
            _burglerCameOut.Invoke();
            _isAlarm = false;
        }
    }
}
