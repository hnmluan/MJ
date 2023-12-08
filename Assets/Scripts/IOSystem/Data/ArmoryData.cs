using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class ArmoryData
{
    public List<ItemArmoryData> weapons;

    public ArmoryData(Armory armory) => this.weapons = armory.Weapons.Select(item => new ItemArmoryData(item)).ToList();
}
