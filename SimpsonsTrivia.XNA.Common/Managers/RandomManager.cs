using System;

namespace WindowsGame.Common.Managers
{
	public interface IRandomManager
	{
		void Initialize();
		Int32 Generate(Int32 max);
		Int32 Generate(Int32 min, Int32 max);
	}

	public class RandomManager : IRandomManager
	{
		private Random random;

		public void Initialize()
		{
			random = new Random((Int16)DateTime.Now.Ticks & 0x0000FFFF);
		}

		public Int32 Generate(Int32 max)
		{
			return random.Next(max);
		}
		public Int32 Generate(Int32 min, Int32 max)
		{
			return random.Next(min, max);
		}
	}

}