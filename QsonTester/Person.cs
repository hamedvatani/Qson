namespace QsonTester
{
    public class Person
    {
        public string Name { get; set; }
        public string[] Tels { get; set; }

        public bool IsEqual(Person p)
        {
            if (Name == p.Name && StringArrayIsEqual(Tels, p.Tels))
                return true;
            return false;
        }

        private bool StringArrayIsEqual(string[] list1, string[] list2)
        {
            if (list1 == null && list2 == null)
                return true;
            if (list1 != null && list2 != null)
            {
                if (list1.Length != list2.Length)
                    return false;
                for (int i = 0; i < list1.Length; i++)
                    if (list1[i] != list2[i])
                        return false;
                return true;
            }
            return false;
        }
    }
}