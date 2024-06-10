using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BuildingController : MonoBehaviour{
    public GameObject pointer;
    public int idxBuilding;
    public string buildingScene;
    private MapSystem _MapSystem;

    [SerializeField] private string _buildingName;

    private StoryManager _storyManager;
    // Start is called before the first frame update
    void Start()
    {
        _MapSystem = MapSystem.Instance;
        _storyManager = StoryManager.Instance;
        
        // pointer.SetActive(_MapSystem.currentBuilding == idxBuilding);
        pointer.SetActive(_MapSystem.currentBuildingName == _buildingName);
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
        _MapSystem.currentBuilding = idxBuilding;
        _MapSystem.currentBuildingName = _buildingName;

        if (_storyManager.IdxStory == 1)
        {
            _storyManager.UpdateStory();
            _storyManager.StartStory();
        }
        else
        {
            SceneManager.LoadScene(_buildingName);
        }
    }
    
    private void MoveCharAnimation(int currentBuilding, int gotoBuilding)
    {
        switch(currentBuilding) 
        {
            case 1:
                switch (gotoBuilding)
                {
                    case 2:
                        mAnimatorChar.SetTrigger("B1toB2");
                        break;
                    case 3:
                        mAnimatorChar.SetTrigger("B1toB3");
                        break;
                    case 4:
                        mAnimatorChar.SetTrigger("B1toB4");
                        break;
                }
                break;
            case 2:
                switch (gotoBuilding)
                {
                    case 1:
                        mAnimatorChar.SetTrigger("B2toB1");
                        break;
                    case 3:
                        mAnimatorChar.SetTrigger("B2toB3");
                        break;
                    case 4:
                        mAnimatorChar.SetTrigger("B2toB4");
                        break;
                }
                break;
            
            case 3:
                switch (gotoBuilding)
                {
                    case 1:
                        mAnimatorChar.SetTrigger("B3toB1");
                        break;
                    case 2:
                        mAnimatorChar.SetTrigger("B3toB2");
                        break;
                    case 4:
                        mAnimatorChar.SetTrigger("B3toB4");
                        break;
                }
                break;
            case 4:
                switch (gotoBuilding)
                {
                    case 1:
                        mAnimatorChar.SetTrigger("B4toB1");
                        break;
                    case 2:
                        mAnimatorChar.SetTrigger("B4toB2");
                        break;
                    case 3:
                        mAnimatorChar.SetTrigger("B4toB3");
                        break;
                }
                break;
            default:
                Debug.Log(("Invalid"));
                break;
        }
    }
}
