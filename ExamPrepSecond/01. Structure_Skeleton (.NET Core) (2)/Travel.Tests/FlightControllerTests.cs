// REMOVE any "using" statements, which start with "Travel." BEFORE SUBMITTING

using System.Runtime.InteropServices.ComTypes;
using Travel.Core.Controllers;
using Travel.Entities;
using Travel.Entities.Airplanes;
using Travel.Entities.Items;
using Travel.Entities.Items.Contracts;

namespace Travel.Tests
{
	using NUnit.Framework;

	[TestFixture]
    public class FlightControllerTests
	{
	    private Airport airport;
	    private Airplane airplane;
	    private FlightController flightController;
	    private Trip trip;

	    [SetUp]
        public void SetUp()
        {
            this.airport = new Airport();
            this.airplane = new LightAirplane();
            this.flightController = new FlightController(airport);
            this.trip = new Trip("Tik", "Pik", airplane);

        }

	    ////[Test]
	    //public void TestIsTakeOfMethodWorkProperly()
	    //{
     //       //todo 2:12:00 implement other part - structure problem on some diff [Test]
	    //    var passenger = new Passenger("Gosho");

     //       var airport = new Airport();
	    //    var airplane = new LightAirplane();

     //       var passangers = new Passenger[10];

	    //    for (int i = 0; i < passangers.Length; i++)
	    //    {
	    //        passangers[i]= new Passenger("Gosho "+i);
     //           airplane.AddPassenger(passangers[i]);
	    //    }

	    //    for (int i = 0; i < 5; i++)
	    //    {
	    //        if (i % 2 == 0)
	    //        {
	    //            var bag = new Bag(passangers[i], new IItem[] { new Colombian() });
	    //            passangers[i].Bags.Add(bag);
	    //        }
	    //        else
	    //        {
	    //            var bag = new Bag(passangers[i], new IItem[] { new Toothbrush() });
	    //            passangers[i].Bags.Add(bag);
	    //        }
     //       }
     //       var trip = new Trip("Tuk", "Tam", airplane);

     //       airport.AddTrip(trip);
     //       var completedTrip = new Trip("tam", "tak", new MediumAirplane());
     //       completedTrip.Complete();
     //       airport.AddTrip(completedTrip);
     //       FlightController flightController = new FlightController(airport);
	    //    var actualResult = flightController.TakeOff();
	    //    var expectedResult = "TukTam1:\r\nOverbooked! Ejected Gosho 1, Gosho 0, Gosho 3, Gosho 7, Gosho 8\r\nConfiscated 3 bags ($50006)\r\nSuccessfully transported 5 passengers from Tuk to Tam.\r\nConfiscated bags: 3 (3 items) => $50006";

     //       Assert.AreEqual(expectedResult, actualResult);
     //       Assert.That(trip.IsCompleted, Is.EqualTo(true));
	    //}

        [Test]
        public void CheckIfTripIsCompleted()
        {
            
            var passenger = new Passenger("Tosho");
            var bag = new Bag(passenger, new IItem[]{new Colombian()});
            passenger.Bags.Add(bag);
            airport.AddTrip(trip);
            trip.Complete();
            var expectedResult = flightController.TakeOff();
            var actualResult = "Confiscated bags: 0 (0 items) => $0";

            Assert.AreEqual(expectedResult, actualResult);

        }

        [Test]
        public void TestIfAirplaneIsOverbooked()
        {

            var passangers = new Passenger[10];
            for (int i = 0; i < passangers.Length; i++)
            {
                passangers[i] = new Passenger("Gosho " + i);
                airplane.AddPassenger(passangers[i]);
            }
            airport.AddTrip(trip);
            var expectedResult = flightController.TakeOff();
            var actualResult = "TikPik2:\r\nOverbooked! Ejected Gosho 1, Gosho 0, Gosho 3, Gosho 7, Gosho 8\r\nConfiscated " +
                               "0 bags ($0)\r\nSuccessfully transported 5 passengers from Tik to Pik.\r\nConfiscated bags: 0 (0 items) => $0";

            Assert.AreEqual(expectedResult, actualResult);

        }

        [Test]
        public void TestLoadCarryOnBaggage()
        {

            var passangers = new Passenger[10];
            for (int i = 0; i < passangers.Length; i++)
            {
                passangers[i] = new Passenger("Gosho " + i);
                airplane.AddPassenger(passangers[i]);
            }
            for (int i = 0; i < 5; i++)
            {
                if (i % 2 == 0)
                {
                    var bag = new Bag(passangers[i], new IItem[] { new Colombian() });
                    passangers[i].Bags.Add(bag);
                }
                else
                {
                    var bag = new Bag(passangers[i], new IItem[] { new Toothbrush() });
                    passangers[i].Bags.Add(bag);
                }
            }
            airport.AddTrip(trip);
            var actualResult = flightController.TakeOff();
            var expectedResult = "TikPik3:\r\nOverbooked! Ejected Gosho 1, Gosho 0, Gosho 3, Gosho 7, Gosho 8\r\nConfiscated 3 bags " +
                                 "($50006)\r\nSuccessfully transported 5 passengers from Tik to Pik.\r\nConfiscated bags: 3 (3 items) => $50006";

            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(trip.IsCompleted, true);


        }

    }
}
