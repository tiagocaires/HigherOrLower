using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL.Service
{
    public interface IGameService
    {
        Task<IActionResult> Create(GameNewRequestNew pGameRequest);
        IActionResult Score(GameScoreRequest pGameScoreRequest);
    }
}
