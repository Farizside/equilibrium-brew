using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BuildingController : MonoBehaviour{
    public GameObject pointer;
    public int idxBuilding;
    public string buildingScene;
    private MapSystem _MapSystem;
    // Start is called before the first frame update
    void Start()
    {
        _MapSystem = MapSystem.Instance;
        pointer.SetActive(_MapSystem.currentBuilding == idxBuilding);
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
        UnityEngine.SceneManagement.SceneManager.LoadScene(buildingScene);
    }
}
