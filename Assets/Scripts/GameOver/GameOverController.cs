using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{

    private float timer;
    public Text textScore;

    void Start()
    {
        timer = 0;
        textScore.text = "Score: " + PlayerPrefs.GetInt("Score").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 3) {
            SceneManager.LoadScene("Menu");
        }
    }
}
