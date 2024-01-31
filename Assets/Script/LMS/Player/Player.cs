using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace LMS.User
{
    public class Player : Entity
    {
        [SerializeField] private PlayerStateSO curState;
        [SerializeField] private PlayerStateSO remainState;

        private Rigidbody pRigd;
        private Animator pAnim;

        #region 점프
        private bool isLand;
        public bool IsLand { get { return isLand; } }
        private bool isJump;
        public bool IsJump
        {
            get { return isJump; }
            set
            {
                if(value)
                {
                    isJump = value;
                }
                else
                {
                    isJump = value;
                }
            }
        }
        private void EndJump() => isJump = false;
        private void Landing() => isLand = true;
        private void EndLand() => isLand = false;
        public void Jump() => pRigd.AddForce(new Vector3(0, 1, 0));
        #endregion

        public bool isAttack { get; set; }
        private void EndAttack() => isAttack = false;
        public bool isHit { get; set; }
        private void EndHit() => isHit = false;
        public float sprint { get; set; }

        private void Awake()
        {
            pRigd = GetComponent<Rigidbody>();
            pAnim = GetComponent<Animator>();
        }

        public void SetMoveVector(Vector3 moveVec) => pRigd.AddForce(moveVec * curSpeed);
        public void SetAnimation(string name) => pAnim.SetTrigger(name);
        public void SetAnimation(string name, float value) => pAnim.SetFloat(name, value);
        public void SetAnimation(string name, bool set) => pAnim.SetBool(name, set);
        public void SetAnimation(Vector2 moveVec)
        {
            pAnim.SetFloat("xDir", moveVec.x);
            pAnim.SetFloat("yDir", moveVec.y);
        }

        public bool IsControllerKey(string keyname)
        {
            switch(keyname)
            {
                case "MoveKeys":
                    return Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);
                case "Fowards":
                    return Input.GetKey(KeyCode.W);
                case "Backs":
                    return Input.GetKey(KeyCode.S);
                case "Rights":
                    return Input.GetKey(KeyCode.D);
                case "Lefts":
                    return Input.GetKey(KeyCode.A);
            }

            Debug.Log("존재하지 않은 컨트롤 키 입니다.");
            return false;
        }

        public void TransitionToState(PlayerStateSO nextState) => curState = nextState != remainState ? nextState : curState;

        protected override void Initailized()
        {
            base.Initailized();
        }

        protected override void Dead()
        {

        }

        void Update()
        {
            curState.UpdateState(this);
            if(Input.GetKeyDown(KeyCode.K)) 
            {
                isHit = true;
            }
        }
        private void FixedUpdate()
        {

        }
    }
}