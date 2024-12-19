using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CHMove : MonoBehaviour
{
    [Header("Positions and Settings")]
    public Transform[] waypoints; // �̵��� ��ġ ����Ʈ (Empty ������Ʈ���� �巡���ؼ� ����)
    public float moveDuration = 2.0f; // �� ������ �̵� �ð�
    public float waitDuration = 1.0f; // �� ��ġ���� ��� �ð�
    public Ease easeType = Ease.Linear; // �������� ���ӵ� Ÿ��
    public bool rotateTowardsNext = true; // �̵��ϸ鼭 ȸ�� ����

    public float slowerMoveDuration = 10.0f; // 'furniture' �±׸� ���� ������Ʈ�� �̵� �ð� (������)

    private void Start()
    {
        if (waypoints.Length > 0)
        {
            StartCoroutine(MoveThroughWaypoints());
        }
        else
        {
            Debug.LogError("No waypoints set!");
        }
    }

    private IEnumerator MoveThroughWaypoints()
    {
        // �±װ� "furniture"�� ��� �̵� �ӵ��� ������ ����
        float actualMoveDuration = (CompareTag("furniture")) ? slowerMoveDuration : moveDuration;

        for (int i = 0; i < waypoints.Length; i++)
        {
            // �̵��ϱ� ����, ��ǥ ������Ʈ�� rotation�� �״�� ���󰡵��� ȸ��
            if (rotateTowardsNext && i < waypoints.Length - 1)
            {
                Quaternion targetRotation = waypoints[i + 1].rotation; // ��ǥ ������Ʈ�� ȸ���� �״�� ���

                // ȸ�� �ִϸ��̼� (ȸ�� �ð� ���� �ε巴�� ȸ��)
                yield return transform.DORotateQuaternion(targetRotation, actualMoveDuration / 2).SetEase(Ease.Linear).WaitForCompletion();
            }

            // ���� ��ġ�� �̵�
            yield return transform.DOMove(waypoints[i].position, actualMoveDuration)
                .SetEase(easeType)
                .WaitForCompletion();

            // ������ ��ġ�� �ƴϸ� ��� �ð� ����
            if (i < waypoints.Length - 1)
            {
                yield return new WaitForSeconds(waitDuration);
            }
        }

        // ������ ��ġ�� ������ �� �̵� ����
        transform.DOKill(); // ��� Ʈ�� ����
    }
}
