using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public static GameController instance;
    [SerializeField]
    private Text textScore;
    [SerializeField]
    private Text textLifes;
    [SerializeField]
    private Text textMaxScore;
    private int maxScore;
    private int lifes;
    private int score;
    [SerializeField]
    private List<GameObject> waveList;

    //private float maxScore;

    void createSingleton() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        }
        instance = this;
    }

    public void startWave(int n) {
        waveList[n].GetComponent<WaveController>().hasStarted = true;
    }

    private void Awake()
    {
        createSingleton();
    }

    public void addToScore(int n) {
        score += n;
        textScore.text = "Score: " + score.ToString();
    }

    void Start()
    {
        lifes = PlayerPrefs.GetInt("Lifes");
        
        textLifes.text = "Lifes: " + lifes.ToString();
        maxScore = PlayerPrefs.GetInt("MaxScore");
        textMaxScore.text = "MaxScore: " + maxScore.ToString();
    }

    public void loseLife() {
        lifes--;
        if (lifes == 0) {
            PlayerPrefs.SetInt("Score", score);
            if (score > maxScore) {
                print("SE CAMBIA EL MAXSCOREEEEEEEEEE");
                maxScore = score;
            }
            PlayerPrefs.SetInt("MaxScore", maxScore);
            SceneManager.LoadScene("GameOver");
        }
        textLifes.text = "Lifes: " + lifes.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
