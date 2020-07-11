using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private Button buttonJugar;

    void Start()
    {
        buttonJugar.onClick.AddListener(() => goSeleccion());
    }

    void goSeleccion() {
        SceneManager.LoadScene("Seleccion");
    }
}
