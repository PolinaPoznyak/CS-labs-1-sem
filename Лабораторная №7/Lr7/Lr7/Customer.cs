using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr7
{
    // контракт о взаимодействии между классом
    interface IBoxing
    {
        void Boxing(bool isBox);
    }
    abstract class Box
    {
        public abstract void Boxing(bool isBox);
    }
    // одноименные методы
    class Customer : Box, IBoxing
    {
        public override void Boxing(bool isBox)
        {
            if (isBox == true)
            {
                Console.WriteLine("\nКондитерские изделия необходимо уложить в коробку\n");
            }
            else
            {
                Console.WriteLine("\nНет необходимости укладывать кондитерские изделия в коробку\n");
            }
        }
        //public void CheckInfo(IBoxing boxing)
        //{
        //    boxing.Boxing(true);
        //}
        public void CheckInfo(IHasInfo hasInfo)
        {
            hasInfo.DisplayInfo();
        }
    }
}
