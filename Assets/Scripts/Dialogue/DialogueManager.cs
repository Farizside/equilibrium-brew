using System.Collections;
using System.Collections.Generic;
using cherrydev;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private DialogBehaviour _dialogBehaviour;
    [SerializeField] private PlayerMood _player;

    public static DialogueManager Instance;
    
    private void Awake()
    {
        if (Instance != null) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
        
        DontDestroyOnLoad(this);
    }

    public void StartDialogue(DialogNodeGraph dialogue)
    {
        _dialogBehaviour.BindExternalFunction("Manic", ManicResponse);
        _dialogBehaviour.BindExternalFunction("Depress", DepressResponse);

        _dialogBehaviour.StartDialog(dialogue);
    }

    public void ManicResponse()
    {
        _player.ManicMood();
    }

    public void DepressResponse()
    {
        _player.DepressMood();
    }
}
