using System.Globalization;

namespace CodeChallenge04_BowlingScorer
{
	public static class SingleBallScoreEnumParser
	{
		public static int GetScore(this SingleBallScoreEnum ball, int previousBallScore = 0)
		{
			if (IsStrike(ball))
			{
				return 10;
			}

			if (IsSpare(ball))
			{
				return 10 - previousBallScore;
			}
			return (int) ball;
		}

		public static bool IsNull(this SingleBallScoreEnum ball)
		{
			return (int) ball == -1;
		}

		public static bool IsSpare(this SingleBallScoreEnum ball)
		{
			return (int) ball == 10;
		}

		public static bool IsStrike(this SingleBallScoreEnum ball)
		{
			return (int) ball == 100;
		}

		public static string GetName(this SingleBallScoreEnum ball)
		{
			if (IsNull(ball))
			{
				return "";
			}

			if ((int) ball <= 0 || (int) ball >= 10)
			{
				return ball.ToString();
			}

			var ballValue = (int) ball;
			return ballValue.ToString(CultureInfo.InvariantCulture);
		}

	}
}