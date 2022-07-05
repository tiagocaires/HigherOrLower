using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL.Service
{
    public interface IStepService
    {
        Task<IActionResult> Create(StepNewRequest pStepNewRequest);
    }
}
