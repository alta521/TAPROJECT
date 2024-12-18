using UnityEngine;
using DG.Tweening; // Dotween ���ӽ����̽�

public class rotcha : MonoBehaviour
{
    void Start()
    {
        int numPoints = 100; 
        float radius = 5f;   
        Vector3[] path = new Vector3[numPoints];

        
        for (int i = 0; i < numPoints; i++)
        {
            float angle = (float)i / numPoints * 2 * Mathf.PI; 
            path[i] = new Vector3(Mathf.Cos(angle) * radius, 0, Mathf.Sin(angle) * radius);
        }

        
        Sequence sequence = DOTween.Sequence();

        
        sequence.Append(transform.DOPath(path, 10f, PathType.Linear)
            .SetEase(Ease.Linear));

       
        sequence.Append(transform.DOMoveY(10f, 3f).SetEase(Ease.OutQuad));

        //�ݺ��ϸ� �ȵ�. �� �ڵ�� �� ���ö��� Ȯ���ϱ�.
        //sequence.SetLoops(-1, LoopType.Restart);
    }
}
