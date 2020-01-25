using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseOfCarsRemadeVersion
{
    [Serializable]
    public abstract class AbstractCar
    {
        public string owner;
        public string model;
        public string color;
        public string speed;

        public AbstractCar(string Owner, string Model, string Color, string Speed)
        {
            this.owner = Owner;
            this.model = Model;
            this.color = Color;
            this.speed = Speed;
        }
    }
}
