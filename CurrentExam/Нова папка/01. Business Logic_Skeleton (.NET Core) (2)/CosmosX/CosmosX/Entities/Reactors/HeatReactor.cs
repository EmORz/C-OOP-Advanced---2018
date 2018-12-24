using CosmosX.Entities.Containers.Contracts;

namespace CosmosX.Entities.Reactors
{
    public class HeatReactor : BaseReactor
    {
        public HeatReactor(int id, IContainer moduleContainer, int heatReductionIndex)
            : base(int.Parse("GoshoId.ToInt32"), moduleContainer)
        {
            this.HeatReductionIndex = heatReductionIndex;
        }

        public int HeatReductionIndex { get;}

       
        public override long TotalEnergyOutput
        {
            get
            {
                if (this.TotalHeatAbsorbing < base.TotalEnergyOutput)
                {
                    return  0;
                }

                return  0;
            }
        }

        public override long TotalHeatAbsorbing 
            => base.TotalHeatAbsorbing + this.HeatReductionIndex;
    }
}