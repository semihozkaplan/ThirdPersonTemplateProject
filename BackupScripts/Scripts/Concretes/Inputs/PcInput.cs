using MasterGame3D.Abstracts.Inputs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MasterGame3D.Inputs
{
    public class PcInput : IInput
    {
        public float Horizontal => Input.GetAxisRaw("Horizontal");
        public float Vertical => Input.GetAxisRaw("Vertical");
        public bool Jump => Input.GetButtonDown("Jump");

    }

}

