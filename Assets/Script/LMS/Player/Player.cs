using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LMS.User
{
    public class Player : Entity
    {
        [SerializeField] private PlayerStateSO curState;
        [SerializeField] private PlayerStateSO remainState;

        private Rigidbody pRigd;
        private Animator pAnim;

        private void Awake()
        {
            pRigd = GetComponent<Rigidbody>();
            pAnim = GetComponent<Animator>();
        }

        public void SetMoveVector(Vector3 moveVec) => pRigd.AddForce(moveVec * curSpeed);
        public void SetAnimation(string name) => pAnim.SetTrigger(name);
        public void SetAnimation(string name, bool set) => pAnim.SetBool(name, set);
        public void SetAnimation(Vector2 moveVec)
        {
            pAnim.SetFloat("xDir", moveVec.x);
            pAnim.SetFloat("yDir", moveVec.y);
        }

        public void TransitionToState(PlayerStateSO nextState)
        {
            if (nextState != remainState) curState = nextState;
        }

        protected override void Dead()
        {

        }

        void Update()
        {
            curState.UpdateState(this);
        }
        private void FixedUpdate()
        {

        }
    }
}