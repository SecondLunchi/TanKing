using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveKey : MonoBehaviour {

    public float TankSpeed = 0.05f;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.A)) {
            this.transform.Rotate(0, -0.5f, 0);
        }
        else if (Input.GetKey(KeyCode.D)) {
            this.transform.Rotate(0, 0.5f, 0);
        }
        else if (Input.GetKey(KeyCode.W)) {
            this.transform.Translate(0, 0, TankSpeed);
        }else if (Input.GetKey(KeyCode.S)) {
            this.transform.Translate(0, 0, -TankSpeed);
        }
    }
}
