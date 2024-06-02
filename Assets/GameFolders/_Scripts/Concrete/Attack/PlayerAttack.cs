using UnityEngine;

public class PlayerAttack : IAttack
{
    

    public void Attack(Transform transform, Vector3 rayDirection, float attackRange, LayerMask enemyLayer, GameObject player, Animator anim)
    {
        float sphereRadius = 1.5f; 
        
  

        RaycastHit[] hits = Physics.SphereCastAll(transform.position, sphereRadius, rayDirection, attackRange, enemyLayer);

        foreach (RaycastHit hit in hits)
        {
          float enemyLevel= hit.collider.gameObject.GetComponent<EnemyLevelManager>().EnemyLevel;//if (pLevel >= eLevel)
         float playerLevel=  PlayerLevelManager.Instance._level;
              if(enemyLevel<playerLevel)
              {

                anim.SetTrigger("isPlayerAttack");
                

              // hit.collider.gameObject.GetComponentInChildren<Animator>().SetTrigger("isEnemyDead");
              hit.collider.gameObject.GetComponent<EnemyController>().speed=0;

                Vector3 pos=hit.collider.gameObject.GetComponent<Transform>().position;
                EffectManager.Instance.DeadEffect(pos); // fazlaca spawn var 
                MonoBehaviour.Destroy(hit.collider.gameObject, 1);
              }
            
           
        }
    }

   
}
