using System.Collections;
using UnityEngine;

public class FireWandSpawner : WeaponSpawner
{
    int num = 3;
    float speed = 200f;
    Vector2 destination;

    internal override IEnumerator StartAttack()
    {
        EnemySpawner enemySpawner = EnemySpawner.GetInstance();

        while (true)
        {
            UpdateAttackPower();
            UpdateAttackSpeed();

            if (enemySpawner.GetListCount() > 0)
            {
                destination = enemySpawner.GetRandomEnemyPosition();
                for (int i = 0; i < num; ++i)
                    SpawnWeapon(i);
            }

            yield return new WaitForSeconds(GetAttackSpeed());
        }
    }

    void SpawnWeapon(int i)
    {
        GameObject weapon = ObjectPooling.GetObject(GetWeaponType());
        float destLength = (destination - (Vector2)transform.position).magnitude;
        Vector2 destVector;
        float angle;

        if (GetWeaponData().GetParent().Equals(WeaponData.Parent.Self))
            weapon.transform.position += Player.GetInstance().GetPosition();

        weapon.transform.localScale = new Vector3(weapon.transform.localScale.x * (GetAdditionalScale() / 100f), weapon.transform.localScale.y * (GetAdditionalScale() / 100f), weapon.transform.localScale.z);
        weapon.GetComponent<Weapon>().SetParameters(GetAttackPower(), GetInactiveDelay(), Direction.Self);

        // ���� ������ �߻��ϱ� ���� ���� ����
        if (i == 0 || i % 2 == 0)
            destination.x += i * destLength * 0.25f;
        else
            destination.x -= i * destLength * 0.25f;

        // ��ǥ���� ��������
        destVector = (destination - (Vector2)transform.position).normalized;

        // ����Ʈ ȸ�� �� ����
        if (destVector.y < 0)
            angle = -Vector2.Angle(destVector, new Vector2(1, 0));
        else
            angle = Vector2.Angle(destVector, new Vector2(1, 0));

        // ����Ʈ ȸ��
        weapon.transform.rotation = Quaternion.Euler(0f, 0f, angle - 8.5f);

        weapon.SetActive(true);

        // �߻�
        weapon.GetComponent<Rigidbody2D>().AddForce(destVector * speed, ForceMode2D.Force);
    }

    public override void LevelUp()
    {
        IncreaseLevel();

        Debug.Log("levelUp");

        switch (GetLevel())
        {
            case 2:
                num++;
                break;
            case 3:
                IncreaseAttackPower(5);
                break;
            case 4:
                num++;
                IncreaseAttackPower(5);
                IncreaseAdditionalScale(10f);
                break;
            case 5:
                DecreaseAttackSpeed(10f);
                break;
        }
    }
}