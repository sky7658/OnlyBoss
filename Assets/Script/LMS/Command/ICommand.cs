using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LMS.Command
{
    public interface ICommand
    {
        public void Execute(ref bool isRunning);
        public bool Decision();
    }
}
