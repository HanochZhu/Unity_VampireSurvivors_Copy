using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    /*
     * ����
     * ��ѱ�
     * ����
     * ���� ������
     * ����
     */

    void Start()
    {
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {

        yield return null;
    }
}