using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DeadMenuControl : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public MenuController menuController;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggleDeadMenu(int score){
        gameObject.SetActive(true);
        scoreText.text = "YOUR SCORE:\n"+ score.ToString();

    }
}
