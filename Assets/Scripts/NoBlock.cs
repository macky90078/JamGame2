using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoBlock : MonoBehaviour {

    public Animator animator;
    public bool canBlock = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NoBlock")
        {
            canBlock = false;
            animator.SetBool("CombatIdle", false);
        }
    }
}
