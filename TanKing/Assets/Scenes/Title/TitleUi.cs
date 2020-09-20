using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class TitleUi : MonoBehaviour {

    GameObject Title;
    bool presstoanykey = true;

    private void Start() {
        //Tile表示
        Title = GameObject.Find("Title");
        Title.SetActive(false);
    }

    private void Update() {
        if (Input.GetKey(KeyCode.A) || presstoanykey) {
            PressToAnyKey();
            presstoanykey = false;
        }
    }

    public void PressToAnyKey() {
        Title.SetActive(true);
        GameObject.Find("PressToAnyKey").SetActive(false);
    }

    public void SoccerStart() {
        SceneManager.LoadScene("Soccer");
    }



}
