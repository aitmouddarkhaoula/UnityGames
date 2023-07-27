using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManagerF : MonoBehaviour
{
    public List<GameObject> targets;
    public int score;
    [SerializeField] private TextMeshProUGUI _scoreText;
    // Start is called before the first frame update
    void Start(){
        InvokeRepeating("SpawnRandomTargets", 1, 1.5f);
        score = 0;
        _scoreText.text = "Score: " + score;
    }

    public void SpawnRandomTargets()
    {
        GameObject newTarget = targets[Random.Range(0, targets.Count)];
        Instantiate(newTarget, RandomPositions(), Quaternion.identity);
        
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        _scoreText.text = "Score: " + score;
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
