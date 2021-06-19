using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class StartPaused : MonoBehaviour
{
    // This entire script just makes sure you have to enter a name before hand this ensures that data is saving... just a helper really
    public GameObject deathCanvas;
    public GameObject nameField;
    private TMP_InputField _textInput;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == nameField) // we can use events to figure out if the player is typing out and doing the things
        {
            _textInput = nameField.GetComponent<TMP_InputField>(); 

            if (Input.GetKeyUp(KeyCode.Return) && _textInput.text != null) // like so ^
            {
                StartGame();
            }
        }
    }

    private void StartGame()
    {
        Debug.Log(("StartGame()"));
        deathCanvas.SetActive(false);
        Time.timeScale = 1;
    }
}
