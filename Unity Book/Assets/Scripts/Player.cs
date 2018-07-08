using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Coustom/Player")]
public class Player : MonoBehaviour {

    public float m_speed = 6;

    public Transform m_rocket; // 只是为了实例化子弹

    private Transform m_transform;

    private float m_lastShootTime = 0;
    public float m_shootInterval = 0.1f;

    [SerializeField]
    private int m_life = 10; // 玩家血量

	// Use this for initialization
	void Start () {
        m_transform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {

        float movex = 0;
        float movez = 0;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            movez += m_speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            movez -= m_speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movex -= m_speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            movex += m_speed * Time.deltaTime;
        }
        m_transform.Translate(new Vector3(-movex, 0, -movez)); // 因为模型方向是反的。

        m_lastShootTime += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space))
        { 
            if (m_lastShootTime > m_shootInterval)
            {
                m_lastShootTime = 0;
                Instantiate(m_rocket, m_transform.position, m_transform.rotation);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.CompareTo("PlayerRocket") != 0)
        {
            // 除了玩家子弹外的碰撞
            m_life -= 1;
        }
        if (m_life <= 0)
        {
            Debug.Log("???????????????");
            Destroy(this.gameObject);
        }
    }


}
