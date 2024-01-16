using System.Collections;
using UnityEngine;
using LMS.Utility;
using UnityEngine.AI;

public abstract class Monster : Entity
{
    [SerializeField] private MonStateSO curState;
    [SerializeField] private MonStateSO remainState;
    
    [Header("Chase")]
    [SerializeField] private float chaseRange = 10;
    [SerializeField] private Transform chaseTarget;
    
    private NavMeshAgent agent;
    private Rigidbody rigid;
    private Animator anim;

    private float autoTime;
    private bool isAutoChange = false;
    public bool IsAutoChange
    {
        get { return isAutoChange; }
    }

    protected virtual void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        agent.updateRotation = false;
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
    
    public void SetAnimation(string name, bool value)
    {
        anim.SetBool(name, value);
    }
    
    public void SetAnimation(string name, float value)
    {
        anim.SetFloat(name, value);
    }

    protected override void Dead()
    {

    }
    
    public void SetAutoTime()
    { 
        isAutoChange = false;
        curSpeed = 0;
        CoroutineManager.Instance.ExecuteCoroutine(AutoTime());
        //멈추기
        agent.isStopped = true;
    }
    
    public void OffAutoTime()
    {
        StopCoroutine(AutoTime());
        isAutoChange = false;
        agent.isStopped = false;
    }
    
    private IEnumerator AutoTime()
    {
        int _autoTime = UnityEngine.Random.Range(2, 5);

        yield return new WaitForSeconds(_autoTime);
        
        isAutoChange = true;
    }

    public void SetWander() => StartCoroutine(Wander());

    private IEnumerator Wander()
    {
        float curTime = 0;
        float maxTime = 10;
        isAutoChange = false;
        
        agent.speed = curSpeed;
        agent.SetDestination(CalculateWanderPos());
        
        Vector3 to = new Vector3(agent.destination.x,0,agent.destination.z);
        Vector3 from = new Vector3(transform.position.x,0,transform.position.z);
        transform.rotation = Quaternion.LookRotation(to - from);
        
        while (true)
        {
            if (curSpeed < MaxSpeed / 2)
            {
                curSpeed += Time.deltaTime*3;
                agent.speed = curSpeed;
            }
            curTime += Time.deltaTime;
            to = new Vector3(agent.destination.x,0,agent.destination.z);
            from = new Vector3(transform.position.x,0,transform.position.z);
            if ((to - from).sqrMagnitude < 0.01f || curTime >= maxTime)
            {
                isAutoChange = true;
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
        
        wanderJitter = UnityEngine.Random.Range(wanderJitterMin, wanderJitterMax);
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
        isAutoChange = false;
    }

    public bool GetChaseDis()
    {
        if (chaseTarget == null) return false;
        if (Vector3.Distance(transform.position, chaseTarget.position) <= chaseRange)
        {
            return true;
        }

        return false;
    }
    
    public void LookTarget()
    {
        Vector3 to = new Vector3(chaseTarget.position.x,0,chaseTarget.position.z);
        Vector3 from = new Vector3(transform.position.x,0,transform.position.z);
        transform.rotation = Quaternion.LookRotation(to - from);
    }
    
    public void SetChase() => StartCoroutine(Chase());
    
    private IEnumerator Chase()
    {
        isAutoChange = false;
        agent.speed = curSpeed;
        agent.SetDestination(chaseTarget.position);
        
        while (true)
        {
            agent.SetDestination(chaseTarget.position);
            if (curSpeed < MaxSpeed)
            {
                curSpeed += Time.deltaTime*3;
                agent.speed = curSpeed;
            }
            if (Vector3.Distance(transform.position, chaseTarget.position) >= chaseRange)
            {
                isAutoChange = true;
                break;
            }
            yield return null;
        }
    }
    
    public void OffChase()
    {
        StopCoroutine(Chase());
        isAutoChange = false;
    }
}