using Assets.Scripts.Miscellaneous;
using Assets.Scripts.Spells;
using UnityEngine;

public class FireballBallistic : ShootingSpell
{
    public int Damage = 50;
    public int Radius = 5;
    private Explosion explosion;
    private bool IsDestroyed = false;
    
	void Start ()
    {
        explosion = new Explosion();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!IsDestroyed)
        {
            string collisinObject = collision.gameObject.tag;
            if (TagNames.Terrain.Equals(collisinObject) || TagNames.Character.Equals(collisinObject))
            {
                explosion.Explode(Damage, Radius, transform.position);
                turnManager.ChangeTurn();
                CameraSingleton.Instance.WatchObject(turnManager.GetActiveWizard().gameObject);
                Destroy(this.gameObject);
                IsDestroyed = true;
            }
        }
    }
}
