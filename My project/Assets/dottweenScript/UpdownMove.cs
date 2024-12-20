using UnityEngine;
using DG.Tweening; 

public class UpdownMove : MonoBehaviour
{
    public float want;  // 목표 위치 (Y축)
    public float speed; // 이동 속도

    void Start()
    {
        // Y축 이동
        transform.DOMoveY(want, speed).SetEase(Ease.Linear);

        // Z축 회전 (10도 회전)
        transform.DORotate(new Vector3(0, 0, 10), speed, RotateMode.FastBeyond360).SetEase(Ease.Linear);
    }
}

