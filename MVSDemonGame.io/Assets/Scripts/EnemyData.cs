using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="EnemyData", menuName ="My Game/Enemy Data")]
public class EnemyData : ScriptableObject
{
    [System.Serializable]
public class UnitData
    {
        public string unit_name = "Template Unit";
        public int uid = 0;
        public int factionID = 0;

    }

    public List<UnitData> units = new List<UnitData>();

}
