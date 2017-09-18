using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour {

    [SerializeField] GameObject cameraOne;
    [SerializeField] GameObject cameraTwo;

    public bool cameraOneOn = true;
    public bool cameraTwoOn = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && cameraOneOn == true)
        {
            cameraTwo.SetActive(true);
            cameraOne.SetActive(false);

            cameraOneOn = false;
            cameraTwoOn = true;
        }
        else if (other.gameObject.tag == "Player" && cameraTwoOn == true)
        {
            cameraOne.SetActive(true);
            cameraTwo.SetActive(false);

            cameraTwoOn = false;
            cameraOneOn = true;
        }
    }
}
