namespace solidprinciples.Principle;

public class KISS
{
   //As you can see here, the method that uses a Switch-Case construct is much simpler and easier to understand.
    public static string GetMonthNameUsingSwitchCase(int number)
   {
     switch (number)
     {
         case 1:
             return "January";
         case 2:
             return "February";
         case 3:
             return "March";
         case 4:
             return "April";
         case 5:
             return "May";
         case 6:
             return "June";
         case 7:
             return "July";
         case 8:
             return "August";
         case 9:
             return "September";
         case 10:
             return "October";
         case 11:
             return "November";
         case 12:
             return "December";
         default:
             throw new InvalidOperationException();
        }
   }

public static string GetMonthNameUsingIfElse(int number)
{
     if ((number < 1) || (number > 12)) throw new InvalidOperationException();
         string[] months = {
             "January",
             "February",
             "March",
             "April",
             "May",
             "June",
             "July",
             "August",
             "September",
             "October",
             "November",
             "December"
     };
         return months[number - 1];
}


}
