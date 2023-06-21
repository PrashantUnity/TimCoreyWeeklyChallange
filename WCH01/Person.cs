namespace WCH01
{
    internal class Person
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"First Name : {FirstName}\nLast Name : {LastName}";
        }
    }
}