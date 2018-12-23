// REMOVE any "using" statements, which start with "Travel." BEFORE SUBMITTING

//using Travel.Core.Controllers;
//using Travel.Entities;
//using Travel.Entities.Airplanes;
//using Travel.Entities.Items;
//using Travel.Entities.Items.Contracts;

namespace Travel.Tests
{
	using NUnit.Framework;

    [TestFixture]
    public class FlightControllerTests
    {

        //public void TestIsMethodTakeOfProperly()
        //{
        //    var airport = new Airport();

        //    var airPlane = new LightAirplane();
        //    var passenger = new Passenger("Goiko Mitich");
        //    airPlane.AddPassenger(passenger);

        //    //test is airplaen is overbook
        //    //test load carry on baggage
        //    var passengers = new Passenger[10];

        //    for (int i = 0; i < passengers.Length; i++)
        //    {
        //        passengers[i] = new Passenger("Pesho" + i);
        //        airPlane.AddPassenger(passengers[i]);
        //        //
        //    }

        //    for (int i = 0; i < 5; i++)
        //    {
        //        if (i % 2 == 0)
        //        {
        //            var bag = new Bag(passengers[i], new IItem[] {new Colombian()});
        //            passengers[i].Bags.Add(bag);
        //        }
        //        else
        //        {
        //            var bag = new Bag(passengers[i], new IItem[] {new Toothbrush()});
        //            passengers[i].Bags.Add(bag);
        //        }
        //    }

        //    var trips = new Trip("Bankiq", "Turnomogurele", airPlane);
        //    airport.AddTrip(trips);

        //    //тест IsCompleted
        //    var completedTrip = new Trip("tam", "tuk", new MediumAirplane());
        //    completedTrip.Complete();
        //    airport.AddTrip(completedTrip);

        //    FlightController flightController = new FlightController(airport);

        //    var actualResult = flightController.TakeOff();
        //    var expectedResult =
        //        "BankiqTurnomogurele1:\r\nOverbooked! Ejected Pesho0, Goiko Mitich, Pesho2, Pesho6, Pesho7, Pesho8\r\nConfiscated 2 bags ($100000)\r\nSuccessfully transported 5 passengers from Bankiq to Turnomogurele.\r\nConfiscated bags: 2 (2 items) => $100000";

        //    Assert.AreEqual(actualResult, expectedResult);
        //    Assert.That(trips.IsCompleted);
        //}

        [Test]
        public void CheckTripIsCompleted()
        {
            var airport = new Airport();
            var airplane = new LightAirplane();
            var passenger = new Passenger("Bai Ganio");
            airplane.AddPassenger(passenger);
            var bag = new Bag(passenger, new IItem[] {new Jewelery()});
            passenger.Bags.Add(bag);

            var trip = new Trip("Tuk", "Tam", airplane);
            trip.Complete();
            airport.AddTrip(trip);
            var flightController = new FlightController(airport);

            var expected = flightController.TakeOff();
            var actual = "Confiscated bags: 0 (0 items) => $0";

            Assert.AreEqual(expected, actual);
            Assert.IsTrue(trip.IsCompleted);
        }

        [Test]
        public void AirplaneIsOverbooked()
        {
            var airport = new Airport();

            var airPlane = new LightAirplane();
            var trip = new Trip("Tuk", "Tam", airPlane);

            //test is airplaen is overbook
            var passengers = new Passenger[10];

            for (int i = 0; i < passengers.Length; i++)
            {
                passengers[i] = new Passenger("Pesho" + i);
                airPlane.AddPassenger(passengers[i]);
                //
            }
            airport.AddTrip(trip);

            var flightController = new FlightController(airport);

            var expected = flightController.TakeOff();
            var actual = "TukTam1:\r\nOverbooked! Ejected Pesho1, Pesho0, Pesho3, Pesho7, Pesho8\r\nConfiscated 0 bags ($0)\r\nSuccessfully transported 5 passengers from Tuk to Tam.\r\nConfiscated bags: 0 (0 items) => $0";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestLoadingBag()
        {
            var airport = new Airport();

            var airPlane = new LightAirplane();

            //test load carry on baggage
            var passengers = new Passenger[10];

            for (int i = 0; i < passengers.Length; i++)
            {
                passengers[i] = new Passenger("Pesho" + i);
                airPlane.AddPassenger(passengers[i]);
                //
            }

            for (int i = 0; i < 5; i++)
            {
                if (i % 2 == 0)
                {
                    var bag = new Bag(passengers[i], new IItem[] { new Colombian() });
                    passengers[i].Bags.Add(bag);
                }
                else
                {
                    var bag = new Bag(passengers[i], new IItem[] { new Toothbrush() });
                    passengers[i].Bags.Add(bag);
                }
            }

            var trips = new Trip("Bankiq", "Turnomogurele", airPlane);
            airport.AddTrip(trips);


            var flightController = new FlightController(airport);

            var expected = flightController.TakeOff();
            var actual = "BankiqTurnomogurele1:\r\nOverbooked! Ejected Pesho1, Pesho0, Pesho3, Pesho7, Pesho8\r\nConfiscated 3 bags ($50006)\r\nSuccessfully transported 5 passengers from Bankiq to Turnomogurele.\r\nConfiscated bags: 3 (3 items) => $50006";

            Assert.AreEqual(expected, actual);
        }
    }
}
