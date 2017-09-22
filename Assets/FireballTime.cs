using UnityEngine;

public class FireballTime : MonoBehaviour {
    
	void Start () {
        Invoke("Destroy", 3);
	}

    void Destroy()
    {
        Destroy(this.gameObject);
    }
}
