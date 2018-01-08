using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_03
{
    public class Car: IComparable<Car>
    {
        public string mark { get; set; }
        public string model { get; set; }
        public string type { get; set; }
        public double price { get; set; }

        public override string ToString()
        {
            return "Mark:  " + mark+".\nModel: "+model+".\nType:  "+type+".\nPrice: "+price+"\n";
        }

        // compare this car with got car
        public int CompareTo(Car compareCar)
        {
            // A null value means that this object is greater.
            if ( compareCar==null )
            {
                return 1;
            }

            if ( !Double.Equals(price , compareCar.price) )
            {
                return price > compareCar.price ? 1 : -1;
            }
            if ( String.Compare(type, compareCar.type) != 0)
            {
                return String.Compare(model , compareCar.model);
            }
            if ( String.Compare(mark , compareCar.mark)!=0 )
            {
                return String.Compare(mark , compareCar.mark);
            }
            return 0;
        }

    }
}
