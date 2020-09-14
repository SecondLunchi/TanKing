using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Tama : MonoBehaviourPunCallbacks {

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

        if (collision.gameObject.tag == "Wall") {
            Particle.Play();
            if (TamaBound > 0) {
                TamaBound--;
            } else {
                PhotonNetwork.Destroy(this.gameObject);
            }
        /*} else if (collision.gameObject.tag == "Tank" && collision.gameObject != ) {
            Particle.Play();
            //Destroy(collision.gameObject);
            PhotonNetwork.Destroy(this.gameObject);
            */
        } else if (collision.gameObject.tag == "Soccer") {
            Particle.Play();
            PhotonNetwork.Destroy(this.gameObject);
        }

    }
}

