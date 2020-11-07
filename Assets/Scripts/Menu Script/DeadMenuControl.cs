﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DeadMenuControl : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public MenuController menuController;
    public Button PauseButton;
    public GameObject deadMenu;
    public Pacman pacman;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {   

        if(gameObject.active){
            PauseButton.interactable = false;
        }
        
    }

    public void toggleDeadMenu(int score){
        Debug.Log(score);
        gameObject.SetActive(true);
        scoreText.text = "YOUR SCORE:\n"+ score.ToString();

    }
}
