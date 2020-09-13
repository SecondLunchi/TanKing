using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamaRed : MonoBehaviour {

    //Tamaバウンド回数
    public int TamaBound = 1;

    ParticleSystem Particle;

    // Start is called before the first frame update
    void Start() {
        Particle = GetComponent<ParticleSystem>();

    }

    // Update is called once per frame
    void Update() {

    }


    private void OnCollisionEnter(Collision collision) {

        Particle.Play();

        if (collision.gameObject.tag == "Wall") {
            if (TamaBound > 0) {
                TamaBound --;
            } else {
                Destroy(this.gameObject);
            }
        }else if (collision.gameObject.tag == "Tank" && collision.gameObject.name != "TankRed") {
            //Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
        else if(collision.gameObject.tag == "Soccer") {
            Destroy(this.gameObject);
        }

    }
}
