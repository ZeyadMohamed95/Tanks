using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomspawn : MonoBehaviour {
    public GameObject PickUP;
    public float StartWait;

    private Vector3 pos;
    private MeshRenderer rend;
	// Use this for initialization
	void Start ()
    {
        rend = PickUP.GetComponentInChildren<MeshRenderer>(); 
        rend.enabled = false;
        
	}
	
    void Update()
    {
        StartCoroutine(SpawningFunction());
    }
	
	IEnumerator SpawningFunction()
    {
        yield return new WaitForSeconds(StartWait);
        if (rend.enabled==false)
        {
            rend.enabled = true;
            print("Coroutine ended: ");
            // x between -40 and 40 and z between -40 and 40 y = .6
            pos = new Vector3(Random.Range(-40f, 40f), 0.6f, Random.Range(-40f, 40f));
            PickUP.transform.position = pos;
        }

    }
}
