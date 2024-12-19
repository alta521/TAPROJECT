using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CHMove : MonoBehaviour
{
    [Header("Positions and Settings")]
    public Transform[] waypoints; // 이동할 위치 리스트 (Empty 오브젝트들을 드래그해서 설정)
    public float moveDuration = 2.0f; // 각 구간의 이동 시간
    public float waitDuration = 1.0f; // 각 위치에서 대기 시간
    public Ease easeType = Ease.Linear; // 움직임의 가속도 타입
    public bool rotateTowardsNext = true; // 이동하면서 회전 여부

    public float slowerMoveDuration = 10.0f; // 'furniture' 태그를 가진 오브젝트의 이동 시간 (느리게)

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
        // 태그가 "furniture"일 경우 이동 속도를 느리게 설정
        float actualMoveDuration = (CompareTag("furniture")) ? slowerMoveDuration : moveDuration;

        for (int i = 0; i < waypoints.Length; i++)
        {
            // 이동하기 전에, 목표 오브젝트의 rotation을 그대로 따라가도록 회전
            if (rotateTowardsNext && i < waypoints.Length - 1)
            {
                Quaternion targetRotation = waypoints[i + 1].rotation; // 목표 오브젝트의 회전을 그대로 사용

                // 회전 애니메이션 (회전 시간 동안 부드럽게 회전)
                yield return transform.DORotateQuaternion(targetRotation, actualMoveDuration / 2).SetEase(Ease.Linear).WaitForCompletion();
            }

            // 현재 위치로 이동
            yield return transform.DOMove(waypoints[i].position, actualMoveDuration)
                .SetEase(easeType)
                .WaitForCompletion();

            // 마지막 위치가 아니면 대기 시간 적용
            if (i < waypoints.Length - 1)
            {
                yield return new WaitForSeconds(waitDuration);
            }
        }

        // 마지막 위치에 도달한 후 이동 멈춤
        transform.DOKill(); // 모든 트윈 종료
    }
}
