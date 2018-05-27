using System.Collections.Generic;

public interface IWareHouse
{
    void EquipArmy(IArmy army);

    void AddAmmo(string ammoName, int count);
    void EquipSoldier(ISoldier soldier);
}
