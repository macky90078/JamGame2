using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPController : MonoBehaviour {

    [SerializeField] Image healthBar;

    PlayerMovement playerScript;
    public GameObject playerObj;

    private void Awake()
    {
        playerScript = playerObj.GetComponent<PlayerMovement>();
    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        healthBar.fillAmount = playerScript.playerHealth;

    }
}
