using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Goal : MonoBehaviourPunCallbacks {

    //UIのスコアオブジェクト
    public GameObject AiteScoreObject;

    //ゴール点数
    int Goals = 0;

    //ボール
    public GameObject SoccerBall;

    //待機時間(s)
    [Range(0,5)]
    public float SummonTime = 2.5f;
    float summontime;

    bool summon;

    public static bool RemoveList;

    void Start() {

    }

    void Update() {

        //Summon処理
        if (summon) {
            summontime += Time.deltaTime;
            if (summontime >= SummonTime) {
                PhotonNetwork.Instantiate(SoccerBall.name, new Vector3(0, 8.5f), Quaternion.identity);
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
        PhotonView.Destroy(x);
        RemoveList = true;
        summon = true;
    }
}