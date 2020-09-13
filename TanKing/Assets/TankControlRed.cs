using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControlRed : MonoBehaviour {

    //発射するtama
    public GameObject tama;
    //tamaの位置調整に
    public Transform muzzle;
    //発射効果音
    public AudioClip ShotSE;
    AudioSource audioSource;

    ParticleSystem Particle;

    //tamaの速度、発射感覚
    [Range(1, 12)]
    public float TamaSpeed = 6.0f;
    [Range(0.1f, 5)]
    public float TamaDelay = 3.0f;
    float tamadelay;

    //Tankの移動速度、回転速度
    [Range(0, 10)]
    public float TankSpeed = 5f;
    [Range(0, 10)]
    public float RotateSpeed = 5f;

    //発射後反動時間
    [Range(0, 5)]
    public float HandouRange = 2f;


    void Start() {
        //コンポーネントを取得
        audioSource = GetComponent<AudioSource>();
        Particle = GetComponent<ParticleSystem>();
        tamadelay = TamaDelay;
    }


    void Update() {
        //一定間隔のTama連射

        tamadelay += Time.deltaTime;
        Move();
    }


    //Tamaの発射関数
    void Shot() {
        //Tamaを複製
        GameObject tamas = Instantiate(tama) as GameObject;

        //操作オブジェクトの前方向に速度を掛ける
        Vector3 force;
        force = this.gameObject.transform.forward * TamaSpeed * 100;

        //力を加えて発射、及び位置の調整
        //向き変更時tamas.transform.LookAt(transform.forward);
        tamas.transform.position = muzzle.position;
        tamas.GetComponent<Rigidbody>().AddForce(force);

        //射撃音
        audioSource.PlayOneShot(ShotSE);

        Particle.Play();
    }

    //TankのMove関数
    void Move() {
        if (Input.GetKey(KeyCode.RightArrow)) {
            this.transform.Rotate(0, RotateSpeed * 10 * Time.deltaTime, 0);
        } else if (Input.GetKey(KeyCode.LeftArrow)) {
            this.transform.Rotate(0, -(RotateSpeed * 10 * Time.deltaTime), 0);
        } else if (Input.GetKey(KeyCode.UpArrow)) {
            this.transform.Translate(0, 0, TankSpeed * Time.deltaTime);
        } else if (Input.GetKey(KeyCode.DownArrow)) {
            this.transform.Translate(0, 0, -(TankSpeed * Time.deltaTime));
        } else if (Input.GetKey(KeyCode.RightShift)) {
            while (Input.GetKey(KeyCode.RightShift) && TamaDelay - tamadelay <= 0) {
                Shot();
                gameObject.GetComponent<Rigidbody>().AddForce(-transform.forward * HandouRange * 100);
                tamadelay = 0;
            }
        }

    }
}


