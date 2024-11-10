using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public GameObject IK_LFoot;
    public GameObject IK_RFoot;
    // Start is called before the first frame update
    void Start()
    {
        //IK_LFoot = GetComponent<GameObject>();
       // IK_RFoot = GetComponent<GameObject>();
    }
    private void FixedUpdate()
    {
        RaycastHit hit;
        float maxDist = 1.0f;

        if (Physics.Raycast(transform.position, transform.TransformDirection(-1.0f * Vector3.up), out hit, maxDist))
        {
            GameObject go = hit.collider.gameObject;
            if (go != null)
            {
                if (go != this.gameObject)
                {
                    //go.SetActive(false);
                    IK_LFoot.transform.position = (go.transform.position + new Vector3(-1,0,0));
                    IK_RFoot.transform.position = (go.transform.position + new Vector3(-1, 0, 0)); ;
                    Debug.Log("Raycast");
                }
            }
        }
    }
}