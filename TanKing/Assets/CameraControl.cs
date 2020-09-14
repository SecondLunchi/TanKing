using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraControl : MonoBehaviour {
    public Camera cam;

    //カメラのターゲット
    public List<GameObject> targets;

    public Vector3 offset;
    public float smoothTime = 0.5f;

    public float minZoom = 40;
    public float maxZoom = 10;
    public float zoomLimiter = 50;

    private Vector3 velocity;

    private void Start() {
        //指定タグ(配列)をターゲットに追加
    }

    private void Update() {
        targets.AddRange(GameObject.FindGameObjectsWithTag("Soccer"));
        targets.AddRange(GameObject.FindGameObjectsWithTag("Tank"));
        if (Goal.RemoveList) {
            targets = new List<GameObject>();
           
            Goal.RemoveList = false;
        }
    }

    private void Reset() {
        cam = GetComponent<Camera>();
    }

    private void LateUpdate() {
        if (targets.Count == 0) return;

        Move();
        Zoom();
    }

    private void Zoom() {
        var newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / zoomLimiter);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
    }

    private void Move() {
        var centerPoint = GetCenterPoint();
        var newPosition = centerPoint + offset;
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    private float GetGreatestDistance() {
        var bounds = new Bounds(targets[0].transform.position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++) {
            bounds.Encapsulate(targets[i].transform.position);
        }
        return bounds.size.x;
    }

    private Vector3 GetCenterPoint() {
        if (targets.Count == 1) return targets[0].transform.position;
        var bounds = new Bounds(targets[0].transform.position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++) {
            bounds.Encapsulate(targets[i].transform.position);
        }
        return bounds.center;
    }
}