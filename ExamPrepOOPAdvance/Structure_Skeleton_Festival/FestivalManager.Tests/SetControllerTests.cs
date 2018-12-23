// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)

using System;
//using FestivalManager.Core.Controllers;
//using FestivalManager.Core.Controllers.Contracts;
//using FestivalManager.Entities;
//using FestivalManager.Entities.Contracts;
//using FestivalManager.Entities.Instruments;
//using FestivalManager.Entities.Sets;

namespace FestivalManager.Tests
{
	using NUnit.Framework;

	[TestFixture]
	public class SetControllerTests
    {
		[Test]
	    public void Test()
	    {
            IStage stage = new Stage();
            ISetController setController = new SetController(stage);
	        ISet set = new Short("Set1");

            stage.AddSet(set);

	        var result = setController.PerformSets();
	        var expectedResult = "1. Set1:\r\n-- Did not perform";

            Assert.AreEqual(result, expectedResult);

	    }

        [Test]
        public void IsReturnSucessMessage()
        {
            IStage stage = new Stage();
            ISetController setController = new SetController(stage);

            ISet set = new Short("Set1");
            IPerformer performer = new Performer("Boiko", 53);
            performer.AddInstrument(new Guitar());

            ISong song = new Song("Vignetu", new TimeSpan(0,6,0));
            set.AddSong(song);
            set.AddPerformer(performer);
            stage.AddSet(set);

            var result = setController.PerformSets();
            var expectedResult = "1. Set1:\r\n-- 1. Vignetu (06:00)\r\n-- Set Successful";

            Assert.AreEqual(expectedResult, result);

        }

        [Test]
        public void PerformSetShouldDecreaseInstrument()
        {
            IStage stage = new Stage();
            ISetController setController = new SetController(stage);

            ISet set = new Short("Set1");
            IPerformer performer = new Performer("Boiko", 53);
            IInstrument instrument = new Guitar();
            performer.AddInstrument(instrument);

            ISong song = new Song("Vignetu", new TimeSpan(0, 6, 0));
            set.AddSong(song);
            set.AddPerformer(performer);
            stage.AddSet(set);
            var beforePerforming = instrument.Wear;
            setController.PerformSets();
            var afterPerforming = instrument.Wear;

            Assert.AreNotEqual(beforePerforming, afterPerforming);

        }

    }
}