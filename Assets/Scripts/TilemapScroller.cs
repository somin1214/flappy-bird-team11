using UnityEngine;

public class TilemapScroller : MonoBehaviour
{
    [Header("Scroll Settings")]
    public float scrollSpeed = 2f;
    public bool autoScroll = true;

    [Header("Loop Settings")]
    public float resetPositionX = -20f; // 이 위치에 도달하면
    public float startPositionX = 0;   // 여기로 리셋

    [Header("Gizmo Settings")]
    public bool showGizmos = true;
    public float gizmoHeight = 10f; // Gizmo 선의 높이
    public Color resetColor = Color.red;
    public Color startColor = Color.green;

    void Update()
    {
        if (autoScroll)
        {
            // 왼쪽으로 스크롤
            transform.position += Vector3.left * scrollSpeed * Time.deltaTime;

            // 무한 루프
            if (transform.position.x <= resetPositionX)
            {
                Vector3 pos = transform.position;
                pos.x = startPositionX;
                transform.position = pos;
            }
        }
    }

    // Scene 뷰에서 Gizmo 그리기
    void OnDrawGizmos()
    {
        if (!showGizmos) return;

        float yPos = transform.position.y;

        // Reset Position 선 (초록색)
        Gizmos.color = resetColor;
        Vector3 resetTop = new Vector3(resetPositionX, yPos + gizmoHeight / 2, 0);
        Vector3 resetBottom = new Vector3(resetPositionX, yPos - gizmoHeight / 2, 0);
        Gizmos.DrawLine(resetTop, resetBottom);

        // Start Position 선 (초록색)
        Gizmos.color = startColor;
        Vector3 startTop = new Vector3(startPositionX, yPos + gizmoHeight / 2, 0);
        Vector3 startBottom = new Vector3(startPositionX, yPos - gizmoHeight / 2, 0);
        Gizmos.DrawLine(startTop, startBottom);

        // 화살표 그리기 (Reset -> Start)
        Gizmos.color = Color.yellow;
        Vector3 arrowStart = new Vector3(resetPositionX, yPos, 0);
        Vector3 arrowEnd = new Vector3(startPositionX, yPos, 0);
        Gizmos.DrawLine(arrowStart, arrowEnd);

        // ȭ��ǥ �� ǥ��
        Vector3 arrowTip1 = arrowEnd + new Vector3(-0.5f, 0.5f, 0);
        Vector3 arrowTip2 = arrowEnd + new Vector3(-0.5f, -0.5f, 0);
        Gizmos.DrawLine(arrowEnd, arrowTip1);
        Gizmos.DrawLine(arrowEnd, arrowTip2);
    }

    // ���õǾ��� ���� Gizmo �׸��� (�� �����ϰ�)
    void OnDrawGizmosSelected()
    {
        if (!showGizmos) return;

        float yPos = transform.position.y;

        // Reset Position ���� ǥ��
        Gizmos.color = new Color(resetColor.r, resetColor.g, resetColor.b, 0.3f);
        Vector3 resetBoxCenter = new Vector3(resetPositionX, yPos, 0);
        Gizmos.DrawCube(resetBoxCenter, new Vector3(0.5f, gizmoHeight, 0.1f));

        // Start Position ���� ǥ��
        Gizmos.color = new Color(startColor.r, startColor.g, startColor.b, 0.3f);
        Vector3 startBoxCenter = new Vector3(startPositionX, yPos, 0);
        Gizmos.DrawCube(startBoxCenter, new Vector3(0.5f, gizmoHeight, 0.1f));
    }
}