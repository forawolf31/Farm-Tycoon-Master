using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DepoManager : MonoBehaviour
{
    public int maxDepoDeger;
    public int DepoDeger;
    public GameObject DepoGameObject;

    private float _depoDeger;
    void LateUpdate()
    {
        _depoDeger = (0.10f / maxDepoDeger) * DepoDeger;
        DepoGameObject.transform.DOScaleY(_depoDeger, Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("collect"))
        {
            other.transform.DOLocalMoveY(3, 0.05f).OnComplete(() =>
            {
                other.transform.DOLocalMove(DepoGameObject.transform.position, 0.05f).OnComplete(() =>
                {
                    DepoDeger++;
                    Destroy(other.gameObject);
                });
            });
        }
    }
}
