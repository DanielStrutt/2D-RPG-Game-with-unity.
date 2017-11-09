using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DialogueManager : MonoBehaviour {

    public GameObject dBox;
    public Text dText;

    public bool dialogeActive;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (dialogeActive && (Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.Mouse0)))
        {
            dBox.SetActive(false);
            dialogeActive = false;
        }
    }

    public void ShowBox(string dialogue)
    {
        dialogeActive = true;
        dBox.SetActive(true);
        dText.text = dialogue;
    }
}
