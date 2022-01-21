using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarm;

    private WaitForSeconds _waitingTime = new WaitForSeconds(1);

    private float _targetVolume;
    private bool _isBurglerInside;

    private static float _volumeFadeRate = 0.1f;

    private void Start()
    {
        _alarm.volume = 0;
    }

    public IEnumerator VolumeIncrease()
    {
        _isBurglerInside = true;
        _targetVolume = 1;

        _alarm.Play();

        while (_alarm.volume < _targetVolume && _isBurglerInside == true )
        {
            _alarm.volume = Mathf.MoveTowards(_alarm.volume, _targetVolume, _volumeFadeRate);
            yield return _waitingTime;
        }
    }

    public IEnumerator VolumeDecrease()
    {
        _isBurglerInside = false;
        _targetVolume = 0; 

        while (_alarm.volume > _targetVolume && _isBurglerInside == false )
        {
            _alarm.volume = Mathf.MoveTowards(_alarm.volume, _targetVolume, _volumeFadeRate);
            yield return _waitingTime;
        }

        _alarm.Stop();
    }

    public void StartAlarm()
    {
        StartCoroutine(VolumeIncrease());
    }

    public void StopAlarm()
    {
        StartCoroutine(VolumeDecrease());  
    }
}
