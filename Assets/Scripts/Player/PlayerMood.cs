using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMood : MonoBehaviour
{
    [Range(-1, 1)]
    [SerializeField] private float _moodLevel;

    [SerializeField] private float _moodSwingLevel;

    [SerializeField] private Slider _moodSlider;

    public void DepressMood()
    {
        _moodLevel -= _moodSwingLevel;
        HandleUI();
    }
    
    public void ManicMood()
    {
        _moodLevel += _moodSwingLevel;
        HandleUI();
    }

    public void HandleUI()
    {
        _moodSlider.value = _moodLevel;
    }
}
