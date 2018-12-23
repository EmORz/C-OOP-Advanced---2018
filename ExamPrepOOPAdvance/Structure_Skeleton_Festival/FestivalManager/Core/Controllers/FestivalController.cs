using FestivalManager.Entities;
using FestivalManager.Entities.Factories.Contracts;

namespace FestivalManager.Core.Controllers
{
	using System;
	using System.Globalization;
	using System.Linq;
	using System.Text;
	using Contracts;
	using Entities.Contracts;

	public class FestivalController : IFestivalController
	{
		private const string TimeFormat = "mm\\:ss";
		private const string TimeFormatLong = "{0:2D}:{1:2D}";
		private const string TimeFormatThreeDimensional = "{0:3D}:{1:3D}";

	    private ISetFactory setFactory;
	    private IInstrumentFactory instrumentFactory;
		private readonly IStage stage;

		public FestivalController(IStage stage, ISetFactory setFactory, IInstrumentFactory instrumentFactory)
		{
			this.stage = stage;
		    this.instrumentFactory = instrumentFactory;
		    this.setFactory = setFactory;
		}



	    public string RegisterSet(string[] args)
	    {
	        var name = args[0];
	        var typeSetName = args[1];

	        var set = this.setFactory.CreateSet(name, typeSetName);
            this.stage.AddSet(set);

	        return $"Registered {typeSetName} set";



	    }
        public string ProduceReport()
		{
			var result = string.Empty;

			var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));
		
            result += ($"Festival length: {(TimeCalc(totalFestivalLength))}") + "\n";

            foreach (var set in this.stage.Sets)
			{
                result += ($"--{set.Name} ({TimeCalc(set.ActualDuration)}):") + "\n";

                var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
				foreach (var performer in performersOrderedDescendingByAge)
				{
					var instruments = string.Join(", ", performer.Instruments
						.OrderByDescending(i => i.Wear));

					result += ($"---{performer.Name} ({instruments})") + "\n";
				}

				if (!set.Songs.Any())
					result += ("--No songs played") + "\n";
				else
				{
					result += ("--Songs played:") + "\n";
					foreach (var song in set.Songs)
					{
						result += ($"----{song.Name} ({TimeCalc(song.Duration)})") + "\n";
					}
				}
			}

			return result.ToString();
		}
	    private string TimeCalc(TimeSpan span)
	    {
	        int minutes = span.Hours * 60 + span.Minutes;
	        return $"{minutes:d2}:{span.Seconds:d2}";
	    }



        public string SignUpPerformer(string[] args)
		{
			var name = args[0];
			var age = int.Parse(args[1]);

			var instrumentNames = args.Skip(2).ToArray();

			var instuments = instrumentNames
                .Select(i => this.instrumentFactory.CreateInstrument(i))
                .ToArray();

			IPerformer performer = new Performer(name, age);

			foreach (var instrument in instuments)
			{
                performer.AddInstrument(instrument);
            }

			this.stage.AddPerformer(performer);

			return $"Registered performer {performer.Name}";
		}

		public string RegisterSong(string[] args)
		{
		    var songName = args[0];
		    var songDurationTokens = args[1].Split(":").Select(int.Parse).ToArray();
		    var songMin = songDurationTokens[0];
		    var songSec = songDurationTokens[1];
            
            TimeSpan songDuration = new TimeSpan(0, songMin, songSec);
            ISong song = new Song(songName, songDuration );
            this.stage.AddSong(song);

		    return $"Registered song {song}";
		}

	    public string AddSongToSet(string[] args)
	    {
	        var songName = args[0];
	        var setName = args[1];

	        if (!this.stage.HasSet(setName))
	        {
	            throw new InvalidOperationException("Invalid set provided");
	        }

	        if (!this.stage.HasSong(songName))
	        {
	            throw new InvalidOperationException("Invalid song provided");
	        }

	        var set = this.stage.GetSet(setName);
	        var song = this.stage.GetSong(songName);

	        set.AddSong(song);

	        return $"Added {song} to {set.Name}";
	    }

		public string AddPerformerToSet(string[] args)
		{
		    var performerName = args[0];
		    var setName = args[1];

		    if (!this.stage.HasPerformer(performerName))
		    {
		        throw new InvalidOperationException("Invalid performer provided");
		    }

		    if (!this.stage.HasSet(setName))
		    {
		        throw new InvalidOperationException("Invalid set provided");
		    }

		    var performer = this.stage.GetPerformer(performerName);
		    var set = this.stage.GetSet(setName);

		    set.AddPerformer(performer);

		    return $"Added {performer.Name} to {set.Name}";
        }
        

		public string RepairInstruments(string[] args)
		{
			var instrumentsToRepair = this.stage.Performers
				.SelectMany(p => p.Instruments)
				.Where(i => i.Wear < 100)
				.ToArray();

			foreach (var instrument in instrumentsToRepair)
			{
				instrument.Repair();
			}

			return $"Repaired {instrumentsToRepair.Length} instruments";
		}
	}
}