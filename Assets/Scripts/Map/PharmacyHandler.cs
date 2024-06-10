using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PharmacyHandler : MonoBehaviour
{
    private StoryManager _storyManager;
    
    void Start()
    {
        _storyManager = StoryManager.Instance;

        if (_storyManager.IdxStory == 3)
        {
            _storyManager.StartStory();
        }
    }
}
