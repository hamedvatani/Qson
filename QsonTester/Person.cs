using System;
using System.Collections.Generic;

namespace QsonTester
{
    [Serializable]
    public class Person
    {
        public string Name { get; set; }
        public List<string> Tels { get; set; }

        public bool IsEqual(Person p)
        {
            if (Name == p.Name && StringListIsEqual(Tels, p.Tels))
                return true;
            return false;
        }

        private bool StringListIsEqual(List<string> list1, List<string> list2)
        {
            if (list1 == null && list2 == null)
                return true;
            if (list1 != null && list2 != null)
            {
                if (list1.Count != list2.Count)
                    return false;
                for (int i = 0; i < list1.Count; i++)
                    if (list1[i] != list2[i])
                        return false;
                return true;
            }
            return false;
        }
    }
}