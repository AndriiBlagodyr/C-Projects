using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseOfCarsRemadeVersion
{
    [Serializable]
    public class SportCar : AbstractCar
    {
        protected string owner;
        protected string model;
        protected string color;
        protected string speed;

        public SportCar(string Owner, string Model, string Color, string Speed)
            : base(Owner, Model, Color, Speed)
        {
        }

        public string Owner
        {
            get { return owner; }
            set { owner = value; }
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public string Color
        {
            get { return color; }
            set { color = value; }
        }
        public string Speed
        {
            get { return speed; }
            set { speed = value; }
        }
    }
}
