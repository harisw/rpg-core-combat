using System.Collections;
using System.Collections.Generic;
using RPG.Combat;
using RPG.Core;
using UnityEngine;

namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 3f;

        Fighter fighter;
        Health health;
        GameObject player;
        private void Start()
        {
            fighter = GetComponent<Fighter>();
            health = GetComponent<Health>();
            player = GameObject.FindWithTag("Player");
            print("Player "+ player);
        }

        // Update is called once per frame
        void Update()
        {
            if (health.IsDead())   return;
            
            if (IsInAttackRangeOfPlayer() && fighter.CanAttack(player))
            {
                fighter.Attack(player);
            }
            else
            {
                fighter.Cancel();
            }
        }

        private bool IsInAttackRangeOfPlayer()
        {
            float distanceWithPlayer = Vector3.Distance(player.transform.position, transform.position);
            return distanceWithPlayer < chaseDistance;
        }

        /// Callback to draw gizmos only if the object is selected.
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, chaseDistance);            
        }
    }
}