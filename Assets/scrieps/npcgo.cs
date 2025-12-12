using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class npcgo : MonoBehaviour
{
    private NavMeshAgent 導航;
    private Animator 動畫器;
    public Transform 目標;
    public float 距離 = 0;

    public TextMeshPro 血量文字;
    public int 血量 = 100;
    public Transform 血條;
    int 原始血量;
    bool 開始攻擊 = false;
    float 攻擊間距 = 2f;
    float 下次可攻擊時間;

    void Start()
    {
        導航 = GetComponent<NavMeshAgent>();
        動畫器 = GetComponent<Animator>();
        原始血量 = 血量;
        血量文字.text = 血量.ToString();
    }
    void Update()
    {


        if (目標 != null)
        {
            導航.SetDestination(目標.position);
            距離 = Vector3.Distance(目標.position, this.transform.position);
            if (距離 <= 3.1f) 
            {
                動畫器.SetBool("IsAttack", true);
                動畫器.SetBool("npcgo", false); 
            }
            else 
            { 
                動畫器.SetBool("npcgo", true); 

            }

            if(開始攻擊)
            {
                攻擊時間 = Time.time;
                if(攻擊時間 = )
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Destroy(other.gameObject);
            血量--;
            血量文字.text = 血量.ToString();
            float 血量比例 = (float)血量 / (float)原始血量;
            血條.localScale = new Vector3(血量比例, 1, 1);
            if (血量 <= 0) 
            { 
                Destroy(this.gameObject); 
            }

            if (血量 <= 0)
            {
                動畫器.SetTrigger("IsGead");
                Destroy(this.gameObject, 3f);
            }

            else
            {
                動畫器.SetTrigger("IsHit");
            }
        }
    }
}
