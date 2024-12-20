using UnityEngine;
using DG.Tweening; 

public class UpdownMove : MonoBehaviour
{
    public float want;  // ��ǥ ��ġ (Y��)
    public float speed; // �̵� �ӵ�

    void Start()
    {
        // Y�� �̵�
        transform.DOMoveY(want, speed).SetEase(Ease.Linear);

        // Z�� ȸ�� (10�� ȸ��)
        transform.DORotate(new Vector3(0, 0, 10), speed, RotateMode.FastBeyond360).SetEase(Ease.Linear);
    }
}

