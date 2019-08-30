using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picking : MonoBehaviour {
    private TankMovement m_tankMovement;
    private bool isActive = false;
    private MeshRenderer rend;

    void Awake()
    {
        rend = GetComponentInChildren<MeshRenderer>(); 
    }
	// Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        m_tankMovement = other.GetComponent<TankMovement>();
        if (m_tankMovement != null && isActive == false)
        {
            isActive = true;
            StartCoroutine(PowerUpWearOff(5.0f));
        }
        rend.enabled = false;
    }
    IEnumerator PowerUpWearOff(float waitTime)
    {
        m_tankMovement.m_Speed *= 2.0f;
        yield return new WaitForSeconds(waitTime);
        m_tankMovement.m_Speed *= 0.5f; // remove boost
        
        isActive = false;
        //print("Coroutine ended: " + Time.time + " seconds");
    }
}
