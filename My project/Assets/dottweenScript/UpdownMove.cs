using UnityEngine;
using DG.Tweening; // Dotween ���ӽ����̽�

public class UpdownMove : MonoBehaviour
{
    public float want;
    public float speed;
    void Start()
    {
        // ������Ʈ�� 3�� ���� ������ �Ʒ��� (Y�� 0) �̵�
        transform.DOMoveY(want, speed).SetEase(Ease.Linear);
    }
}
