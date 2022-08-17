using System;
using System.Collections;
using System.Timers;
using DG.Tweening;
using UnityEngine;
public class CarManager : MonoBehaviour
{
    [SerializeField] private CharacterController Controller;
    private Joystick joy;
    public int carSpeed=5;
    private static float xMove, zMove;
    [SerializeField] private GameObject[] tekerlek;
    [SerializeField] private GameObject depo;
    

    private void OnEnable()
    {
        joy = FindObjectOfType<Joystick>();
        StartCoroutine(startDrive());
    }
    IEnumerator startDrive()
    {
        joy = FindObjectOfType<Joystick>();
        yield return new WaitForSeconds(1);
    }
    private void Start()
    {
        joy = FindObjectOfType<Joystick>();
    }
    
    private void Update()
    {
        playerMovementControler();
        playerRotationControler();
      //  depo.transform.DOLocalRotateQuaternion(this.transform.rotation, 5f);
    }
    void playerMovementControler()
    {
        xMove = joy.Horizontal;// + joystek.Horizontal;
        zMove = joy.Vertical;// + joystek.Vertical;
        float gravity = 9.8f;
        if (xMove != 0)
        {
            foreach (var VARIABLE in tekerlek)
            {
                VARIABLE.transform.Rotate(0, 0, 0 * Time.deltaTime);
            }
        }
       
        Vector3 moveAxis = new Vector3(xMove, -gravity, zMove);
        Controller.Move(((moveAxis) * carSpeed * Time.deltaTime));
    }
    void playerRotationControler()
    {
        Vector3 NextDir = new Vector3(xMove, 0, zMove);
        if (NextDir != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(NextDir);
    }
    
   
}
