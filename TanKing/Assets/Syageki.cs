using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Syageki : MonoBehaviour {

    public GameObject tama;

    //tamaの位置調整に
    public Transform muzzle;

    //tamaの速度
    public float TamaSpeed = 100.0f;

    //tamaの発射間隔
    public float tamaDelay = 3.0f;

    public AudioClip BulletRazer;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start() {

        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.Space)) {
            Shot();
        }

    }

    void Shot() {
            //Tamaを複製
            GameObject tamas = Instantiate(tama) as GameObject;

            //操作オブジェクトの前方向に速度を掛ける
            Vector3 force;
            force = this.gameObject.transform.forward * TamaSpeed;

            //力を加えて発射、及び位置の調整
            //向き変更時tamas.transform.LookAt(transform.forward);
            tamas.transform.position = muzzle.position;
            tamas.GetComponent<Rigidbody>().AddForce(force);

            //射撃音
            //audioSource.PlayOneShot(BulletRazer);
        }
    }

