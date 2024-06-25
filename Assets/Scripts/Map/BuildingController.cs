using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BuildingController : MonoBehaviour{
    public GameObject pointer;
    public int idxBuilding;
    private MapSystem _mapSystem;
    public CharMove Char;
    [SerializeField] private string _buildingName;

    private StoryManager _storyManager;
    void Start()
    {
        _mapSystem = MapSystem.Instance;
        // _storyManager = StoryManager.Instance;
        
        pointer.SetActive(_mapSystem.currentBuilding == idxBuilding);
    }
    private void OnMouseEnter()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
    }

    private void OnMouseExit()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);

    }

    private void OnMouseDown()
    {
        _mapSystem.currentBuilding = idxBuilding;
        _mapSystem.currentBuildingName = _buildingName;
        // if (_storyManager.IdxStory == 1)
        // {
        //     _storyManager.UpdateStory();
        //     _storyManager.StartStory();
        // }
        // else
        // {
            StartCoroutine(Char.ChangeSceneUntilReachTarget(gameObject.transform,_buildingName));
        // }    
    }
    
}
