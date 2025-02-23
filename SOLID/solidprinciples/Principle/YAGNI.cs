namespace solidprinciples.Principle;

// In this example, the Author class follows the YAGNI principle of implementing minimal functionality. For this simple example, we have considered only two attributes of the Author entity, i.e. the first name and last name.
class Author
    {
        private string _firstName;
        private string _lastName;
        public Author(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
        }
        public string GetAuthorName()
        {
            return $"{_firstName} {_lastName}";
        }
    }
