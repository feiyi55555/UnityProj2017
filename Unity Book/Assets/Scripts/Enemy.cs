using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private Transform m_transform;

    public float m_speed = 1;
    public int m_life = 10;
    protected float m_retSpeed = 30; // 旋转速度

	// Use this for initialization
	void Start () {
        m_transform = this.transform;
        m_renderer = this.GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {
        UpdateMove();
        if (m_isActive && !m_renderer.isVisible)
        {
            Destroy(this.gameObject);
        }
	}

    protected void UpdateMove()
    {
        float rx = Mathf.Sin(Time.time) * Time.deltaTime;
        m_transform.Translate(new Vector3(rx, 0, -m_speed * Time.deltaTime));
    }

    internal Renderer m_renderer;
    internal bool m_isActive = false;

    private void OnBecameVisible()
    {
        m_isActive = true;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.CompareTo("PlayerRocket") == 0)
        {
            Rocket rocket = other.GetComponent<Rocket>();
            if (rocket != null)
            {
                m_life -= rocket.m_power;
            }
        }
        else if (other.tag.CompareTo("Player") == 0)
        {
            m_life = 0;
        }
        if (m_life <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
