using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class TestBu : MonoBehaviourPunCallbacks{


    public void TankRedSummon() {
        GameObject TankRed = PhotonNetwork.Instantiate("TankRed", new Vector3(7, 1.4f, 0), Quaternion.Euler(0, -90, 0), 0);
        TankControl tankControl = TankRed.GetComponent<TankControl>();
        tankControl.enabled = true;
    }
    public void TankBlueSummon() {
        GameObject TankBlue = PhotonNetwork.Instantiate("TankBlue", new Vector3(-7, 1.4f, 0), Quaternion.Euler(0, 90, 0), 0);
        TankControl tankControl = TankBlue.GetComponent<TankControl>();
        tankControl.enabled = true;
    }

}
