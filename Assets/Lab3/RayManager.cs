using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RayManager : MonoBehaviour
{
    [SerializeField] GameObject Target;
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        SetTarget();
    }

    void SetTarget()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Target.transform.position = hit.point;
            }
        }

    }
}
