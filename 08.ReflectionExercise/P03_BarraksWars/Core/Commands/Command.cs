using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Contracts;

namespace P03_BarraksWars.Core.Commands
{
    public abstract class Command:IExecutable
    {
        private string[] data;
       
        protected Command(string[] data)
        {
            this.Data = data;
            
        }
        protected string[] Data { get { return this.data; } private set { this.data = value; } }

       

        public abstract string Execute();

    }
}
