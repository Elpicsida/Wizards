using Assets.Scripts.Spells;

public class FireballTime : ShootingSpell {
    
	public override void Activate ()
    {
        base.Activate();
        Invoke("Destroy", 3);
	}

    void Destroy()
    {
        Destroy(this.gameObject);
    }
}
