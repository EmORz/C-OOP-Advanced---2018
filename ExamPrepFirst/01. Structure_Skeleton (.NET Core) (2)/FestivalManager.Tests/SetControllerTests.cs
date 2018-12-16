// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)

using System;
using FestivalManager.Core.Controllers;
using FestivalManager.Core.Controllers.Contracts;
using FestivalManager.Entities;
using FestivalManager.Entities.Contracts;
using FestivalManager.Entities.Instruments;
using FestivalManager.Entities.Sets;

namespace FestivalManager.Tests
{
	using NUnit.Framework;

	[TestFixture]
	public class SetControllerTests
    {
		[Test]
	    public void SetControllerShouldReturnFailMessage()
	    {
            IStage stage = new Stage();
            ISetController setController = new SetController(stage);

            ISet set = new Short("Set1");
            stage.AddSet(set);

	        var expectedResult = "1. Set1:\r\n-- Did not perform";
            var actualResult = setController.PerformSets();

            Assert.That(actualResult, Is.EqualTo(expectedResult));
	    }

        [Test]
        public void SetControllerShouldReturnSucessMessage()
        {
            IStage stage = new Stage();
            ISetController setController = new SetController(stage);

            ISet set = new Short("Set1");

            IPerformer performer = new Performer("Pesho", 22);
            performer.AddInstrument(new Guitar());
            set.AddPerformer(performer);

            ISong song = new Song("Bai Hu", new TimeSpan(0, 2, 30));
            set.AddSong(song);

            stage.AddSet(set);

            var actualResult = setController.PerformSets();
            var expectedResult = "1. Set1:\r\n-- 1. Bai Hu (02:30)\r\n-- Set Successful";

            Assert.AreEqual(actualResult, expectedResult);

        }

        [Test]
        public void PerformShouldDecreaseInstrumentWear()
        {
            IStage stage = new Stage();
            ISetController setController = new SetController(stage);

            ISet set = new Short("Set1");

            IPerformer performer = new Performer("Pesho", 22);
            IInstrument instrument = new Guitar();
            performer.AddInstrument(instrument);
            set.AddPerformer(performer);

            ISong song = new Song("Bai Hu", new TimeSpan(0, 2, 30));
            set.AddSong(song);

            stage.AddSet(set);
            var instrumentBefore = instrument.Wear;

            setController.PerformSets();
            var instrumentAfter = instrument.Wear;

            Assert.AreNotEqual(instrumentBefore, instrumentAfter);

        }
	}
}