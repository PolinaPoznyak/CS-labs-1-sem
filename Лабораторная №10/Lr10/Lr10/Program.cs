using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Lr10
{
    class Program
    {
        static void Main(string[] args)
        {
            Furniture obj1 = new Furniture() { name = "Диван 'Альбина'", price = 500, madeOf = "ткань", inStock = true };
            Furniture obj2 = new Furniture() { name = "Диван 'Марго'", price = 700, madeOf = "кожа", inStock = true };
            Furniture obj3 = new Furniture() { name = "Табурет", price = 50, madeOf = "дерево", inStock = true };
            Furniture obj4 = new Furniture() { name = "Напольная вешалка", price = 70, madeOf = "металл", inStock = false };
            Furniture obj5 = new Furniture() { name = "Комод", price = 250, madeOf = "дерево", inStock = false };

            ArrayList listOfFurniture = new ArrayList();
            var _list = new FurnitureList(listOfFurniture);

            //listOfFurniture.Add(obj1);
            //listOfFurniture.Add(obj2);
            //listOfFurniture.Add(obj3);
            //listOfFurniture.Add(obj4);
            //listOfFurniture.Add(obj5);

            //listOfFurniture.Contains(obj1);
            //listOfFurniture.RemoveAt(0);
            //listOfFurniture.Contains(obj1);

            _list.Add(obj1);
            _list.Add(obj2);
            _list.Add(obj3);
            _list.Add(obj4);
            _list.Add(obj5);

            Console.WriteLine($"До удаления первого объекта: {_list.Contains(obj1)}");
            _list.RemoveAt(0);
            Console.WriteLine($"После удаления первого объекта: {_list.Contains(obj1)}");

            foreach (var item in _list)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("\n<---List<T> — это универсальная версия ArrayList--->\n");                     //Первая коллекция

            List<Furniture> genericList = new List<Furniture>() { };
            genericList.Add(obj1);
            genericList.Add(obj4);
            genericList.Insert(1, obj5);
            genericList.Remove(obj2);
            
            Console.WriteLine($"Индекс первого вхождения элемента {obj4.name} в списке: {genericList.IndexOf(obj4) + 1}");
            
            foreach (var item in genericList)
            {
                Console.WriteLine(item.name);
            }

            Console.WriteLine("\n<---Коллекция Stack<T>--->\n");                                                   //Вторая коллекция

            Stack<Furniture> stackFurniture = new Stack<Furniture>(genericList);

            foreach (var item in stackFurniture)
            {
                Console.WriteLine(item.name);
            }

            Console.WriteLine("\n<---Класс ObservableCollection--->\n");

            ObservableCollection<Furniture> furn = new ObservableCollection<Furniture>
            {
                obj1, obj2, obj3
            };

            furn.CollectionChanged += Furn_CollectionChanged;                       //позволяет обрабатывать изменения коллекции

            furn.Add(obj4);
            furn.Remove(obj3);
            furn[0] = new Furniture { name = "Кресло-груша", price = 200, madeOf = "ткань", inStock = true };

            Console.WriteLine("\nКаталог магазина:\n");
            foreach (var item in furn)
            {
                Console.WriteLine(item.name);
            }
        }

        private static void Furn_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Furniture newFurn = e.NewItems[0] as Furniture;
                    Console.WriteLine($"В магазине обновление ассортимента! В каталог добавили: {newFurn.name}");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Furniture oldFurn = e.OldItems[0] as Furniture;
                    Console.WriteLine($"Товар {oldFurn.name} сняли с производства");
                    break;
                case NotifyCollectionChangedAction.Replace:
                    Furniture replacedFurn = e.OldItems[0] as Furniture;
                    Furniture replacingFurn = e.NewItems[0] as Furniture;
                    Console.WriteLine($"Товар {replacedFurn.name} сняли с производства. Однако его заменит новинка - {replacingFurn.name}");
                    break;
            }
        }
    }
}
