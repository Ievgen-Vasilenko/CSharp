using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson4
{
    public abstract class Car
    {
        protected int _speed;
        protected string _type;

        public Car()
        {
            _speed = 0;
            _type = "noname";
        }

        public abstract void Drive();

        public override string ToString()
        {
            return string.Format("Model: {0}; Max speed: {1}", _type, _speed);
        }

    }

    public class Vaz : Car
    {

        public Vaz() :base()
        {
            _type = "VAZ 2107";
        }

        public override void Drive()
        {
            _speed = 60;
        }

    }

    public class Lamborgini : Car, ITurbo
    {
        public Lamborgini() : base()
        {
            Turbo();
            _type = "Gallardo";
        }

        public override void Drive()
        {
            _speed = 260;
        }

        public void Turbo()
        {
            
        }

    }

    public class Ferrari : Car, IExtendedEngine
    {

        public Ferrari() : base()
        {
            _type = "Testarossa";
        }

        public override void Drive()
        {
            ExtendEngine();
            _speed = 240;
        }

        public void ExtendEngine()
        {
            
        }

    }

    interface ITurbo
    {
        void Turbo();
    }

    interface IExtendedEngine
    {
        void ExtendEngine();
    }
}
