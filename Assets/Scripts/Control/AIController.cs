using System.Collections;
using System.Collections.Generic;
using RPG.Combat;
using UnityEngine;

namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 3f;

        Fighter fighter;
        GameObject player;
        private void Start()
        {
            fighter = GetComponent<Fighter>();
            player = GameObject.FindWithTag("Player");
            print("Player "+ player);
        }

        // Update is called once per frame
        void Update()
        {
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
    }
}