using UnityEngine;

public class TilemapScroller : MonoBehaviour
{
    [Header("Scroll Settings")]
    public float scrollSpeed = 2f;
    public bool autoScroll = true;

    [Header("Loop Settings")]
    public float resetPositionX = -20f; // �� ��ġ�� �����ϸ�
    public float startPositionX = 0;   // ����� ����

    [Header("Gizmo Settings")]
    public bool showGizmos = true;
    public float gizmoHeight = 10f; // Gizmo ���� ����
    public Color resetColor = Color.red;
    public Color startColor = Color.green;

    void Update()
    {
        if (autoScroll)
        {
            // �������� ��ũ��
            transform.position += Vector3.left * scrollSpeed * Time.deltaTime;

            // ���� ����
            if (transform.position.x <= resetPositionX)
            {
                Vector3 pos = transform.position;
                pos.x = startPositionX;
                transform.position = pos;
            }
        }
    }

    // Scene �信�� Gizmo �׸���
    void OnDrawGizmos()
    {
        if (!showGizmos) return;

        float yPos = transform.position.y;

        // Reset Position �� (������)
        Gizmos.color = resetColor;
        Vector3 resetTop = new Vector3(resetPositionX, yPos + gizmoHeight / 2, 0);
        Vector3 resetBottom = new Vector3(resetPositionX, yPos - gizmoHeight / 2, 0);
        Gizmos.DrawLine(resetTop, resetBottom);

        // Start Position �� (�ʷϻ�)
        Gizmos.color = startColor;
        Vector3 startTop = new Vector3(startPositionX, yPos + gizmoHeight / 2, 0);
        Vector3 startBottom = new Vector3(startPositionX, yPos - gizmoHeight / 2, 0);
        Gizmos.DrawLine(startTop, startBottom);

        // ȭ��ǥ �׸��� (Reset �� Start)
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