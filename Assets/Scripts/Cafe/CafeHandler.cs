using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CafeHandler : MonoBehaviour
{
    private StoryManager _storyManager;
    void Start()
    {
        _storyManager = StoryManager.Instance;

        if (_storyManager.IdxStory == 4)
        {
            _storyManager.StartStory();
        }
    }
}
