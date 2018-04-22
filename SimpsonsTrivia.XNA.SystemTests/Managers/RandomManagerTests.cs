using WindowsGame.Managers;
using NUnit.Framework;

namespace WindowsGame.SystemTests.Managers
{
	[TestFixture]
	public class RandomManagerTests
	{
		private IRandomManager randomManager;

		[SetUp]
		public void SetUp()
		{
			randomManager = new RandomManager();
		}

		[Test]
		public void LoadContentDataTest()
		{
		}

		[TearDown]
		public void TearDown()
		{
			randomManager = null;
		}

	}
}
