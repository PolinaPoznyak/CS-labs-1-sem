using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr10
{
    class FurnitureList : IList<Furniture>
    {
        public IList<Furniture> _listOfFurniture = new List<Furniture>();
        public FurnitureList() { }
        public FurnitureList(ArrayList values)
        {
            foreach (Furniture item in values)
                Add(item);
        }
        public IEnumerator<Furniture> GetEnumerator()
        {
            return _listOfFurniture.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(Furniture item)
        {
            _listOfFurniture.Add(item);
        }

        public void Clear()
        {
            _listOfFurniture.Clear();
        }

        public bool Contains(Furniture item)
        {
            return _listOfFurniture.Contains(item);
        }

        public void CopyTo(Furniture[] array, int arrayIndex)
        {
            _listOfFurniture.CopyTo(array, arrayIndex);
        }

        public bool Remove(Furniture item)
        {
            return _listOfFurniture.Remove(item);
        }

        public int Count
        {
            get { return _listOfFurniture.Count; }
        }

        public bool IsReadOnly
        {
            get { return _listOfFurniture.IsReadOnly; }
        }


        public int IndexOf(Furniture item)
        {
            return _listOfFurniture.IndexOf(item);
        }

        public void Insert(int index, Furniture item)
        {
            _listOfFurniture.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _listOfFurniture.RemoveAt(index);
        }

        public Furniture this[int index]
        {
            get { return _listOfFurniture[index]; }
            set { _listOfFurniture[index] = value; }
        }

    }

}
