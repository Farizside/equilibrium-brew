using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSystem : MonoBehaviour
{
    public static MapSystem Instance;
    public int currentBuilding;

    public string currentBuildingName;

    private StoryManager _storyManager;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        _storyManager = StoryManager.Instance;
    }

    public void EnterBuilding()
    {
        if (_storyManager.IdxStory == 2 && currentBuildingName == "Pharmacy")
        {
            _storyManager.UpdateStory();
        }
        else if (_storyManager.IdxStory == 3 && currentBuildingName == "Cafe")
        {
            _storyManager.UpdateStory();
        }
        SceneManager.LoadScene(currentBuildingName);
    }
}
