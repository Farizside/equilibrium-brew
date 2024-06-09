using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapUIHandler : MonoBehaviour
{
    private StoryManager _storyManager;

    private void Start()
    {
        _storyManager = StoryManager.Instance;
    }

    public void OpenMap()
    {
        SceneManager.LoadScene("Map");
    }
}
