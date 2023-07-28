using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManagerF : MonoBehaviour
{
    public List<GameObject> targets;
    public int score;
    public float repeatRate=1f;
    public bool _isGameActive = true;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] Button restartButton;
    [SerializeField] GameObject startMenu;
    // Start is called before the first frame update
    public void StartGame(int Difficulty){
        _isGameActive = true;
        startMenu.gameObject.SetActive(false);
        InvokeRepeating("SpawnRandomTargets",0, repeatRate/ Difficulty);
        score = 0;
        UpdateScore(0);
    }

    private void Start()
    {
        _gameOverScreen.gameObject.SetActive(false);
        restartButton.onClick.AddListener(()=>
        {
            _gameOverScreen.gameObject.SetActive(false);
            startMenu.gameObject.SetActive(true);
            
        });
    }

    public void SpawnRandomTargets()
    {
        if(!_isGameActive)
        {
            return;
        }
        GameObject newTarget = targets[Random.Range(0, targets.Count)];
        Instantiate(newTarget, RandomPositions(), Quaternion.identity);
        
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        _scoreText.text = "Score: " + score;
    }
    public void GameOver()
    {
        _gameOverScreen.gameObject.SetActive(true);
        _isGameActive = false;
        CancelInvoke("SpawnRandomTargets");

    }

    public Vector3 RandomPositions()
    {
        float xPos=Random.Range(-4,4);
        float yPos=Random.Range(-4,4);
        Vector3 randomPos=new Vector3(xPos,yPos,0);
        return randomPos;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
