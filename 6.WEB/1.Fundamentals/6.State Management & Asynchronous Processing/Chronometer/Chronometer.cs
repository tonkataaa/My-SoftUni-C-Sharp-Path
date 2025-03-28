using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronometer
{
	public class Chronometer : IChronometer
	{
		private Stopwatch _stopWatch;
		private List<string> _laps;

		public Chronometer()
		{
			_stopWatch = new Stopwatch();
			_laps = new List<string>();
		}


		public string GetTime => _stopWatch.Elapsed.ToString(@"mm\:ss\.ffff");

		public List<string> Laps => _laps;

		public string Lap()
		{
			string result = GetTime;
			_laps.Add(result);

			return result;
		}

		public void Reset()
		{
			_stopWatch.Restart();
			_laps.Clear();
		}

		public void Start()
		{
			_stopWatch.Start();
		}

		public void Stop()
		{
			_stopWatch.Stop();
		}
	}
}
