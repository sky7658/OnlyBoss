using System;
using System.Collections;
using LMS.Utility;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Script.SHY.Monster
{
    public abstract class Monster : Entity
    {
        [SerializeField] private MonStateSO curState;
        [SerializeField] private MonStateSO remainState;
    
        [Header("Chase")]
        [SerializeField] private float chaseRange = 10;
        [SerializeField] private Transform target;
    
        [Header("Attack")]
        [SerializeField] private float attackRange = 2;
        [SerializeField] private float attackDelay = 2;
        private bool _isAttack;
        public bool IsAttack
        {
            get { return _isAttack; }
        }
        
        [Header("Hit")]
        [SerializeField] private float hitDelay = 2;
        private bool _isHit;
        public bool IsHit
        {
            get { return _isHit; }
        }
    
        private NavMeshAgent _agent;
        private Rigidbody _rigid;
        private Animator _anim;

        private float _autoTime;
        private bool _isAutoChange;
        public bool IsAutoChange
        {
            get { return _isAutoChange; }
        }

        protected virtual void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _rigid = GetComponent<Rigidbody>();
            _anim = GetComponent<Animator>();
            _agent.updateRotation = false;
        }
    
        protected virtual void Start()
        {
            Initailized();
            SetAutoTime();
        }
    
        public void TransitionToState(MonStateSO nextState)
        {
            if (nextState == remainState) return;
            curState.ExitState(this);
            curState = nextState;
            curState.EnterState(this);
        }

        // Update is called once per frame
        protected virtual void Update()
        {
            curState.UpdateState(this);
        }

        #region SetAnimation

        public void SetAnimation(string aniName, bool value)
        {
            _anim.SetBool(aniName, value);
        }
    
        public void SetAnimation(string aniName, float value)
        {
            _anim.SetFloat(aniName, value);
        }
    
        public void SetAnimation(string aniName, int value)
        {
            _anim.SetInteger(aniName, value);
        }
    
        public void SetAnimation(string aniName)
        {
            _anim.SetTrigger(aniName);
        }

        #endregion

        protected override void Dead()
        { }
    
        public void SetAutoTime()
        { 
            _isAutoChange = false;
            curSpeed = 0;
            CoroutineManager.Instance.ExecuteCoroutine(AutoTime());
            //멈추기
            _agent.isStopped = true;
        }
    
        public void OffAutoTime()
        {
            StopCoroutine(AutoTime());
            _isAutoChange = false;
            _agent.isStopped = false;
        }
    
        private IEnumerator AutoTime()
        {
            int autoTime = Random.Range(2, 5);

            yield return new WaitForSeconds(autoTime);
        
            _isAutoChange = true;
        }

        #region Wander

        public void SetWander() => StartCoroutine(Wander());

        private IEnumerator Wander()
        {
            float curTime = 0;
            float maxTime = 10;
            _isAutoChange = false;
        
            _agent.speed = curSpeed;
            _agent.SetDestination(CalculateWanderPos());
        
            Vector3 to = new Vector3(_agent.destination.x,0,_agent.destination.z);
            Vector3 from = new Vector3(transform.position.x,0,transform.position.z);
            transform.rotation = Quaternion.LookRotation(to - from);
        
            while (true)
            {
                if (curSpeed < MaxSpeed / 2)
                {
                    curSpeed += Time.deltaTime*3;
                    _agent.speed = curSpeed;
                }
                curTime += Time.deltaTime;
                to = new Vector3(_agent.destination.x,0,_agent.destination.z);
                from = new Vector3(transform.position.x,0,transform.position.z);
                if ((to - from).sqrMagnitude < 0.01f || curTime >= maxTime)
                {
                    _isAutoChange = true;
                    break;
                }
                yield return null;
            }
        }

        private Vector3 CalculateWanderPos()
        {
            float wanderRadius = 10;
            int wanderJitter = 0;
            int wanderJitterMin = 0;
            int wanderJitterMax = 360;

            Vector3 rangerPos = Vector3.zero;
            Vector3 rangeScale = Vector3.one*100.0f;
        
            wanderJitter = Random.Range(wanderJitterMin, wanderJitterMax);
            Vector3 targetPos = transform.position + SetAngle(wanderRadius, wanderJitter);
        
            targetPos.x = Mathf.Clamp(targetPos.x, rangerPos.x - rangeScale.x*0.5f, rangerPos.x + rangeScale.x*0.5f);
            targetPos.y = 0.0f;
            targetPos.z = Mathf.Clamp(targetPos.z, rangerPos.z - rangeScale.z*0.5f, rangerPos.z + rangeScale.z*0.5f);

            return targetPos;
        }
    
        private Vector3 SetAngle(float radius, float angle)
        {
            Vector3 pos = Vector3.zero;
        
            pos.x = Mathf.Cos(angle)*radius;
            pos.z = Mathf.Sin(angle)*radius;

            return pos;
        }
    
        public void OffWander()
        {
            StopCoroutine(Wander());
            _isAutoChange = false;
        }

        #endregion

        #region Chase

        public bool GetChaseDis()
        {
            if (target == null) return false;
            if (Vector3.Distance(transform.position, target.position) <= chaseRange)
            {
                return true;
            }

            return false;
        }
    
        public void LookTarget()
        {
            Vector3 to = new Vector3(target.position.x,0,target.position.z);
            Vector3 from = new Vector3(transform.position.x,0,transform.position.z);
            transform.rotation = Quaternion.LookRotation(to - from);
        }
    
        public void SetChase() => StartCoroutine(Chase());
    
        private IEnumerator Chase()
        {
            _isAutoChange = false;
            _agent.speed = curSpeed;
            _agent.SetDestination(target.position);
        
            while (true)
            {
                _agent.SetDestination(target.position);
                if (curSpeed < MaxSpeed)
                {
                    curSpeed += Time.deltaTime*3;
                    _agent.speed = curSpeed;
                }
                if (Vector3.Distance(transform.position, target.position) >= chaseRange)
                {
                    _isAutoChange = true;
                    break;
                }
                yield return null;
            }
        }
    
        public void OffChase()
        {
            StopCoroutine(Chase());
            _isAutoChange = false;
        }

        #endregion

        #region Attack

        public virtual void SetAttack()
        {
            _agent.isStopped = true;
            _isAttack = true;
            LookTarget();
        }

        public virtual void OffAttack()
        {
            _agent.isStopped = false;
        }
    
        public bool GetDisFromtarget()
        {
            if (target == null) return false;
            if (Vector3.Distance(transform.position, target.position) <= attackRange)
            {
                return true;
            }

            return false;
        }
    
        public void EndAttack()=> StartCoroutine(AttackDelay());
    
        IEnumerator AttackDelay()
        {
            yield return new WaitForSeconds(attackDelay);
            _isAttack = false;
        }

        #endregion
        
        #region Hit
        
        public void SetHit()
        {
            _agent.isStopped = true;
            _isAutoChange = false;
        }

        public override void TakeHit(float damage, Transform pos)
        {
            if(_isHit) return;
            base.TakeHit(damage, pos);
            _isHit = true;
            //StartCoroutine(HitDelay());
        }

        IEnumerator HitDelay()
        {
            yield return new WaitForSeconds(hitDelay);
            _isHit = false;
        }

        public void EndHit()
        {
            _isAutoChange = true;
            _isHit = false;
        }
        
        public void OffHit()
        {
            _agent.isStopped = false;
        }
        
        #endregion
    }
}