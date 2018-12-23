using CosmosX.Entities.Modules.Absorbing.Contracts;

namespace CosmosX.Entities.Modules.Absorbing
{
    public class CooldownSystem : BaseAbsorbingModule, IAbsorbingModule
    {
        public CooldownSystem(int id, int heatAbsorbing)
            : base(id, heatAbsorbing)
        {
        }
    }
}