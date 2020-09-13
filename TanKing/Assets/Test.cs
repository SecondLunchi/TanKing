using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Test : MonoBehaviourPunCallbacks{

    private void Start() {
        //PhotonServerSettingの設定内容で接続するよって文
        PhotonNetwork.ConnectUsingSettings();

        if (string.IsNullOrEmpty(PhotonNetwork.NickName)) {
            PhotonNetwork.NickName = "player" + Random.Range(1, 99999);
        }
    }

    // マスターサーバーに接続できたら呼ばれるやつ
    public override void OnConnectedToMaster() {
        //"room"に参加する、なかったら作る
        PhotonNetwork.JoinOrCreateRoom("room", new RoomOptions(), TypedLobby.Default);
    }

    //room入ったら呼ばれるよ
    public override void OnJoinedRoom() {
        Debug.Log("test");

    }

}
