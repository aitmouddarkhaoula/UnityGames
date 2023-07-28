using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDifficulty : MonoBehaviour
{

    [SerializeField] Button easyButton, mediumButton, hardButton;
    [SerializeField] GameObject startMenu;
    public GameManagerF gameManagerF;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerF= GameObject.FindObjectOfType<GameManagerF>().GetComponent<GameManagerF>();
        easyButton.onClick.AddListener(()=>SetDifficulty(1));
        mediumButton.onClick.AddListener(()=>SetDifficulty(2));
        hardButton.onClick.AddListener(()=>SetDifficulty(4));
    }
    public void SetDifficulty(int difficulty)
    {
        startMenu.gameObject.SetActive(false);
        gameManagerF.StartGame(difficulty);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
