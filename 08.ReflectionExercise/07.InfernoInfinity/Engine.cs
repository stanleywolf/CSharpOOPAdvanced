using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class Engine:IRunnable
{
    private IGemFactory gemFactory;
    private IWeaponFactory weaponFactory;
    private IWeaponRepository weaponRepository;
    private ICommandInterpreter commandInterpreter;

    public Engine(IGemFactory gemFactory,IWeaponFactory weaponFactory, IWeaponRepository weaponRepository, ICommandInterpreter commandInterpreter)
    {
        this.gemFactory = gemFactory;
        this.weaponFactory = weaponFactory;
        this.weaponRepository = weaponRepository;
        this.commandInterpreter = commandInterpreter;
    }

        public void Run()
        {
            while (true)
            {
                string[] tokens = Console.ReadLine().Split(";");
                IExecutable executable = this.commandInterpreter.InterpredCommand(tokens[0], tokens.Skip(1).ToArray());
                var fields = executable.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

                if (fields.Any(f => f.FieldType == typeof(IWeaponRepository)))
                {
                    fields.Single(f => f.FieldType == typeof(IWeaponRepository))
                        .SetValue(executable, this.weaponRepository);
                }

                if (fields.Any(f => f.FieldType == typeof(IWeaponFactory)))
                {
                    fields.Single(f => f.FieldType == typeof(IWeaponFactory))
                        .SetValue(executable, this.weaponFactory);
                }

                if (fields.Any(f => f.FieldType == typeof(IGemFactory)))
                {
                    fields.Single(f => f.FieldType == typeof(IGemFactory))
                        .SetValue(executable, this.gemFactory);
                }

                executable.Execute();
        }
        }
    }
  