using System;
using System.Linq;

namespace CodeChallenge04_BowlingScorer
{
	public class BowlingResult
	{
		// properties
		public string PlayerName { get; private set; }
		public BowlingFrame[] Frames { get; private set; }

		// methods
		public bool ValidateFrames()
		{
			var uniqueFrameCount = Frames.Select(frame => frame.FrameNumber).Distinct().Count();
			if (Frames.Count() != 10 || Frames.Count() != uniqueFrameCount)
			{
				return false;
			}

			return Frames.All(frame => frame.IsValid());
		}

		public int CalculateScore()
		{
			var score = 0;

			foreach (var frame in Frames.OrderBy(f => f.FrameNumber))
			{
				if (frame.IsFinalFrame())
				{
					score += GetTenthFrameScore(frame);
					return score;
				}
					
				var ball1Score = frame.Ball1.GetScore();
				var ball2Score = frame.Ball2.GetScore();

				if (ball1Score < 10 && ball2Score < 10)
				{
					score += ball1Score + ball2Score;
				}
				else if (frame.Ball2.IsSpare())
				{
					var nextBall = Frames.Single(f => f.FrameNumber == frame.FrameNumber + 1).Ball1;

					score += ball1Score + frame.Ball2.GetScore(ball1Score) + nextBall.GetScore();
				}
				else if (frame.Ball1.IsStrike())
				{
					var nextFrame = Frames.Single(f => f.FrameNumber == frame.FrameNumber + 1);
					var nextBall = nextFrame.Ball1;
					var nextNextBall = nextFrame.Ball2;

					// if the next ball is a strike, then grab the first ball of the next frame after that
					if (nextBall.IsStrike() && !nextFrame.IsFinalFrame())
					{
						nextNextBall = Frames.Single(f => f.FrameNumber == frame.FrameNumber + 2).Ball1;
					}

					score += frame.Ball1.GetScore() + nextBall.GetScore() + nextNextBall.GetScore(nextBall.GetScore());
				}
			}

			// the score is returned after the 10th frame, so this point of the code should never be reached
			throw new Exception("No tenth frame found!");
		}

		private static int GetTenthFrameScore(BowlingFrame frame)
		{
			if (!frame.IsFinalFrame())
			{
				throw new ArgumentException("Frame number must be 10", "frame");
			}

			var ball1Score = frame.Ball1.GetScore();
			var ball2Score = frame.Ball2.GetScore();
			var score = 0;

			if (ball1Score < 10 && ball2Score < 10)
			{
				score = ball1Score + ball2Score;
			}
			else if (frame.Ball2.IsSpare())
			{
				score = ball1Score + frame.Ball2.GetScore(ball1Score) + frame.Ball3.GetScore();
			}
			else if (frame.Ball1.IsStrike())
			{
				var ball2 = frame.Ball2;
				var ball3 = frame.Ball3;
				score = frame.Ball1.GetScore() + ball2.GetScore() + ball3.GetScore();
			}

			return score;
		}

		// constructor
		public BowlingResult(string name, BowlingFrame[] frames)
		{
			PlayerName = name;
			Frames = frames;
		}
	}
}