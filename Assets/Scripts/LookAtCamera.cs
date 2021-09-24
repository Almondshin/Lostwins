using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public GameObject Player;
    public Transform target;
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        // transform.LookAt(target, Vector3.zero); -> Ÿ���� ���� XYZ�� ���� ������
        // transform.position = target.transform.position; -> ���� position Z��  -1�� �ְ������ �ϴ� ����� �𸣰���
        transform.position = Player.transform.position + new Vector3(0,0,-1);

    }
}   
