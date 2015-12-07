namespace CodeChallenge04_BowlingScorer
{
	public static class BowlingFrameValidator
	{
		public static bool IsValid(this BowlingFrame frame)
		{
			var isValidFrame = IsValidFrameNumber(frame) && IsValidFrameScore(frame);

			return isValidFrame;
		}

		private static bool IsValidFrameNumber(this BowlingFrame frame)
		{
			return frame.FrameNumber >= 1 && frame.FrameNumber <= 10;
		}

		private static bool IsValidFrameScore(this BowlingFrame frame)
		{
			if (frame.IsFinalFrame())
			{
				return IsValidTenthFrameScore(frame);
			}

			var isValidFrameScore = IsValidSpare(frame)
									|| IsValidStrike(frame)
									|| IsValidTwoBallScore(frame);

			return isValidFrameScore;
		}

		public static bool IsFinalFrame(this BowlingFrame frame)
		{
			return frame.FrameNumber == 10;
		}

		private static bool IsValidTenthFrameScore(this BowlingFrame frame)
		{
			if (!frame.IsFinalFrame())
			{
				return false;
			}
			
			var isValidTenthFrameScore = !frame.Ball1.IsNull()
										&& !frame.Ball2.IsNull()
										&& !frame.Ball1.IsSpare()
										&& !frame.Ball3.IsSpare();

			var hasStrikesOrSpares = frame.Ball1.IsStrike()
									|| frame.Ball2.IsStrike()
									|| frame.Ball2.IsSpare()
									|| frame.Ball3.IsStrike();

			var hasInvalidScoreInThirdBall = frame.Ball1.GetScore() + frame.Ball2.GetScore() >= 10
													&& frame.Ball3.IsNull();

			// for strikes and spares, third ball must not be null; the opposite must also be true
			if (hasInvalidScoreInThirdBall 
				|| (hasStrikesOrSpares && frame.Ball3.IsNull())
				|| !hasStrikesOrSpares && !frame.Ball3.IsNull())
			{
				isValidTenthFrameScore = false;
			}

			return isValidTenthFrameScore;
		}

		private static bool IsValidSpare(this BowlingFrame frame)
		{
			var isValidSpare = !frame.Ball1.IsNull()
								&& frame.Ball1.GetScore() < 10
								&& frame.Ball2.IsSpare()
								&& frame.Ball3.IsNull();

			return isValidSpare;
		}

		private static bool IsValidStrike(this BowlingFrame frame)
		{
			var isValidStrike = frame.Ball1.IsStrike()
								&& frame.Ball2.IsNull()
								&& frame.Ball3.IsNull();

			return isValidStrike;
		}

		private static bool IsValidTwoBallScore(this BowlingFrame frame)
		{
			var isValidTwoBallScore = !frame.Ball1.IsNull()
									&& !frame.Ball2.IsNull()
									&& frame.Ball3.IsNull()
									&& !frame.Ball1.IsStrike()
									&& !frame.Ball2.IsStrike()
									&& !frame.Ball1.IsSpare()
									&& !frame.Ball2.IsSpare()
									&& frame.Ball1.GetScore() < 10
									&& frame.Ball2.GetScore() < 10
									&& frame.Ball1.GetScore() + frame.Ball2.GetScore() < 10;

			return isValidTwoBallScore;
		}
	}
}