using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace LMS.Command
{
    public class CommandManager : MonoBehaviour
    {
        private Dictionary<string, ICommand> commandDic = new Dictionary<string, ICommand>();
        private List<string> commandName = new List<string>();
        private Queue<ICommand> commands = new Queue<ICommand>();
        private bool isRunning = false;

        private int maxCount;

        private void Start()
        {
            AddCommand(new Attack1(), "attack1");
            AddCommand(new Attack2(), "attack2");
            AddCommand(new Attack3(), "attack3");

            maxCount = 3;

            StartCoroutine(Loop());
        }

        private void AutoExecuteCommand()
        {
            if (isRunning) return;

            var command = commands.Dequeue();
            if (!command.Decision()) return;

            isRunning = true;
            command.Execute(ref isRunning);
        }
        public void AddCommand(ICommand command, string cName)
        {
            if (commandDic.ContainsKey(cName)) return;
            commandDic.Add(cName, command);
            commandName.Add(cName);
        }

        public void RemoveCommand(string cName)
        {
            if (commandDic.ContainsKey(cName)) return;
            commandDic.Remove(cName);
            commandName.Remove(cName);
        }

        public void AssignCommand()
        {
            if (commands.Count == maxCount) return;
            var rand = Random.Range(0, commandDic.Count);
            commands.Enqueue(commandDic[commandName[rand]]);
        }

        private IEnumerator Loop()
        {
            while(true)
            {
                AssignCommand();
                if (commands.Count > 0) AutoExecuteCommand();
                yield return null;
            }
        }
    }

    public class Attack1 : ICommand
    {
        public void Execute(ref bool isRunning)
        {
            Debug.Log("공격1");
            isRunning = false;
        }
        public bool Decision() => true;
    }

    public class Attack2 : ICommand
    {
        public void Execute(ref bool isRunning)
        {
            Debug.Log("공격2");
            isRunning = false;
        }
        public bool Decision() => true;
    }

    public class Attack3 : ICommand
    {
        public void Execute(ref bool isRunning)
        {
            Debug.Log("공격3");
            isRunning = false;
        }
        public bool Decision() => true;
    }
}