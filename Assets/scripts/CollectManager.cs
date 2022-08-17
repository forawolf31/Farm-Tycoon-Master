using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectManager : MonoBehaviour
{
    public Transform depo1;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "collect")
        {
            other.transform.localPosition = depo1.localPosition;
            other.GetComponent<MisirHareketi>().Toplandi = true;
        }
    }
}
