using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BuildingController : MonoBehaviour{
    public GameObject pointer;
    public int idxBuilding;
    public string buildingScene;
    public Animator mAnimatorChar;
    private MapSystem _mapSystem;
    
    // Start is called before the first frame update
    void Start()
    {
        _mapSystem = MapSystem.Instance;
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
        MoveCharAnimation(_mapSystem.currentBuilding,idxBuilding);
        _mapSystem.currentBuilding = idxBuilding;
        StartCoroutine(ChangeSceneFinisAnim());
        // UnityEngine.SceneManagement.SceneManager.LoadScene(buildingScene);
    }

    IEnumerator ChangeSceneFinisAnim()
    {
        while (mAnimatorChar.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
        {
            yield return null;
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene(buildingScene);
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
