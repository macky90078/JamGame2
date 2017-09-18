using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class equip : MonoBehaviour {

    public GameObject sword;
    public GameObject hand;

	// Use this for initialization

    private void Start()
    {
        sword.transform.parent = hand.transform;
        sword.transform.position = hand.transform.position;
        sword.transform.rotation = hand.transform.rotation;
    }

}
