using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour {

    //UIのスコアオブジェクト
    public GameObject AiteScoreObject;

    //ゴール点数
    int Goals = 0;

    //複製するボール
    public GameObject SoccerBall;

    //ボールの消滅と生成の時間
    public float DesTime = 1.5f;
    public float SummonTime = 1.5f;
    float Destime = 0;
    float Summontime = 0;

    void Start() {

    }

    void Update() {
        Destime += Time.deltaTime;
        Summontime += DesTime + Time.deltaTime;

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
        Destime = 0;
        Summontime = 0;
        //while (DesTime - Destime <= 0) {
            Destroy(x);
           // Destime = 0;
       // }
       // while (SummonTime - Summontime <= 0) {
            GameObject SoccerBalls = Instantiate(SoccerBall) as GameObject;
            //Summontime = 0;
       // }
        
    }
}