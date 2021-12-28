using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr9
{
   
    public delegate void Upgrade(string message);
    public delegate void Turn_on(string message);
    class Boss
    {
        public event Upgrade Upgraded;
        public event Upgrade Upgradding;
        public event Turn_on Turned;

        //Upgrade _up; //переменная делегата
        //public void UpgradeState(Upgrade up)//метод через который мы передаем объект данного делегата(из внешнего кода передаём некоторые действия)
        //{
        //    _up = up;
        //}
        private string name;
        private int voltage;
        private bool alive;
        
        int upgrade;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Voltage
        {
            get { return voltage; }
            set { voltage = value; }
        }
        public bool Alive
        {
            get { return alive; }
            set { alive = value; }
        }
        public int Upgrade
        {
            get { return upgrade; }
            set { upgrade = value; }
        }

        public Boss(string _name, bool _alive)
        {
            Name = _name;
            Alive = _alive;
        }
        public Boss(string _name, int _voltage, int _upgrade)
        {
            Name = _name;
            Voltage = _voltage;
            Upgrade = _upgrade;
        }
        public Boss(string _name, int _voltage, bool _alive, int _upgrade)
        {
            Name = _name;
            Voltage = _voltage;
            Alive = _alive;
            Upgrade = _upgrade;
        }

        public void IsAlive()
        {
            if (Alive == true)
            {
                Console.WriteLine("Этот экземпляр является полу-техникой");
            }
            else
            {
                Console.WriteLine("Этот экземпляр является техникой");
            }
        }
        public void Upgrading(int _upgrade)
        {
            if (Upgradding != null) Upgradding($"Выполняется {upgrade} обновления");
            Upgrade += _upgrade;
            if (Voltage > 1000)
            {
                if (Upgraded != null) Upgraded("Из-за высокого напряжения техника сломалась. Не удалось осуществить обновления");
            }
            else
            {
                if (Upgraded != null) Upgraded($"Было выполнено {upgrade} обновлений");
            }
        }
        public void Turning_on(bool on_off)
        {
            if (on_off == true)
            {
                if (Turned != null) Turned($"{Name} включено(ON)");
            }
            else
            {
                if (Turned != null) Turned($"{Name} выключено (OFF)");
            }
        }
    }
    delegate void State(object sender, EventArgs e);
    class EventArgs
    {
        public string Message { get; }
        public int Upgr { get; }
        public EventArgs(string message, int upgr)
        {
            Message = message;
            Upgr = upgr;
        }
    }
}
