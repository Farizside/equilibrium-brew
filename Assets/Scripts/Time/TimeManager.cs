using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private Time _curTime;
    [SerializeField] private int _curDay;
    [SerializeField] private float _duration;

    public static Action OnMorningTime;
    public static Action OnAfternoonTime;
    public static Action OnNightTime;
    public static Action OnTimeChanged;

    public static TimeManager Instance;

    private void Awake()
    {
        if (Instance != null) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
        
        DontDestroyOnLoad(this);
    }

    public void Start()
    {
        _curTime = Time.Morning;
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(_duration);
            UpdateTime();
        }
    }

    private void UpdateTime()
    {
        switch (_curTime)
        {
            case Time.Morning:
                _curTime = Time.Afternoon;
                OnAfternoonTime?.Invoke();
                break;
            case Time.Afternoon:
                _curTime = Time.Night;
                OnNightTime?.Invoke();
                break;
            case Time.Night:
                _curTime = Time.Morning;
                OnMorningTime?.Invoke();
                _curDay++;
                break;
        }
        
        OnTimeChanged?.Invoke();
    }
    
    public enum Time
    {
        Morning,
        Afternoon,
        Night
    }
}
