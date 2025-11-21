using Unity.VisualScripting;
using UnityEngine;

public class FindTarget : MonoBehaviour
{
    public Transform 最近的敵人;
    public Vector3 敵人座標;
    public float 最近距離;
    public GameObject 最終目標;

    private void Start()
    {
        最終目標 = GameObject.Find("Target");
    }


    // Update is called once per frame
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length == 0)
        {
            最近的敵人 = null;
            敵人座標 = Vector3.zero;
            最近距離 = 0f;
            return;
        }

        float shortestDistance = float.MaxValue;
        GameObject closestEnemy = null;

        foreach(GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                closestEnemy = enemy;
            }
            if (shortestDistance > 10f)
            {
                closestEnemy = null;
            }
        }

        if (closestEnemy != null)
        {
            最近的敵人 = closestEnemy.transform;
            // 設定目標座標
            敵人座標 = closestEnemy.transform.position;
            最近距離 = shortestDistance;
            敵人座標.y = 1.4f;
            最終目標.transform.position = 敵人座標;
        }
        else
        {
            Vector3 原始座標 = new Vector3(0, 1.6f, 1.72f);
            最終目標.transform.localPosition = 原始座標;
        }

    }
}
