using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    internal class CheckClass
    {
        List<object> ObjList { get; set; }

        public CheckClass(List<object> list)
        {
            ObjList = list;
        }

        public string Compare(List<object> list1)
        {
            if (ObjList.Count() != list1.Count())
            {
                return "Списки не равны";
            }
            else
            {
                for (int i = 0; i < list1.Count(); i++)
                {
                    foreach (Attribute a in list1[i].GetType().GetCustomAttributes())
                    {
                        if (a is NotComparable)
                        {
                            return $"Найден нечитаемый тип {list1[i].GetType()}!\nВ позиции: {i + 1}";
                        }
                    }
                    foreach (PropertyInfo p in list1[i].GetType().GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static))
                    {
                        if (Attribute.IsDefined(p, typeof(Unreadable)))
                        {
                            return $"Найден нечитаемый тип поля {p.Name}!\nВ позиции:{i + 1}";
                            
                        }
                    }
                    if (ObjList[i].GetType() != list1[i].GetType())
                    {
                        return $"Найдено расхождение в типах!\nВ позиции: {i+1}\nПолучено: {list1[i].GetType()}\nОжидалось: {ObjList[i].GetType().Name}";
                        
                    }
                    else
                    {
                        foreach (PropertyInfo p in list1[i].GetType().GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static))
                        {
                            if (p.GetValue(ObjList[i], null) != p.GetValue(list1[i], null))
                            {
                                return $"Найдено расхождение в значениях!\nВ позиции: {i + 1} В поле: {p.Name}\nПолучено: {p.GetValue(list1[i], null)}\nОжидалось: {p.GetValue(ObjList[i], null)}";
                               
                            }
                        }

                    }
                }
            }
            return "Коллекции равны";
        }
    }
}
