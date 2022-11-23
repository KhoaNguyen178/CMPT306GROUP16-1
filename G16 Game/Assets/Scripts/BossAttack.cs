using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
	public int attackDamage = 20;

	public Vector3 attackOffset;
	public float attackRange = 1f;
	public LayerMask attackMask;

	[SerializeField] GameObject projectile;

	float fireRate;
	float nextFire;

    void Start()
    {
		fireRate = 1f;
		nextFire = Time.time;
    }

  //  void Update()
  //  {
		//CheckTimeFired();
  //  }
    public void Attack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
		if (colInfo != null)
		{
			colInfo.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
			Instantiate(projectile, transform.position, Quaternion.identity);
			colInfo.GetComponent<PlayerController>().PlayerTakeDamage(attackDamage);
			
		}
	}
	void OnDrawGizmosSelected()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Gizmos.DrawWireSphere(pos, attackRange);
	}

    //void CheckTimeFired()
    //{
    //    if (Time.time > nextFire)
    //    {
    //        Instantiate(projectile, transform.position, Quaternion.identity);
    //        nextFire = Time.time + fireRate;
    //    }
    //}
}
