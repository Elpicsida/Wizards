using Assets.Scripts.Spells;
using UnityEngine;

public class FireballStraight : ShootingSpell {

    public GameObject FireballBallistic;
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Terrain")
        {
            var velocity = this.GetComponent<Rigidbody2D>().velocity;
            for (int i = 0; i < 10; i++)
            {
                var fireball = (GameObject)Instantiate<GameObject>(FireballBallistic);
                fireball.transform.position = this.transform.position;
                fireball.GetComponent<Rigidbody2D>().velocity = -(velocity + new Vector2(1, 1) * i);
            }
            Destroy(this.gameObject);
        }
    }
}
