using UnityEngine;

public class moveCamera : MonoBehaviour
{
    [SerializeField] private float 速度 = 3.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.UpArrow))//z軸移動
        {
            transform.Translate(Vector3.forward * 速度 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))//z軸移動
        {
            transform.Translate(Vector3.back * 速度 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))//z軸移動
        {
            transform.Translate(Vector3.right * 速度 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))//z軸移動
        {
            transform.Translate(Vector3.left * 速度 * Time.deltaTime);
        }
    }
}
