﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour {
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start() {
        agent = this.GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update() {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
                agent.destination = hit.point;
            }

        
    }
}