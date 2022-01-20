using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarm;

    private WaitForSeconds WaitForOneSecond = new WaitForSeconds(1);

    private float _targetVolumeValue;
    private bool _isBurglerInside;

    private static float _volumeFadeRate = 0.1f;

    private void Start()
    {
        _alarm.volume = 0;
    }

    public IEnumerator AlarmVolumeIncrease()
    {
        _isBurglerInside = true;
        _targetVolumeValue = 1;

        _alarm.Play();

        while (_alarm.volume < _targetVolumeValue && _isBurglerInside == true )
        {
            _alarm.volume = Mathf.MoveTowards(_alarm.volume, _targetVolumeValue, _volumeFadeRate);
            yield return WaitForOneSecond;
        }
    }

    public IEnumerator AlarmVolumeDecrease()
    {
        _isBurglerInside = false;
        _targetVolumeValue = 0; 

        while (_alarm.volume > _targetVolumeValue && _isBurglerInside == false )
        {
            _alarm.volume = Mathf.MoveTowards(_alarm.volume, _targetVolumeValue, _volumeFadeRate);
            yield return WaitForOneSecond;
        }

        _alarm.Stop();
    }

    public void StartAlarm()
    {
        StartCoroutine(AlarmVolumeIncrease());
    }

    public void StopAlarm()
    {
        StartCoroutine(AlarmVolumeDecrease());
    }
}
