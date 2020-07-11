using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SeleccionController : MonoBehaviour
{
    [SerializeField]
    private Button buttonNormal;
    [SerializeField]
    private Button buttonParaoSinPolo;

    void Start()
    {
        buttonNormal.onClick.AddListener(() => goNormal());
        buttonParaoSinPolo.onClick.AddListener(() => goParaoSinPolo());
    }

    void goNormal()
    {
        PlayerPrefs.SetInt("Lifes", 4);
        SceneManager.LoadScene("Game");
    }
    void goParaoSinPolo()
    {
        PlayerPrefs.SetInt("Lifes", 1);
        SceneManager.LoadScene("Game");
    }
}
