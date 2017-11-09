using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public Slider healthbar;
    public Text HPText;
    public PlayerHealthManager playerHealth;

    private PlayerStats thePS;//thePS = The player's stats

    private static bool UIExists;
    public Text levelText;

	// Use this for initialization
	void Start () {

        if (!UIExists)
        {
            UIExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        thePS = GetComponent<PlayerStats>();

    }
	
	// Update is called once per frame
	void Update () {
        healthbar.maxValue = playerHealth.playerMaxHealth;
        healthbar.value = playerHealth.playerCurrentHealth;
        HPText.text = "Health  " + playerHealth.playerCurrentHealth + "/" + playerHealth.playerMaxHealth;
        levelText.text = "Level: " + thePS.currentLevel;
	}
}
