using CosmosX.Entities.Modules.Absorbing.Contracts;

namespace CosmosX.Entities.Modules.Absorbing
{
    public class HeatProcessor : BaseAbsorbingModule, IAbsorbingModule
    {
        public HeatProcessor(int id, int heatAbsorbing) 
            : base(id, heatAbsorbing)
        {
        }
    }
}