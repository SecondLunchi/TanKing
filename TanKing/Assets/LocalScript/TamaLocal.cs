using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamaLocal : MonoBehaviour {

    //Tamaバウンド回数
    public int TamaBound = 1;

    ParticleSystem Particle;

    GameObject MeTank;

    // Start is called before the first frame update
    void Start() {
        Particle = GetComponent<ParticleSystem>();

    }

    // Update is called once per frame
    void Update() {

    }


    private void OnCollisionEnter(Collision collision) {

        MeTank = collision.gameObject;

        if (collision.gameObject.tag == "Wall") {
            Particle.Play();
            if (TamaBound > 0) {
                TamaBound--;
            } else {
                Destroy(this.gameObject);
            }
        } else if (collision.gameObject.tag == "Tank" && collision.gameObject != MeTank) {
            Particle.Play();
            //Destroy(collision.gameObject);
            Destroy(this.gameObject);
        } else if (collision.gameObject.tag == "Soccer") {
            Particle.Play();
            Destroy(this.gameObject);
        }

    }
}

