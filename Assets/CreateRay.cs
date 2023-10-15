using UnityEngine;

public class CreateRay : MonoBehaviour
{
    public Material lineMaterial; // 直線のマテリアル
    public float lineLength = 10f; // 直線の長さ

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // マウスクリックした位置を取得
            Vector3 mousePosition = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);

            // レイキャストを実行して直線を生成
            if (Physics.Raycast(ray, out RaycastHit hit, lineLength))
            {
                Vector3 hitPoint = hit.point;

                // 直線のゲームオブジェクトを生成
                GameObject lineObject = new GameObject("Ray Line");
                LineRenderer lineRenderer = lineObject.AddComponent<LineRenderer>();

                // 直線の表示設定
                lineRenderer.material = lineMaterial;
                lineRenderer.startWidth = 0.1f;
                lineRenderer.endWidth = 0.1f;

                // 直線の頂点を設定
                lineRenderer.positionCount = 2;
                lineRenderer.SetPosition(0, ray.origin);
                lineRenderer.SetPosition(1, hitPoint);
            }
        }
    }
}
