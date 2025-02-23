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

    //We have not implemented unnecessary characteristics like age, address, or telephone number. We may implement these attributes later, if we discover we have a use for them. In the meantime, we adhere to the YAGNI principle by not implementing unnecessary features and avoiding code bloat—additional features that may make the code harder to comprehend, use, and maintain.
