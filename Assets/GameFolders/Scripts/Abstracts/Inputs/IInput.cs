using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MasterGame3D.Abstracts.Inputs
{
    public interface IInput
    {
        float Horizontal { get; }
        float Vertical { get; }
        bool Jump { get; }
    }
}


