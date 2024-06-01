using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMood : MonoBehaviour
{
    [SerializeField] private Mood _mood;
    
    [Range(-1, 1)]
    [SerializeField] private float _moodLevel;

    [SerializeField] private float _moodSwingLevel;

    [SerializeField] private float _manicThreshold;

    [SerializeField] private float _depressThreshold;

    [SerializeField] private Slider _moodSlider;

    private Action _onMoodValueChanged;
    private Action<Mood> _onMoodChanged;

    private Mood Mood
    {
        get => _mood;
        set
        {
            _mood = value;
            _onMoodChanged?.Invoke(value);
        }
    }

    private float MoodLevel
    {
        get => _moodLevel;
        set
        {
            _moodLevel = value;
            _onMoodValueChanged?.Invoke();
            if (MoodLevel >= _manicThreshold)
            {
                Mood = Mood.Manic;
            }else if (MoodLevel <= _depressThreshold)
            {
                Mood = Mood.Depress;
            }
            else
            {
                Mood = Mood.Stable;
            }
        }
    }

    public void OnEnable()
    {
        _onMoodValueChanged += HandleUI;
        _onMoodChanged += HandleMoodChanged;
    }

    private void OnDisable()
    {
        _onMoodValueChanged -= HandleUI;
        _onMoodChanged -= HandleMoodChanged;
    }

    public void DepressMood()
    {
        MoodLevel -= _moodSwingLevel;
    }
    
    public void ManicMood()
    {
        MoodLevel += _moodSwingLevel;
    }

    public void StabilizeMood(float value)
    {
        if (MoodLevel < 0)
        {
            MoodLevel += value;
        }else if (MoodLevel > 0)
        {
            MoodLevel -= value;
        }
    }

    public void HandleUI()
    {
        _moodSlider.value = _moodLevel;
    }

    public void HandleMoodChanged(Mood mood)
    {
        Debug.Log(mood);
    }
}

public enum Mood
{
    Stable,
    Manic,
    Depress
}
