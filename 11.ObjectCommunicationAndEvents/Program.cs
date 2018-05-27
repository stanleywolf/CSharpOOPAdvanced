using System;

namespace Object_Communication_and_Events_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            var combatLog = new CombatLogger();
            var eventLog = new EventLogger();

            combatLog.SetSuccessor(eventLog);

            var warrior = new Warrior("Nikola",50,combatLog);
            var dragon = new Dragon("Yoan",60,20,combatLog);

            IExecutor executor = new CommandExecutor();
            ICommand command = new TargetCommand(warrior,dragon);
            ICommand attack = new AttackComand(warrior);
        }
    }
}
