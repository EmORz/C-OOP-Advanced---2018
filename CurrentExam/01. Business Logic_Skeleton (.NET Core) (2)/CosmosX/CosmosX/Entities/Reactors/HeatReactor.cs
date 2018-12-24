using CosmosX.Entities.Containers.Contracts;

namespace CosmosX.Entities.Reactors
{
    public class HeatReactor : BaseReactor
    {
        public HeatReactor(int id, IContainer moduleContainer, int heatReductionIndex)
            : base(id, moduleContainer)
        {
            this.HeatReductionIndex = heatReductionIndex;
        }

        public int HeatReductionIndex { get;}

        //Todo test this

        //public override long TotalEnergyOutput
        //{
        //    get
        //    {
        //        long totalEnergyFromModules = base.TotalEnergyOutput * this.HeatReductionIndex;


        //        if (base.TotalHeatAbsorbing < TotalEnergyOutput)
        //        {
        //            TotalHeatAbsorbing = 0;
        //        }
        //        return totalEnergyFromModules;

        //        //long totalEnergyFromModules = base.TotalEnergyOutput * this.CryoProductionIndex;

        //        //if (totalEnergyFromModules > base.TotalHeatAbsorbing)
        //        //{
        //        //    totalEnergyFromModules = 0;
        //        //}

        //        //return totalEnergyFromModules;



        //    }
        //}

        public override long TotalHeatAbsorbing 
            => base.TotalHeatAbsorbing + this.HeatReductionIndex;
    }
}