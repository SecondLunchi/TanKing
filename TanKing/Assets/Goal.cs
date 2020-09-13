using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour {

    //UIのスコアオブジェクト
    public GameObject AiteScoreObject;

    //ゴール点数
    int Goals = 0;

    //ボール
    GameObject SoccerBall;

    //待機時間(s)
    [Range(0,5)]
    public float SummonTime = 2.5f;
    float summontime;

    bool summon;

    void Start() {
        SoccerBall = GameObject.FindGameObjectWithTag("Soccer");

    }

    void Update() {

        //Summon処理
        if (summon) {
            summontime += Time.deltaTime;
            if (summontime >= SummonTime) {
                SoccerBall.SetActive(true);
                SoccerBall.transform.position = new Vector3(0, 8.5f);
                summontime = 0;
                summon = false;
            }
        }

    }

    private void OnCollisionEnter(Collision collision) {
        //パルクール追加しろ
        //
        //

        //ボールと衝突したら
        if (collision.gameObject.tag == "Soccer") {

            Goals += 1;

            //スコアオブジェクトにゴール点数を加算
            Text ScoreText = AiteScoreObject.GetComponent<Text>();
            ScoreText.text = Goals.ToString();
            BallSyori(collision.gameObject);
        }

    }

    void BallSyori(GameObject x) {
        x.GetComponent<Rigidbody>().velocity = Vector3.zero;
        SoccerBall.SetActive(false);
        summon = true;
    }
}