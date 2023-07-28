public class PlayerAttack : MeleeAttackByMouse
{
    protected override void PlayAttack()
    {
        base.PlayAttack();
        DamageSender damageReceiver = damageObject.GetComponentInChildren<DamageSender>();
        damageReceiver.isDameFromPlayer = true;
        AudioController.Instance.PlayVFX("sfx_acttack_melee");
    }



    //[Header("------------Other Settings------------")][Space(10)]

    /*[SerializeField] protected string damageObjectName = "Lance";

    [SerializeField] protected bool canAttack = true;

    [SerializeField] protected DOSO doSO;

    [SerializeField] protected bool isMelee;

    [Header("------------Weapon In Hand------------")]
    [Space(10)]

    [SerializeField] protected Transform leftWeaponInHand;

    [SerializeField] protected Transform rightWeaponInHand;

    [SerializeField] protected Transform upWeaponInHand;

    [SerializeField] protected Transform downWeaponInHand;

    [SerializeField] protected Transform weaponInHand;

    [SerializeField] protected SpriteRenderer weaponInHandSprite;

    [Header("------------Weapon In Attack------------")]
    [Space(10)]

    [SerializeField] protected float rotationSpeed = 2000f;

    [SerializeField] protected float circleRadius = 0.5f;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.GetDamageObjectSO();
        this.LoadWeaponInHandSprite();
        this.LoadLeftWeaponInHand();
        this.LoadRightWeaponInHand();
        this.LoadUpWeaponInHand();
        this.LoadDownWeaponInHand();
        this.LoadWeaponInHand();
    }

    private void LoadWeaponInHand()
    {
        if (this.weaponInHand != null) return;
        weaponInHand = transform.Find("WeaponInHand");
        Debug.Log(transform.name + ": LoadWeaponInHand " + gameObject);
    }

    private void LoadDownWeaponInHand()
    {
        if (this.downWeaponInHand != null) return;
        downWeaponInHand = transform.Find("Down");
        Debug.Log(transform.name + ": LoadDownWeaponInHand " + gameObject);
    }

    private void LoadUpWeaponInHand()
    {
        if (this.upWeaponInHand != null) return;
        upWeaponInHand = transform.Find("Up");
        Debug.Log(transform.name + ": LoadUpWeaponInHand " + gameObject);
    }

    private void LoadRightWeaponInHand()
    {
        if (this.rightWeaponInHand != null) return;
        rightWeaponInHand = transform.Find("Right");
        Debug.Log(transform.name + ": LoadRightWeaponInHand " + gameObject);
    }

    private void LoadLeftWeaponInHand()
    {
        if (this.leftWeaponInHand != null) return;
        leftWeaponInHand = transform.Find("Left");
        Debug.Log(transform.name + ": LoadLeftWeaponInHand " + gameObject);
    }

    protected void LoadWeaponInHandSprite()
    {
        if (this.doSO == null) return;
        weaponInHandSprite = transform.GetComponentInChildren<SpriteRenderer>();
        weaponInHandSprite.sprite = doSO.spriteInHand;
        Debug.Log(transform.name + ": LoadWeaponInHandSprite " + gameObject);
    }

    protected virtual void GetDamageObjectSO()
    {
        if (this.doSO != null) return;
        string resPathRanged = "DamageObject/Ranged/" + damageObjectName;
        string resPathMelee = "DamageObject/Melee/" + damageObjectName;
        this.doSO = Resources.Load<DOSO>(resPathRanged);
        if (this.doSO != null)
        {
            Debug.Log(transform.name + ": GetDamageObjectSO " + resPathRanged, gameObject);
            isMelee = false;
            return;
        }
        this.doSO = Resources.Load<DOSO>(resPathMelee);
        if (this.doSO != null)
        {
            Debug.Log(transform.name + ": GetDamageObjectSO " + resPathMelee, gameObject);
            isMelee = true;
            return;
        }
    }

    private void Update()
    {
        if (canAttack)
        {
            if (Input.GetMouseButton(0))
            {
                Attack(damageObjectName);
                StartCoroutine(IntervalAttackCountdown());
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (isMelee) weaponInHandSprite.enabled = false;
            if (!isMelee)
            {
                weaponInHandSprite.enabled = true;
                SetPositionWeaponInAttack();
            }
        }
        else
            InHand();
    }

    private IEnumerator IntervalAttackCountdown()
    {
        canAttack = false;
        yield return new WaitForSeconds(getIntervalAttack());
        canAttack = true;
    }

    private float getIntervalAttack() => doSO is RangedSO ? ((RangedSO)doSO).fireRate : (((MeleeSO)doSO).timeAttack);

    private void SpawnDamageObject(string damageObjectName, Vector3 positon, Quaternion quaternion)
    {
        Transform damageObject = MeleeDOSpawner.Instance.Spawn(damageObjectName, positon, quaternion);
        if (damageObject == null) return;
        damageObject.gameObject.SetActive(true);

        DamageSender damageReceiver = damageObject.GetComponentInChildren<DamageSender>();
        damageReceiver.isDameFromPlayer = true;

        AudioController.Instance.PlayVFX("sfx_acttack_melee");
    }

    private void Attack(string projectileName) => SpawnDamageObject(projectileName, weaponInHand.position, GetQuaternionToMouse());

    public Vector3 GetDirectionToMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z;
        Vector3 target = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 direction = target - transform.position;
        direction.z = 0;
        direction.Normalize();
        return direction;
    }

    private Quaternion GetQuaternionToMouse()
    {
        float angle = Mathf.Atan2(GetDirectionToMouse().y, GetDirectionToMouse().x) * Mathf.Rad2Deg;
        return Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void SetPositionWeaponInAttack()
    {
        float angle = Mathf.Atan2(GetDirectionToMouse().y, GetDirectionToMouse().x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        weaponInHand.rotation = Quaternion.RotateTowards(weaponInHand.rotation, rotation, rotationSpeed * Time.deltaTime);
        weaponInHand.localScale = new Vector3(1, 1, 1);
        Vector3 circularPosition = transform.position + Quaternion.Euler(0, 0, angle) * Vector3.right * circleRadius;
        weaponInHand.position = circularPosition;
    }

    public Transform GetPositionWeaponInHand()
    {
        if (playerCtrl.Animator.GetFloat("X") == 1) return rightWeaponInHand;
        if (playerCtrl.Animator.GetFloat("X") == -1) return leftWeaponInHand;
        if (playerCtrl.Animator.GetFloat("Y") == 1) return upWeaponInHand;
        return downWeaponInHand;
    }

    public void InHand()
    {
        weaponInHand.position = GetPositionWeaponInHand().position;
        weaponInHand.rotation = Quaternion.Euler(0f, 0f, 0f);
        weaponInHand.localScale = new Vector3(1, 1, 1);
        if (playerCtrl.Animator.GetFloat("X") == -1) weaponInHand.localScale = new Vector3(-1, 1, 1);
    }*/
}
