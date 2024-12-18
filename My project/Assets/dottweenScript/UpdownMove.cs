using UnityEngine;
using DG.Tweening; // Dotween 네임스페이스

public class UpdownMove : MonoBehaviour
{
    public float want;
    public float speed;
    void Start()
    {
        // 오브젝트를 3초 동안 위에서 아래로 (Y축 0) 이동
        transform.DOMoveY(want, speed).SetEase(Ease.Linear);
    }
}
