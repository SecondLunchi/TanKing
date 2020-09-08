﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamaCol : MonoBehaviour {

    //Tamaバウンド回数
    public int TamaBound = 1;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }


    private void OnCollisionEnter(Collision collision) {

        if (collision.gameObject.tag == "Wall") {
            if (TamaBound > 0) {
                TamaBound = 0;
            } else {
                Destroy(this);
            }
        }else if (collision.gameObject.tag == "Tank" && collision.gameObject.name != "TankRed") {
            Destroy(collision.gameObject);
            Destroy(this);
        }

    }
}
