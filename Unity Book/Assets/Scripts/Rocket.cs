using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Custom/Rocket")]
public class Rocket : MonoBehaviour {

    public float m_speed = 10;
    public float m_liveTime = 1.5f;
    public int m_power = 1;

    private Transform m_transform;

	// Use this for initialization
	void Start () {
        m_transform = this.transform;
        Destroy(this.gameObject, m_liveTime);
	}
	
	// Update is called once per frame
	void Update () {
        m_transform.Translate(new Vector3(0, 0, -m_speed * Time.deltaTime));
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.CompareTo("Enemy") == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
