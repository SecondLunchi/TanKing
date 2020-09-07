using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamaCol : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }


    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Wall") {
            Destroy(this.gameObject);
        }else if(collision.gameObject.tag == "Tank" && collision.gameObject.name != "TankRed" ) {
            Destroy(collision.gameObject);
        }
    }
}
