using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL.Model.Factory
{
    public class StepAnswerFactory
    {
        public static StepAnswer Create(int pGameId, int pPlayerId, int pPreviousStepId, int pNextStepId, int pAnswer,
                                        int pPreviousCardNumber, ESuit pPreviousCardSuit,
                                        int pNextCardNumber, ESuit pNextCardSuit)
        {
            EStepResult result = EStepResult.Incorrect;
            var answer = (EStepAnswer)pAnswer;
            switch (answer)
            {
                case EStepAnswer.Higher:
                    result = pNextCardNumber >= pPreviousCardNumber ? EStepResult.Correct : EStepResult.Incorrect;
                    break;
                case EStepAnswer.Lower:
                    result = pNextCardNumber <= pPreviousCardNumber ? EStepResult.Correct : EStepResult.Incorrect;
                    break;
            }

            return new StepAnswer
            {
                Answer = answer,
                GameId = pGameId,
                NextStepId = pNextStepId,
                PlayerId = pPlayerId,
                PreviousStepId = pPreviousStepId,
                Result = result,
            };
        }
    }
}
