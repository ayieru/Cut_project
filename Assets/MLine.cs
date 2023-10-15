using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MLine : MonoBehaviour
{
    public GameObject linePrefab; // ラインのプレハブ
    private GameObject currentLine; // 現在のライン
    private LineRenderer lineRenderer; // ラインのレンダラー
    private List<Vector3> linePositions; // ラインの頂点位置

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CreateNewLine();
        }

        if (Input.GetMouseButton(0))
        {
            UpdateLine();
        }
    }

    void CreateNewLine()
    {
        currentLine = Instantiate(linePrefab);
        lineRenderer = currentLine.GetComponent<LineRenderer>();
        linePositions = new List<Vector3>();
        lineRenderer.positionCount = 0;

        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10; // カメラから適切な距離に設定

        Vector3 worldMousePosition = mainCamera.ScreenToWorldPoint(mousePosition);
        AddPointToLine(worldMousePosition);
    }

    void UpdateLine()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10; // カメラから適切な距離に設定

        Vector3 worldMousePosition = mainCamera.ScreenToWorldPoint(mousePosition);
        AddPointToLine(worldMousePosition);
    }

    void AddPointToLine(Vector3 point)
    {
        linePositions.Add(point);
        lineRenderer.positionCount = linePositions.Count;
        lineRenderer.SetPositions(linePositions.ToArray());
    }
}
